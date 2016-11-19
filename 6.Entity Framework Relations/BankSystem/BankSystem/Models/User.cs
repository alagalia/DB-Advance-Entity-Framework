using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BankSystem.Models
{
    public class User
    {
        private string password;
        private string userName;
        private string email;

        public User(string userName, string password, string email)
        {
            this.Password = password;
            this.UserName = userName;
            this.Email = email;
        }

        public User()
        {
            
        }

        public int Id { get; set; }

        [Required, MinLength(4), RegularExpression(@"^(?=.{3,}$)[a-zA-Z0-9]+")]
        public string UserName {
            get { return this.userName; }
            set
            {
                if (!value.All(char.IsLetterOrDigit) ||
                    char.IsDigit(value[0]) ||
                    value.Length<3)
                {
                    throw new ArgumentException("Incorrect username");
                }
                this.userName = value;
            } }

        [Required, MinLength(4)]
        public string Password {
            get { return this.password; }
            set
            {
                if (!value.Any(char.IsUpper) ||
                    !value.Any(char.IsLower) ||
                    !value.Any(char.IsDigit) ||
                    value.Length<6)
                {
                    throw new ArgumentException("Incorrect password");
                }
                this.password = value;
            }
        }

        [Required]
        public string Email {
            get { return this.email; }
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Incorrect email");
                }

                if ((!value.Split('@')[0].All(c => Char.IsLetterOrDigit(c) ||
                                                   c.Equals('_') ||
                                                   c.Equals('-') ||
                                                   c.Equals('.')))
                    || (value.IndexOfAny(new char[] { '-', '_', '.' }) == 0))
                {
                    throw new ArgumentException("Incorrect email");
                }
                this.email = value;
            }
        }

        public bool IsLoggedIn { get; set; }

        public virtual ICollection<Account> Accounts{ get; set; }
    }
}