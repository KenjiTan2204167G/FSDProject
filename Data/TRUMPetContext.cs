using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TRUMPet.Domain;

namespace TRUMPet.Data
{
    public class TRUMPetContext : DbContext
    {
        public TRUMPetContext (DbContextOptions<TRUMPetContext> options)
            : base(options)
        {
        }

        public DbSet<TRUMPet.Domain.Artist> Artist { get; set; } = default!;
        public DbSet<TRUMPet.Domain.Song> Song { get; set; } = default!;
    }
}
