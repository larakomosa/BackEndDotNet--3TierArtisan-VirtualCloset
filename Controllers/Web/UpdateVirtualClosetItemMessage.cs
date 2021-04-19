namespace VirtualClosetAPI.Controllers
{
    public class UpdateVirtualClosetItemMessage
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Favorite { get; set; }
    }
}