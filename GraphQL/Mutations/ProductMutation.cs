
using Microsoft.EntityFrameworkCore;
using StoreBackendQL.Essentials;
using StoreBackendQL.Models;
using System;

namespace StoreBackendQL.GraphQL.Mutations
{
    public class ProductMutation 
    {

        public async Task<Products> CreateProductAsync(Products product, [ScopedService] StoreDbContext context)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> UpdateProductAsync(int id, Products inputProduct, [ScopedService] StoreDbContext context)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                throw new GraphQLException(new Error("Product not found", "NOT_FOUND"));
            }

            product.Name = inputProduct.Name;
            product.Price = inputProduct.Price;

            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Products> DeleteProductAsync(int id, [ScopedService] StoreDbContext context)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                throw new GraphQLException(new Error("Product not found", "NOT_FOUND"));
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return product;
        }
    }
}
