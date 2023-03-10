
using Control_Ingreso_Gasto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Control_Ingreso_Gasto.Data
{
    public class AplicationDbContext: DbContext

    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<IngresoGasto> IngresoGasto { get; set; }

            public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}

