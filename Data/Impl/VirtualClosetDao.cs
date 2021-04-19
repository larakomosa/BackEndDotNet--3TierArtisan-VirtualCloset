﻿using System;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Models;

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
    }
}