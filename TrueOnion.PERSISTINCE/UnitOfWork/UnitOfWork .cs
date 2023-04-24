using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.PERSISTINCE.Context;
using TrueOnion.PERSISTINCE.Repositories.EntityFramework;

namespace TrueOnion.PERSISTINCE.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _appDbContext;
        private IDbContextTransaction _transaction;

        public EFUnitOfWork(EFDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateTransaction()
        {
            _transaction = _appDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
        public void Save()
        {
            _appDbContext.SaveChanges();
        }


        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }

}