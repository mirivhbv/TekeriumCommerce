using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TekeriumCommerce.Infrastructure;
using TekeriumCommerce.Infrastructure.Modules;
using TekeriumCommerce.Infrastructure.Web.ModelBinders;
using TekeriumCommerce.Module.Core.Data;

namespace TekeriumCommerce.WebHost.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // done! todo: Add ModuleConfigurationManager to Modules folder in TekeriumCommerce.Infrastructure
        public static readonly IModuleConfigurationManager modulesConfig = new ModuleConfigurationManager();

        public static IServiceCollection AddModules(this IServiceCollection services, string contentRootPath)
        {
            const string moduleManifestName = "module.json";
            var modulesFolder = Path.Combine(contentRootPath, "Modules");

            foreach (var module in modulesConfig.GetModules())
            {
                var moduleFolder = new DirectoryInfo(Path.Combine(modulesFolder, module.Id));
                var moduleManifestPath = Path.Combine(moduleFolder.FullName, moduleManifestName);
                if (!File.Exists(moduleManifestPath))
                {
                    // done! todo: create MissingModuleManifestException
                    throw new MissingModuleManifestException($"The manifest for the module '{moduleFolder.Name}' is not found.");
                }

                using (var reader = new StreamReader(moduleManifestPath))
                {
                    var content = reader.ReadToEnd();
                    dynamic moduleMetadata = JsonConvert.DeserializeObject(content);
                    module.Name = moduleMetadata.name;
                    module.IsBundledWithHost = moduleMetadata.isBundledWithHost;
                }

                // if is not bundled
                if (!module.IsBundledWithHost)
                {
                    //  done! todo: add method to this class: TryLoadModuleAssembly
                    TryLoadModuleAssembly(moduleFolder.FullName, module);
                    if (module.Assembly == null)
                    {
                        throw new Exception($"Cannot find main assembly for {module.Id}");
                    }
                }
                else
                {
                    module.Assembly = Assembly.Load(new AssemblyName(moduleFolder.Name));
                }

                GlobalConfiguration.Modules.Add(module);
                // done! todo: registermoduleinitializerservices
                RegisterModuleInitializerServices(module, ref services);
            }

            return services;
        }

        private static void TryLoadModuleAssembly(string moduleFolderPath, ModuleInfo module)
        {
            const string binariesFolderName = "bin";
            var binariesFolderPath = Path.Combine(moduleFolderPath, binariesFolderName);
            var binariesFolder = new DirectoryInfo(binariesFolderPath);

            if (Directory.Exists(binariesFolderPath))
            {
                foreach (var file in binariesFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
                {
                    Assembly assembly;
                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName);
                    }
                    catch (FileLoadException e)
                    {
                        assembly = Assembly.Load(new AssemblyName(Path.GetFileNameWithoutExtension(file.Name)));

                        if (assembly is null)
                            throw;

                        var loadedAssemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                        var tryToLoadAssemblyVersion = FileVersionInfo.GetVersionInfo(file.FullName).FileVersion;

                        // or log the exception somewhere and don't add the module to list so that it will not be initialized
                        if (tryToLoadAssemblyVersion != loadedAssemblyVersion)
                        {
                            throw new Exception(
                                $"Cannot load {file.FullName} {tryToLoadAssemblyVersion} because {assembly.Location} {loadedAssemblyVersion} has been loaded");
                        }
                    }

                    if (Path.GetFileNameWithoutExtension(assembly.ManifestModule.Name) == module.Id)
                    {
                        module.Assembly = assembly;
                    }
                }
            }
        }

        private static void RegisterModuleInitializerServices(ModuleInfo module, ref IServiceCollection services)
        {
            var moduleInitializerType = module.Assembly.GetTypes()
                .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
            if ((moduleInitializerType != null) && (moduleInitializerType != typeof(IModuleInitializer)))
            {
                services.AddSingleton(typeof(IModuleInitializer), moduleInitializerType);
            }
        }

        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services,
            IConfiguration configuration)
        {
            // done! todo: firstly should be create TekeriumDbContext class in Data dir of Modules.Core project
            services.AddDbContextPool<TekerDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TekeriumCommerce.WebHost"))
                );
            return services;
        }

        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            // todo: firstly should create models of user, role in Modules.Core project
            // todo: secondly, create Role and User Store in Modules.Core proj
            // todo: add authentication
            // todo: add configure application cookie

            // services.AddIdentity<>()


            return services;
        }

        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services, IList<ModuleInfo> modules)
        {
            var mvcBuilder = services
                .AddMvc(o => { o.ModelBinderProviders.Insert(0, new InvariantDecimalModelBinderProvider()); })
                .AddRazorOptions(o =>
                {
                    foreach (var module in modules.Where(x => !x.IsBundledWithHost))
                    {
                        o.AdditionalCompilationReferences.Add(
                            MetadataReference.CreateFromFile(module.Assembly.Location));
                    }
                })
                .AddViewLocalization()
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            foreach (var module in modules.Where(x => !x.IsBundledWithHost))
            {
                AddApplicationPart(mvcBuilder, module.Assembly);
            }

            return services;
        }

        private static void AddApplicationPart(IMvcBuilder mvcBuilder, Assembly assembly)
        {
            var partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);

            foreach (var part in partFactory.GetApplicationParts(assembly))
            {
                mvcBuilder.PartManager.ApplicationParts.Add(part);
            }

            var relatedAssemblies = RelatedAssemblyAttribute.GetRelatedAssemblies(assembly, false);
            foreach (var relatedAssembly in relatedAssemblies)
            {
                partFactory = ApplicationPartFactory.GetApplicationPartFactory(relatedAssembly);
                foreach (var part in partFactory.GetApplicationParts(relatedAssembly))
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }
            }
        }
    }
}