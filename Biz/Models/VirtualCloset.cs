namespace VirtualClosetAPI.Biz.Models
{
    public class VirtualCloset
    {
        internal string name;

        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Favorite { get; set; }


        public VirtualCloset(string name, string category, bool favorite)
        {
            Name = name;
            Category = category;
            Favorite = favorite;
        }

        public VirtualCloset(long id, string name, string category, bool favorite)
        {
            Id = id;
            Name = name;
            Category = category;
            Favorite = favorite;
        }
        public VirtualCloset()
        {

        }
    }
}