using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;

namespace VirtualClosetAPI.Controllers
{

    /// <summary>
    /// Biz manager for Items.
    /// </summary>
    public interface IVirtualClosetManager
    {
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="closetIds">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<IEnumerable<VirtualCloset>> Get(IEnumerable<long> closetIds);
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <returns>The requested clients.</returns>
        Task<IEnumerable<VirtualCloset>> Get();
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="info">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info);
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="info">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<VirtualCloset> Update(long id, UpdateVirtualClosetItemInfo info);
    }
}