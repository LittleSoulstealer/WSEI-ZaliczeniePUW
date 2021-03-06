﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zaliczenie.Models.Sqlite;

namespace Zaliczenie.Data
{
    public class LocalDB
    {
        readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Products>().Wait();
        }
        public async Task<List<T>> GetAllGeneric<T>() where T : class, ISqliteModel, new()
        {
            return await database.Table<T>().ToListAsync();
        }
        public async Task<int> SaveGeneric<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }
        public async Task<int> DeleteGeneric<T>(T item)
        {
            var result = await database.DeleteAsync(item);
            return result;
        }

        internal async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }
   
        internal async Task<Products> GetProductbyID(int id)
        {
            return await database.Table<Products>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }
        public async Task<int> SaveItemAsync<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }
        public async Task<int> DeleteItemAsync<T>(T item)
        {
            return await database.DeleteAsync(item);
        }

    }
}
