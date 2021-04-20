using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Models;
using VirtualClosetAPI.Controllers.Contracts;
using VirtualClosetAPI.Controllers.Web;
using System.Linq;
using VirtualClosetAPI.Biz.Impl;
using System.Collections.Generic;

namespace VirtualClosetAPI.Data.Impl
{
    public class VirtualClosetDao : IVirtualClosetDao
    {
        private readonly VirtualClosetContext closetContext;

        public VirtualClosetDao(VirtualClosetContext closetContext)
        {
            this.closetContext = closetContext;
        }

        async public Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info)
        {
            var item = new VirtualCloset(info.Name, info.Category, info.Favorite);

            closetContext.VirtualClosetItems.Add(item);
            await closetContext.SaveChangesAsync();

            return item;

        }

        async public Task<VirtualCloset> Update(long id, UpdateVirtualClosetItemInfo info)

        {
            var change = await closetContext.VirtualClosetItems
                .FirstAsync(i => i.Id == id);

            change.Name = info.Name;
            change.Category = info.Category;
            change.
                Favorite= info.Favorite;

            await closetContext.SaveChangesAsync();

            return change;

        }
        async public Task<VirtualCloset> Delete(long id)
        {
            var item = await closetContext.VirtualClosetItems.FindAsync(id);
            closetContext.VirtualClosetItems.Remove(item);

            await closetContext.SaveChangesAsync();

            return item;
        }

        public async Task<SearchResponse<VirtualCloset>> Search(SearchVirtualClosetItemInfo info)
        {
            var query = closetContext.VirtualClosetItems
            .Where(c => c.Name.StartsWith((string)info.Name))
            .AsQueryable()
            .AsNoTracking();

            int count = await query.CountAsync();
            List<VirtualCloset> results = await query
                .OrderBy(c => c.Id)
                .ToListAsync();

            return new SearchResponse<VirtualCloset>(results, count);

        }

    }
}