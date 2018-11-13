using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Vidly.Models;

namespace Vidly.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.DAL.VidlyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.DAL.VidlyContext context)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer() { Name = "Mary Smith", Id = 1, IsSubscribedToNewsletter = true, MembershipTypeId = 1, BirthDate = new DateTime(2004, 9, 24) },
                new Customer() { Name = "John Doe", Id = 2 ,IsSubscribedToNewsletter = false, MembershipTypeId = 2, BirthDate = new DateTime(1974, 8, 22) },
                new Customer() { Name = "Alice Ropartz", Id = 3, IsSubscribedToNewsletter = true, MembershipTypeId = 3 }
            };

            foreach (Customer customer in customers)
            {
                context.Customers.AddOrUpdate(customer);
            }
            context.SaveChanges();

            List<Movie> movies = new List<Movie>
            {
                new Movie() { Name = "Shrek", Id = 1, DateAdded = new DateTime(2012, 8, 23), ReleaseDate = new DateTime(2001, 4, 22), GenreId = 4 },
                new Movie() { Name = "Wall.E", Id = 2, DateAdded = new DateTime(2010, 12, 15), ReleaseDate = new DateTime(2008, 6, 27), GenreId = 1 },
                new Movie() { Name = "Anastasia", Id = 3, DateAdded = new DateTime(2006, 3, 8), ReleaseDate = new DateTime(1997, 11, 21), GenreId = 1 }
            };

            foreach (Movie movie in movies)
            {
                context.Movies.AddOrUpdate(movie);
            }
            context.SaveChanges();
        }
    }
}