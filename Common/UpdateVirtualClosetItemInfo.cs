namespace VirtualClosetAPI.Controllers
{
    public class UpdateVirtualClosetItemInfo
    {
        public string Name;
        public string Category;
        public bool Favorite;

        public UpdateVirtualClosetItemInfo(string name, string category, bool favorite)
        {
            this.Name = name;
            this.Category = category;
            this.Favorite = favorite;
        }
    }
}