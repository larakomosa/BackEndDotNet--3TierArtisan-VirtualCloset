using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApplicationAPI.Controllers;
using VirtualClosetAPI.Biz.Models;

namespace VirtualClosetAPI.Biz.Impl
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="closetIds">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<IEnumerable<Category>> Get();
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="closetIds">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<IEnumerable<Category>> Get(IEnumerable<long> categoryIds);
        /// <summary>
        /// Get a set clients by their unique identifiers.
        /// </summary>
        /// <param name="info">The unique identifiers of the clients to get.</param>
        /// <returns>The requested clients.</returns>
        Task<Category> Create(CreateCategoryItemInfo info);
        Task<Category> Update(long id, UpdateCategoryItemInfo info);
        Task<Category> Delete(long id);
    }
}