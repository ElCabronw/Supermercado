using System;
using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory2
{
    public class TransactionInMemoryRepository : ITransactionRepository
    {
        private List<Transaction> transactions;
        public TransactionInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Get(string cashierName)
        {
            if(string.IsNullOrWhiteSpace(cashierName))
            return transactions;

            return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));


        }

        public IEnumerable<Transaction> GetByDay(string cashierName,DateTime date)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp.Date == date.Date);

            return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) && x.TimeStamp.Date == date.Date);




           
        }

        public void Save(string cashierName,int productId,string productName, double price,int beforeQty, int soldQty)
        {
            int transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                int maxId = transactions.Max(x => x.TransactionId);
                transactionId = maxId + 1;
            }
            else
            {
                transactionId = 1;
            }


            transactions.Add(new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                SoldQty = soldQty,
                BeforeQty = beforeQty,
                TimeStamp = DateTime.Now,
                TransactionId = transactionId,
                CashierName = cashierName
            });
        }

        public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
                return transactions.Where(x => x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);

            return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase) &&
            x.TimeStamp >= startDate.Date && x.TimeStamp <= endDate.Date.AddDays(1).Date);
        }
    }
}
