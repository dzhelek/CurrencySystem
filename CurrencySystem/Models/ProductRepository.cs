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

        // public async Task<Money<TTargetCurrency>> GetTotalValueAsync<TTargetCurrency>() where TTargetCurrency : ICurrency
        // {
        //     var products = await GetAllProductsAsync();
        //     decimal totalInEur = 0;

        //     foreach (var product in products)
        //     {
        //         var parts = product.StoredMoneyValue.Split('|');
        //         if (parts.Length != 2 || !decimal.TryParse(parts[0], out decimal amount))
        //         {
        //             throw new ArgumentException($"Invalid money value format in product {product.Id}: {product.StoredMoneyValue}");
        //         }

        //         var money = CurrencyFactory.CreateMoney(amount, parts[1]);
        //         if (typeof(TTargetCurrency) == typeof(EUR))
        //         {
        //             if (money is Money<EUR> eurMoney)
        //             {
        //                 totalInEur += eurMoney.Amount;
        //             }
        //             else
        //             {
        //                 var converted = money.ConvertTo<EUR>();
        //                 totalInEur += converted.Amount;
        //             }
        //         }
        //     }

        //     if (typeof(TTargetCurrency) == typeof(EUR))
        //     {
        //         return new Money<TTargetCurrency>(totalInEur) as Money<TTargetCurrency>;
        //     }
            
        //     return new Money<EUR>(totalInEur).ConvertTo<TTargetCurrency>();
        // }
    }
}
