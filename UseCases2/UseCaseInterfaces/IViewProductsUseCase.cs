﻿using System.Collections.Generic;
using CoreBusiness;

namespace UseCases
{
    public interface IViewProductsUseCase
    {
        IEnumerable<Product> Execute();
    }
}