﻿using CatalogDb.API.Entities;

namespace CatalogDb.API.Pagination.Filters.Products
{
    public sealed class ProductExactPriceFilter : BaseFilter<Product>
    {
        public decimal? Price { get; set; }

        public override IQueryable<Product> HandleFilter(IQueryable<Product> filter)
        {
            if (Price.HasValue)
            {
                filter = filter.Where(p => p.Price == Price.Value);
            }

            return filter;
        }
    }
}
