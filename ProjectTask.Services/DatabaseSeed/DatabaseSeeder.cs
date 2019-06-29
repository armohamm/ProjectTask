using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.DatabaseSeed
{
    public class DatabaseSeeder : ISeed, IDisposable
    {
        private IUnitOfWork UnitOfWork { get; }
        private bool _disposed = false;


        public DatabaseSeeder(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        ~DatabaseSeeder()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool d)
        {
            if (_disposed)
                return;
            if (d)
            {
                _disposed = true;
                UnitOfWork.Dispose();
            }
        }


        public async Task SeedAsync()
        {
            await new DatabaseMigrator(UnitOfWork).SeedAsync();

            await new DataSeeder(UnitOfWork).SeedAsync();
        }


    }
}
