using System;
using System.Threading.Tasks;
using VirtualClosetAPI.Controllers;
using VirtualClosetAPI.Biz.Models;

namespace VirtualClosetAPI.Data.Impl
{
    internal interface ICategoryDao
    {
        Task<Category> Create(CreateCategoryItemInfo info);
        Task<Category> Update(long id, UpdateCategoryItemInfo info);
        Task<Category> Delete(long id);

    }
}