using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Controllers;

namespace VirtualClosetAPI.Biz.Impl
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Get a set clients
        /// </summary>
        /// <returns>Get all categories.</returns>
        Task<IEnumerable<Category>> Get();
        /// <summary>
        /// Get a set category by their unique identifiers.
        /// </summary>
        /// <returns>The requested category.</returns>
        Task<IEnumerable<Category>> Get(IEnumerable<long> categoryIds);
        /// <summary>
        /// create a category
        /// </summary>
        /// <param name="info">The category info to be added to table.</param>
        /// <returns>OK.</returns>
        Task<Category> Create(CreateCategoryItemInfo info);
        /// <summary>
        /// update a category
        /// </summary>
        /// <param name="info">The category info to be updated on table.</param>
        /// <returns>OK.</returns>
        Task<Category> Update(long id, UpdateCategoryItemInfo info);
        /// <summary>
        /// delete a category
        /// </summary>
        /// <param name="id">The category to be deleted from the table.</param>
        /// <returns>OK</returns>
        Task<Category> Delete(long id);
    }
}