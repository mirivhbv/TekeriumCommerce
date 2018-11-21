set identity_insert [dbo].[Catalog_Category] on
insert [dbo].[Catalog_Category] ([Id], [Name], [Slug], [MetaTitle], [MetaKeywords], [MetaDescription], [Description], [DisplayOrder], [IsPublished], [IncludeInMenu], [IsDeleted], [ParentId], [ThumbnailImageId]) VALUES (1, N'car', N'car', NULL, NULL, NULL, NULL, 0, 1, 1, 0, NULL, NULL)
insert [dbo].[Catalog_Category] ([Id], [Name], [Slug], [MetaTitle], [MetaKeywords], [MetaDescription], [Description], [DisplayOrder], [IsPublished], [IncludeInMenu], [IsDeleted], [ParentId], [ThumbnailImageId]) VALUES (2, N'4x4', N'4x4', NULL, NULL, NULL, NULL, 0, 1, 1, 0, NULL, NULL)
set identity_insert [dbo].[Catalog_Category] off

set identity_insert [dbo].[Catalog_Brand] on
INSERT [dbo].[Catalog_Brand] ([Id], [Name], [Slug], [Description], [IsPublished], [IsDeleted]) VALUES (1, N'Bridgestone', N'bridgestone', NULL, 1, 0)
INSERT [dbo].[Catalog_Brand] ([Id], [Name], [Slug], [Description], [IsPublished], [IsDeleted]) VALUES (2, N'lassa', N'lassa', NULL, 1, 0)
set identity_insert [dbo].[Catalog_Brand] off


set identity_insert [dbo].[Catalog_Product] on
INSERT [dbo].[Catalog_Product] ([Id], [Name], [Slug], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedById], [CreatedOn], [UpdatedOn],
[UpdatedById], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [SpecialPrice], [SpecialPriceStart], [SpecialPriceEnd],  [StockQuantity],
[NormalizedName], [DisplayOrder], [ThumbnailImageId], [BrandId]) 
VALUES (1, N'Lightweight Jacket', N'lightweight-jacket', NULL, NULL, NULL, 1, NULL, 0, 10, CAST(N'2018-08-11T15:02:17.0131910+07:00' AS DateTimeOffset), 
CAST(N'2018-08-11T15:02:17.0133446+07:00' AS DateTimeOffset), 10, 
N'<p>Nulla eget sem vitae eros pharetra viverra. Nam vitae luctus ligula. Mauris consequat ornare feugiat.<br></p>', N'<p>Aenean sit amet gravida nisi. Nam fermentum est felis, quis feugiat nunc fringilla sit amet. Ut in blandit ipsum. Quisque luctus dui at ante aliquet, in hendrerit lectus interdum. Morbi elementum sapien rhoncus pretium maximus. Nulla lectus enim, cursus et elementum sed, sodales vitae eros. Ut ex quam, porta consequat interdum in, faucibus eu velit. Quisque rhoncus ex ac libero varius molestie. Aenean tempor sit amet orci nec iaculis. Cras sit amet nulla libero. Curabitur dignissim, nunc nec laoreet consequat, purus nunc porta lacus, vel efficitur tellus augue in ipsum. Cras in arcu sed metus rutrum iaculis. Nulla non tempor erat. Duis in egestas nunc.<br></p>', 
NULL, CAST(58.79 AS Decimal(18, 2)), 
CAST(69.00 AS Decimal(18, 2)), NULL, NULL, NULL, 0,  NULL, 0, 1, 2)
set identity_insert [dbo].[Catalog_Product] off
