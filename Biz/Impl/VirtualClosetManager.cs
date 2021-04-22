using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Data;
using VirtualClosetAPI.Data.Impl;
using VirtualClosetAPI.Models;
using VirtualClosetAPI.Controllers.Contracts;
using VirtualClosetAPI.Controllers.Web;
using Artisan.Core.Exceptions;
using IVirtualClosetDao = VirtualClosetAPI.Data.IVirtualClosetDao;

namespace VirtualClosetAPI.Biz.Impl
{
    internal class VirtualClosetManager : IVirtualClosetManager
    {
        private readonly VirtualClosetContext closetContext;
        private readonly IVirtualClosetDao virtualClosetDao;

        public VirtualClosetManager(VirtualClosetContext closetContext, IVirtualClosetDao virtualClosetDao)
        {
            this.closetContext = closetContext;
            this.virtualClosetDao = virtualClosetDao;
        }

        public async Task<IEnumerable<VirtualCloset>> Get(IEnumerable<long> closetIds)
        {

            return await closetContext.VirtualClosetItems
                .Where(item => closetIds.Contains(item.Id))
                .Select(item => new VirtualCloset { Id = item.Id, Name = item.Name, Category = item.Category, Favorite = item.Favorite })
                .ToListAsync();
        }

        public async Task<IEnumerable<VirtualCloset>> Get()
        {

            return await closetContext.VirtualClosetItems
                .Select(item => new VirtualCloset { Id = item.Id, Name = item.Name, Category = item.Category, Favorite = item.Favorite })
                .ToListAsync();
        }

        public async Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info)
        {

            return await virtualClosetDao.Create(info);
        }

        public async Task<VirtualCloset> Update(long id, UpdateVirtualClosetItemInfo info)
        {
            return await virtualClosetDao.Update(id, info);
        }

        public async Task<VirtualCloset> Delete(long id)
        {
            return await virtualClosetDao.Delete(id);
        }

        public async Task<SearchResponse<VirtualCloset>> Search(SearchVirtualClosetItemInfo info)
        {
            Verify.That(info, nameof(info)).IsNotNull();

            return await virtualClosetDao.Search(info);
        }

    }
}
