using System;
using System.Data.Entity.Validation;
using PhotoShare.Data.Intefaces;
using PhotoShare.Data.Repositories;
using PhotoShare.Models;

namespace PhotoShare.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhotoShareContext context;
        private IRepository<Album> albums;
        private IRepository<AlbumRole> albumRoles;
        private IRepository<Picture> pictures;
        private IRepository<Tag> tags;
        private IRepository<Town> towns;
        private IRepository<User> users;

        public UnitOfWork()
        {
            this.context = new PhotoShareContext();
        }
        public IRepository<Album> Albums
        {
            get
            {
                return this.albums ?? (this.albums = new Repository<Album>(context.Albums));
            }
        }

        public IRepository<AlbumRole> AlbumRoles
        {
            get
            {
                return this.albumRoles ?? (this.albumRoles = new Repository<AlbumRole>(context.AlbumRoles));

            }
        }

        public IRepository<Picture> Pictures {
            get
            {
                return this.pictures ?? (this.pictures = new Repository<Picture>(context.Pictures));

            }
        }
        public IRepository<Tag> Tags {
            get
            {
                return this.tags ?? (this.tags = new Repository<Tag>(context.Tags));

            }
        }
        public IRepository<Town> Towns {
            get
            {
                return this.towns ?? (this.towns = new Repository<Town>(context.Towns));

            }
        }
        public IRepository<User> Users {
            get
            {
                return this.users ?? (this.users = new Repository<User>(context.Users));

            }
        }
        public void Save()
        {
            try
            {
            context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult e in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError innerE in e.ValidationErrors)
                    {
                        Console.WriteLine(innerE.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}