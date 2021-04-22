using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Impl;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Common;
using VirtualClosetAPI.Controllers.Web;

namespace VirtualClosetAPI.Controllers
{

    /// <summary>
    /// Biz manager for Items.
    /// </summary>
    public interface IVirtualClosetManager
    {
        /// <summary>
        /// Get a closet item by it's unique identifier.
        /// </summary>
        /// <param name="closetIds">The unique identifiers of the clients to get.</param>
        /// <returns>The requested closet item.</returns>
        Task<IEnumerable<VirtualCloset>> Get(IEnumerable<long> closetIds);
        /// <summary>
        /// Get all closet items
        /// </summary>
        /// <returns>The requested closet items.</returns>
        Task<IEnumerable<VirtualCloset>> Get();
        /// <summary>
        /// Create a closet item 
        /// </summary>
        /// <param name="info">The category info to be added to table.</param>
        /// <returns>OK</returns>
        Task<VirtualCloset> Create(CreateVirtualClosetItemInfo info);
        /// <summary>
        /// Get a set closet items by their unique identifiers.
        /// </summary>
        /// <param name="info">The unique identifiers of the closet item to update.</param>
        /// <returns>OK.</returns>
        Task<VirtualCloset> Update(long id, UpdateVirtualClosetItemInfo info);
        /// <summary>
        /// Delete a closet item by their unique identifiers.
        /// </summary>
        /// <param name="id">The unique identifiers of the closet item to delete.</param>
        /// <returns>OK</returns>
        Task<VirtualCloset> Delete(long id);
        /// <summary>
        /// Search for an Item
        /// </summary>
        Task<SearchResponse<VirtualCloset>> Search(SearchVirtualClosetItemInfo info);
    }
}