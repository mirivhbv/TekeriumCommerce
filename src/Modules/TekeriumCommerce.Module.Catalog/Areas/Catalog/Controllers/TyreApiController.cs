using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TekeriumCommerce.Infrastructure.Data;
using TekeriumCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using TekeriumCommerce.Module.Catalog.Models;

namespace TekeriumCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin")]
    [Route("api/tyres")]
    public class TyreApiController : Controller
    {
        private readonly IRepository<TyreRimSize> _tyreRimSizeRepository;
        private readonly IRepository<TyreWidth> _tyreWidthRepository;
        private readonly IRepository<TyreProfile> _tyreProfileRepository;
        private readonly IRepository<TyreWidthProfileRimSize> _commonTyreRepository;

        public TyreApiController(
            IRepository<TyreRimSize> tyreRimSizeRepository,
            IRepository<TyreWidth> tyreWidthRepository,
            IRepository<TyreProfile> tyreProfileRepository,
            IRepository<TyreWidthProfileRimSize> commonTyreRepository)
        {
            _tyreRimSizeRepository = tyreRimSizeRepository;
            _tyreWidthRepository = tyreWidthRepository;
            _tyreProfileRepository = tyreProfileRepository;
            _commonTyreRepository = commonTyreRepository;
        }

        public async Task<IActionResult> Get()
        {
            var widthList = await _tyreWidthRepository.Query()
                .Select(p => new TyreForm
                {
                    Id = p.Id,
                    Size = p.Size,
                    Profiles = p.TyreWidthProfileRimSizes.Select(c => new TyreProfileVm
                    {
                        Id = c.TyreProfile.Id,
                        Size = c.TyreProfile.Size,
                    }).Distinct().ToList()
                }).ToListAsync();

            // Include(x => x.TyreWidthProfileRimSizes).ThenInclude(x => x.TyreProfile).Distinct().ToListAsync();

            foreach (var tyreForm in widthList)
            {
                if (tyreForm != null)
                {
                    foreach (var pr in tyreForm.Profiles)
                    {
                        pr.RimSizes = MapMatchingRimSizes(tyreForm.Id, pr.Id);
                    }
                }
            }

            return Json(widthList);
        }

        [HttpGet("profiles")]
        public async Task<IActionResult> GetProfiles()
        {
            var profiles = await _tyreProfileRepository.Query().ToListAsync();

            return Json(profiles);
        }

        [HttpGet("rimsizes")]
        public async Task<IActionResult> GetRimSizes()
        {
            var rimsizes = await _tyreRimSizeRepository.Query().ToListAsync();

            return Json(rimsizes);
        }

        [HttpGet("widths")]
        public async Task<IActionResult> GetWidths()
        {
            var widths = await _tyreWidthRepository.Query().ToListAsync();

            return Json(widths);
        }

        [HttpPost("add/{width}/{profile}/{rim}")]
        public async Task<IActionResult> AddAll(long width, long profile, long rim)
        {
            // done ! todo:
            // 1st. check width, profile and rim is available in db, else return error
            // 2nd. check current selected options is available in db or not. yes => return error . no => add (create new tyrewidthprofile)

            var check = await _commonTyreRepository.Query().FirstOrDefaultAsync(x =>
                x.TyreWidthId == width && x.TyreProfileId == profile && x.TyreRimSizeId == rim);

            if (check != null)
                return BadRequest(new {message = "Selected profile and width already is in width."});

            // get all shits:
            var w = await _tyreWidthRepository.Query().FirstOrDefaultAsync(x => x.Id == width);
            var p = await _tyreProfileRepository.Query().FirstOrDefaultAsync(x => x.Id == profile);
            var r = await _tyreRimSizeRepository.Query().FirstOrDefaultAsync(x => x.Id == rim);

            if (w is null || p is null || r is null)
            {
                return BadRequest(new {message = "There is not that type of sizes."});
            }

            var twpr = new TyreWidthProfileRimSize
            {
                TyreWidth = w,
                TyreProfile = p,
                TyreRimSize = r
            };

            // todo: it is best to move to service layer... later
            using (var transaction = _commonTyreRepository.BeginTransaction())
            {
                _commonTyreRepository.Add(twpr);
                await _commonTyreRepository.SaveChangesAsync();

                transaction.Commit();
            }

            return Ok();
        }

        [HttpDelete("profile")]
        public async Task<IActionResult> RemoveProfile([FromBody] RemoveSelectedProfile id)
        {
            var widthId = id.WidthId;
            var profileId = id.ProfileId;

            var all = await _commonTyreRepository.Query()
                .Where(x => x.TyreProfileId == profileId && x.TyreWidthId == widthId).ToListAsync();

            foreach (var t in all)
            {
                _commonTyreRepository.Remove(t);
            }

            await _commonTyreRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("width")]
        public async Task<IActionResult> RemoveWidth(long id)
        {
            var all = await _commonTyreRepository.Query().Where(x => x.TyreWidthId == id).ToListAsync();

            foreach (var w in all)
            {
                _commonTyreRepository.Remove(w);
            }

            await _commonTyreRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("rimsize")]
        public async Task<IActionResult> RemoveRimSize([FromBody] RemoveSelectedRimSize rim)
        {
            var widthId = rim.WidthId;
            var profileId = rim.ProfileId;
            var rimSizeId = rim.RimSizeId;

            var all = await _commonTyreRepository.Query()
                .Where(x => x.TyreProfileId == profileId && x.TyreWidthId == widthId && x.TyreRimSizeId == rimSizeId).ToListAsync();

            if (all?.Count > 0) // actually there is one record
            {
                foreach (var size in all)
                {
                    _commonTyreRepository.Remove(size);
                }
            }

            await _commonTyreRepository.SaveChangesAsync();

            return NoContent();
        }

        private IEnumerable<TyreRimSizeVm> MapMatchingRimSizes(long widthId, long profileId)
        {
            var rims = this._tyreRimSizeRepository.Query()
                .Include(x => x.TyreWidthProfileRimSizes).ThenInclude(a => a.TyreProfile)
                .Include(x => x.TyreWidthProfileRimSizes).ThenInclude(a => a.TyreWidth).ToList();

            var specificRims = (from c in rims
                                from m in c.TyreWidthProfileRimSizes
                                where m.TyreProfile.Id == profileId && m.TyreWidth.Id == widthId
                                select m.TyreRimSize).Distinct().Select(x => new TyreRimSizeVm { Id = x.Id, Size = x.Size });

            return specificRims;
        }
    }
}