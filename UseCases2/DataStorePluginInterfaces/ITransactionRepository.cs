using System;
using System.Collections.Generic;
using CoreBusiness;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Get(string cashierName);
        IEnumerable<Transaction> GetByDay(string cashierName,DateTime date);
        void Save(string cashierName, int productId, double price, int beforeQty,int soldQty);
    }
}
