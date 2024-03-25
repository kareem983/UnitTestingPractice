using Core.Abstractions;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;

        public ProductService(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductList()
        {
            try
            {
                return await _dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                var result = await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var SearchedProduct = await _dbContext.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
                if (SearchedProduct == null) return null;

                _dbContext.Entry(SearchedProduct).CurrentValues.SetValues(product);
                await _dbContext.SaveChangesAsync();

                return SearchedProduct;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            try
            {
                var product = await _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefaultAsync();
                if (product == null) return false;

                var result = _dbContext.Entry(product).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();

                return (result == null) ? false : true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }
    }
}
