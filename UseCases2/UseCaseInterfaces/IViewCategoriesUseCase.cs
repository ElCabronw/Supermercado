using System.Collections.Generic;
using CoreBusiness;

namespace UseCases
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}