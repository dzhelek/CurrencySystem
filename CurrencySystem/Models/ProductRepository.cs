using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    public class ProductRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public ProductRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>().Wait();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _database.Table<Product>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            if (product.Id != 0)
            {
                return await _database.UpdateAsync(product);
            }
            return await _database.InsertAsync(product);
        }

        public async Task<int> DeleteProductAsync(Product product)
        {
            return await _database.DeleteAsync(product);
        }

    }
}
