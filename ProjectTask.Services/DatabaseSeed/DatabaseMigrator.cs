using ProjectTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.Services.DatabaseSeed
{
    public sealed class DatabaseMigrator : ISeed
    {
        private readonly IUnitOfWork _context;

        public DatabaseMigrator(IUnitOfWork context)
        {
            _context = context;
        }


        public async Task SeedAsync()
        {
            await _context.MigrateDatabaseAsync();
            await _context.CommitAsync().ConfigureAwait(false);
        }
    }
}
