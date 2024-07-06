
using Microsoft.EntityFrameworkCore;
using StoreBackendQL.Essentials;
using StoreBackendQL.Models;
using HotChocolate;
using System;

namespace StoreBackendQL.GraphQL.Queries
{
    public class ProductQuery
    {
        public IQueryable<Products> GetProducts([ScopedService] StoreDbContext context)
        {
            return context.Products;
        }

        public Products GetProduct(int id, [ScopedService] StoreDbContext context)
        {
            return context.Products.Find(id);
        }
    }
}
