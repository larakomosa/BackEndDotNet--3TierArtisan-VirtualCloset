using System;
namespace VirtualClosetAPI.Models
{
    public class VirtualClosetEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Favorite { get; set; }
    }
}
