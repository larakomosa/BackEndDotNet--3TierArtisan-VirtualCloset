using System;
using System.ComponentModel.DataAnnotations;
using Artisan.Core.Exceptions;
using Artisan.Service.Core.Web;
namespace VirtualClosetAPI.Controllers.Contracts
{
    [FieldNamespace("virtualcloset")]
    public class VirtualClosetResponse
    {
        /// <summary>
        /// Standard constructor.
        /// </summary>
        public VirtualClosetResponse(long id, string name, string category, bool favorite)
        {
            Verify.That(id, nameof(id)).IsGreaterThanOrEqualTo(0);
            Verify.That(name, nameof(name)).IsNotNullOrEmpty();
            Verify.That(category, nameof(category)).IsNotNullOrEmpty();

            Id = Id;
            Name = name;
            Category = category;
            Favorite = favorite;
        }

        /// <summary>
        /// unique identifier of closet item
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// The name of the closet item.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The category of the closet item.
        /// </summary>
        [Required]
        public string Category { get; set; }

        /// <summary>
        /// Weather or not the item is a favorite.
        /// </summary>
        public bool Favorite { get; set; }
    }
}

