using System;
using VirtualClosetAPI.Biz.Models;
using VirtualClosetAPI.Models;

namespace VirtualClosetAPI.Data.Extensions
{
    /// <summary>
    /// Extenstion methods for <see cref="ClientEntity"/>.
    /// </summary>
    public static class VirtualClosetEntityExtensions
    {
        /// <summary>
        /// Converts a <see cref="ClientEntity"/> to a <see cref="Client"/> model.
        /// </summary>
        public static VirtualCloset ToModel(this VirtualClosetEntity entity)
        {
            return new VirtualCloset(
                entity.Id,
                entity.Name,
                entity.Category,
                entity.Favorite);
        }
    }
}
