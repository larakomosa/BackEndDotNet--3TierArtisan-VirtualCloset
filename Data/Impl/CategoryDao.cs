using System;
using System.Threading.Tasks;
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
    }
}


