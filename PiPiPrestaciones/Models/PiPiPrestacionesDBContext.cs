using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PiPiPrestaciones.Models;

namespace PiPiPrestaciones.Models
{
    public class PiPiPrestacionesDBContext: DbContext
    {
        public PiPiPrestacionesDBContext() : base("DefaultConnection")
        {
        }

        public DbSet<Agenda> Agenda { get; set; }
        //public DbSet<Aplicacion> Aplicacion { get; set; }
        public DbSet <Aplicacion> Aplicacion { get; set; }
        public DbSet<PantallaAplicacion> PantallaAplicacion { get; set; }

        public System.Data.Entity.DbSet<PiPiPrestaciones.Models.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<PiPiPrestaciones.Models.PantallaEstatica> PantallaEstaticas { get; set; }

        public System.Data.Entity.DbSet<PiPiPrestaciones.Models.StaticPage> StaticPages { get; set; }

        public System.Data.Entity.DbSet<PiPiPrestaciones.Models.Map> Maps { get; set; }

        public System.Data.Entity.DbSet<PiPiPrestaciones.Models.Speacker> Speackers { get; set; }
    }
}