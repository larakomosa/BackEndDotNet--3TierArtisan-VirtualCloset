using System;
namespace VirtualClosetAPI.Common
{
    public class CreateVirtualClosetItemInfo
    {
        public string Name;
        public string Category;
        public bool Favorite;

        public CreateVirtualClosetItemInfo(string name, string category, bool favorite)
        {
            this.Name = name;
            this.Category = category;
            this.Favorite = favorite;
        }
    }
}
