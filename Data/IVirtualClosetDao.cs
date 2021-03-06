using System;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Impl;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Controllers.Web;

namespace VirtualClosetAPI.Data
{
        internal interface IVirtualClosetDao
        {
        Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info);
        Task<VirtualCloset> Update(long id, UpdateVirtualClosetItemInfo info);
        Task<VirtualCloset> Delete(long id);
        Task<SearchResponse<VirtualCloset>> Search(SearchVirtualClosetItemInfo info);


    }
}