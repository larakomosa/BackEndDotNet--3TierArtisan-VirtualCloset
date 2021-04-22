using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Data.Impl;
using VirtualClosetAPI.Models;

namespace VirtualClosetAPI.Biz.Impl
{
    internal class CategoryManager : ICategoryManager
    {
        private readonly VirtualClosetContext closetContext;
        private readonly CategoryDao categoryDao;

        public CategoryManager(VirtualClosetContext closetContext, CategoryDao categoryDao)
        {
            this.closetContext = closetContext;
            this.categoryDao = categoryDao;
            
        }

        public async Task<IEnumerable<Category>> Get()
        {

            return await closetContext.Categories
                .Select(item => new Category { Id = item.Id, Name = item.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> Get(IEnumerable<long> closetIds)
        {

            return await closetContext.Categories
                .Where(item => closetIds.Contains(item.Id))
                .Select(item => new Category { Id = item.Id, Name = item.Name})
                .ToListAsync();
        }

        public async Task<Category>Create(CreateCategoryItemInfo info)
        {

            return await categoryDao.Create(info);
        }

        public async Task<Category> Update(long id, UpdateCategoryItemInfo info)
        {
            return await categoryDao.Update(id, info);
        }

        public async Task<Category> Delete(long id)
        {
            return await categoryDao.Delete(id);
        }
    }
}
