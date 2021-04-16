﻿using System;
using Microsoft.EntityFrameworkCore;

namespace VirtualClosetAPI.Models
{
        public class VirtualClosetContext : DbContext
        {
            public VirtualClosetContext(DbContextOptions<VirtualClosetContext> options)
                : base(options)
            {
            }

            public DbSet<VirtualCloset> VirtualClosetItems { get; set; }
        }
    }