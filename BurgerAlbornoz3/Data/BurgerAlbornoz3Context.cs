using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BurgerAlbornoz3.Models;

namespace BurgerAlbornoz3.Data
{
    public class BurgerAlbornoz3Context : DbContext
    {
        public BurgerAlbornoz3Context (DbContextOptions<BurgerAlbornoz3Context> options)
            : base(options)
        {
        }

        public DbSet<BurgerAlbornoz3.Models.Burger> Burger { get; set; } = default!;
        public DbSet<BurgerAlbornoz3.Models.Promo> Promo { get; set; } = default!;
    }
}
