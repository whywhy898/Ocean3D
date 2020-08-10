using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Domain.Core.SeedWork
{
   public interface ITransaction
    {
        IDbContextTransaction GetCurrentTransaction();

        bool HasActiveTransaction { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync(IDbContextTransaction transaction);

        void RollBackTransaction();

    }
}
