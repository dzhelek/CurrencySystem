using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencySystem.Models
{
    public class ProductRepository
    {
        string _dbPath;
        SQLiteAsyncConnection db;
        public async Task Init()
        {
            if (db != null)
                return;
            db = new SQLiteAsyncConnection(_dbPath);
            await db.CreateTableAsync<Product>();
        }

        public ProductRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            await Init();
            return await db.Table<Product>().ToListAsync();
        }
        public async Task<Product> GetProductAsync(int id)
        {
            await Init();
            return await db.Table<Product>().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<int> SaveProductAsync(Product product)
        {
            await Init();
            if (product.Id != 0)
            {
                return await db.UpdateAsync(product);
            }
            else
            {
                return await db.InsertAsync(product);
            }
        }
        public async Task<int> DeleteProductAsync(Product product)
        {
            await Init();
            return await db.DeleteAsync(product);
        }
    }
}
