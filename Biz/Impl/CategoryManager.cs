using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Models;

namespace VirtualClosetAPI.Biz.Impl
{
    internal class CategoryManager : ICategoryManager
    {
        private readonly VirtualClosetContext closetContext;

        public CategoryManager(VirtualClosetContext closetContext)
        {
            this.closetContext = closetContext;
        }

        public async Task<IEnumerable<Category>> Get()
        {

            return await closetContext.Categories
                .Select(item => new Category { Id = item.Id, Name = item.Name })
                .ToListAsync();
        }
    }
}
