using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Models
{
    public class Resource
    {
        public Resource()
        {
            
        }
       public Resource(string name, string typeOfResource, string url )
        {
            this.Name = name;
            this.TypeOfResource = typeOfResource;
            this.Url = url;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, RegularExpression("video|presentation|document|other")]
        public string TypeOfResource { get; set; }

        [Required, RegularExpression(@"www\..+\.com|net|org|bg")]
        public string Url { get; set; }

        public virtual Course Course { get; set; }  

        public virtual ICollection<License> Licenses { get; set; }
    }
}