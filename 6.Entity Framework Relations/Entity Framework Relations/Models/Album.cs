using System.Collections.Generic;

namespace StudentSystem.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}