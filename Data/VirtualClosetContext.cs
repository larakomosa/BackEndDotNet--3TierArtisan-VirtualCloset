using System;
using Microsoft.EntityFrameworkCore;
using VirtualClosetAPI.Biz.Models;

namespace VirtualClosetAPI.Models
{
        public class VirtualClosetContext : DbContext
        {
            public VirtualClosetContext(DbContextOptions<VirtualClosetContext> options)
                : base(options)
            {
            }
        /// <summary>
        /// Database collection for Closet Items
        /// </summary>
        public DbSet<VirtualCloset> VirtualClosetItems { get; set; }

        /// <summary>
        /// Database collection for client payments.
        /// </summary>
        public DbSet<Category> Categories { get; set; }
    }
}