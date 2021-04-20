using System;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Controllers.Contracts;

namespace VirtualClosetAPI.Controllers.Extensions
{
    /// <summary>
    /// Extenstion methods for <see cref="Account"/>.
    /// </summary>
    public static class TodoItemExtensions
    {
        /// <summary>
        /// Converts a <see cref="Account"/> to a <see cref="AccountResponse"/>.
        /// </summary>
        public static VirtualClosetResponse ToResponse(this VirtualCloset model)
        {
            return new VirtualClosetResponse (model.Id, model.Name, model.Category, model.Favorite);
        }
    }
}