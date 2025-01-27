using ProyectoP3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP3.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            // Crear tablas para Usuario y Auto
            _database.CreateTableAsync<Usuario>().Wait();
            _database.CreateTableAsync<Auto>().Wait();
        }

        // Métodos para Usuarios
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

        // Métodos para Autos
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
    }
}