using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OlallaJessica_ExamenP1.Models;

    public class OlallaJessica_ExamenP1Context : DbContext
    {
        public OlallaJessica_ExamenP1Context (DbContextOptions<OlallaJessica_ExamenP1Context> options)
            : base(options)
        {
        }

        public DbSet<OlallaJessica_ExamenP1.Models.Olalla> Olalla { get; set; } = default!;
    }
