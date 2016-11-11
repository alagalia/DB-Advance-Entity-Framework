namespace _02.Create_User.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private string username;

        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(30)]
        public string Username
        {
            get { return this.username; }
            set
            {
                //check 
                if (value == null)
                {
                    throw new ArgumentException();
                }
                this.username = value;
            }
        }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
