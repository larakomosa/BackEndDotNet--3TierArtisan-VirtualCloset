using System;
namespace VirtualClosetAPI.Controllers.Web
{
    public class SearchVirtualClosetItemInfo
    {
        public long Id;
        public string Name;
        public string Category;
        public bool? Favorite;

        public SearchVirtualClosetItemInfo(long id, string name, string category, bool? favorite)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Favorite = favorite;
        }
    }
}