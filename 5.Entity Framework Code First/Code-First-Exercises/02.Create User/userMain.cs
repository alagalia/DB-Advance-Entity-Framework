using System;
using System.IO;
using _02.Create_User.Models;

namespace _02.Create_User
{
    class UserMain
    {
        static void Main()
        {
            User user = new User()
            {
                Username = "Lusy",
                Password = "123",
                Email = "alabala@ala.bg",
                ProfilePicture =
                    File.ReadAllBytes(
                        @"C:\Users\Dell\Desktop\cat-breed-landing-hero.jpg"),
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now,
                Age = 20,
                IsDeleted = false
            };

            UserContext context = new UserContext();
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
