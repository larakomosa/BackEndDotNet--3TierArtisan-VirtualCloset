using System;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers;

namespace VirtualClosetAPI.Data
{
        internal interface IVirtualClosetDao
        {
            Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info);
        }
    }