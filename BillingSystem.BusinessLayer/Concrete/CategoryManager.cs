﻿using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.DataAccessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public IQueryable<Category> GetAllCategoriesWithProduct(int id)
        {
            return _categoryDal.GetAllCategoriesWithProduct(id);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
