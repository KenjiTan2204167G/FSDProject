using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using TRUMPet.Domain;

namespace TRUMPet.Data
{
    public class TRUMPetContext : DbContext
    {
        public TRUMPetContext(IdentityDbContext<TRUMPetContext> options)
            : base(options)
        {
        }

        public DbSet<TRUMPet.Domain.Artist> Artist { get; set; } = default!;
        public DbSet<TRUMPet.Domain.Song> Song { get; set; } = default!;
        public DbSet<TRUMPet.Domain.Genre> Genre { get; set; } = default!;
        public DbSet<TRUMPet.Domain.User> User { get; set; } = default!;
        public DbSet<TRUMPet.Domain.Staff> Staffs { get; set; } = default!;
    }
}
