using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.EFCore.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.EFCore.Services
{
    public class AccountDataService : IDataService<Account>
    {
        private readonly SimpleTraderAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(SimpleTraderAppDbContextFactory dbContextFactory)
        {
            _contextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(_contextFactory);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<Account> Get(int id)
        {
            using (SimpleTraderAppDbContext traderAppDbContext = _contextFactory.CreateDbContext())
            {
                Account entity = await traderAppDbContext.Accounts.Include(a =>a.AssetTrasactions).FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (SimpleTraderAppDbContext traderAppDbContext = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entity = await traderAppDbContext.Accounts.Include(a => a.AssetTrasactions).ToListAsync();
                return entity;
            }
        }
    }
}
