using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class PiPiPrestacionesDBContext: DbContext
    {
        public PiPiPrestacionesDBContext() : base("DefaultConnection")
        {
        }

        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Aplicacion> Aplicacion { get; set; }
        public DbSet<PantallaAplicacion> PantallaAplicacion { get; set; }


    }
}