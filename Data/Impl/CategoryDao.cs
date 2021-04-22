using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApplicationAPI.Controllers;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Models;

namespace VirtualClosetAPI.Data.Impl
{
    public class CategoryDao:  ICategoryDao
    {
        private readonly VirtualClosetContext closetContext;

        public CategoryDao(VirtualClosetContext closetContext)
        {
            this.closetContext = closetContext;
        }

        async public Task<Category> Create(CreateCategoryItemInfo info)
        {
            var item = new Category(info.Name);

            closetContext.Categories.Add(item);
            await closetContext.SaveChangesAsync();

            return item;

        }
        async public Task<Category> Update(long id, UpdateCategoryItemInfo info)

        {
            var change = await closetContext.Categories
                .FirstAsync(i => i.Id == id);

            change.Name = info.Name;
            await closetContext.SaveChangesAsync();

            return change;

        }
        async public Task<Category> Delete(long id)
        {
            var item = await closetContext.Categories.FindAsync(id);
            closetContext.Categories.Remove(item);

            await closetContext.SaveChangesAsync();

            return item;
        }
    }
}


