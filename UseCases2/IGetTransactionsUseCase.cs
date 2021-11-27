using System;
using System.Collections.Generic;
using CoreBusiness;

namespace UseCases
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}