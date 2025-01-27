using ProyectoP3.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoP3.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Auto>().Wait();
            _database.CreateTableAsync<Transaction>().Wait();
        }

        public Task<List<Usuario>> GetVendedoresAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        public Task<int> SaveVendedorAsync(Usuario vendedor)
        {
            if (vendedor.IdUsuario != 0)
                return _database.UpdateAsync(vendedor);
            else
                return _database.InsertAsync(vendedor);
        }

        public Task<int> DeleteVendedorAsync(Usuario vendedor)
        {
            return _database.DeleteAsync(vendedor);
        }

        public Task<List<Auto>> GetAutosAsync()
        {
            return _database.Table<Auto>().ToListAsync();
        }

        public Task<int> SaveAutoAsync(Auto auto)
        {
            if (auto.IdAuto != 0)
                return _database.UpdateAsync(auto);
            else
                return _database.InsertAsync(auto);
        }

        public Task<int> DeleteAutoAsync(Auto auto)
        {
            return _database.DeleteAsync(auto);
        }

        public Task<List<Transaction>> GetTransactionsAsync()
        {
            return _database.Table<Transaction>().ToListAsync();
        }

        public Task<int> SaveTransactionAsync(Transaction transaction)
        {
            return _database.InsertAsync(transaction);
        }
    }
}
