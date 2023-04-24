using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.DOMAIN.Entities;

namespace TrueOnion.APPLICATION.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task SaveAsync();
        void Save();
    }
}
