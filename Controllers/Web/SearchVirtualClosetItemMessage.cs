using System;
namespace VirtualClosetAPI.Controllers.Web
{
    public class SearchVirtualClosetItemMessage
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Favorite { get; set; }
    }
}