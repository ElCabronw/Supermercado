using System.Collections.Generic;
using CoreBusiness;

namespace UseCases
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}