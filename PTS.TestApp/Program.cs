using PTS.Domain.Entities;
using PTS.Domain.Infrastructure;
using PTS.Persistence;
using System;

namespace PTS.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var admin = new Customer {
                CustomerId = 1,
                Username = "jed",
                Password = Encypt.EncryptString("jed8703"),
                ExternalId = Guid.NewGuid()
            };

            using (var db = new PTSDbContext())
            {
                db.Add(admin);
                db.SaveChanges();
            }


        }
    }
}
