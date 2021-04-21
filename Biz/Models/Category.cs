using System;
namespace VirtualClosetAPI.Biz.Models
{
    public class Category
    {
        internal string name;

        public long Id { get; set; }
        public string Name { get; set; }


        public Category(string name)
        {
            Name = name;
        }

        public Category(long id, string name)
        {
            Id = id;
            Name = name;
        }
        public Category()
        {

        }
    }
}