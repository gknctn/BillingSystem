﻿using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        List<Category> GetAll();
        Category GetById(int id);
        IQueryable<Category> GetAllCategoriesWithProduct(int id);

    }
}
