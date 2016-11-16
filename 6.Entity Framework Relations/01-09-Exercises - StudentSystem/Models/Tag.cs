using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomAttributes;

namespace StudentSystem.Models
{
    public class Tag
    {
        private string name;

        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required, Tag]
        public string Name
        {
            get { return this.name; }
            set { this.name = TagTransofrmer.Transform(value); }
        }

        public virtual ICollection<Album> Albums { get; set; }
    }
}