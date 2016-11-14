using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual Student Student { get; set; }
    }
}