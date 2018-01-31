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
        public PiPiPrestacionesDBContext() : base("PiPrestaciones")
        {
        }

     
        //public DbSet<Aplicacion> Aplicacion { get; set; }
        public DbSet <Aplicacion> Aplicacion { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<CssModel> CssModel { get; set; }
        public DbSet<Type> Type { get; set; }
        public DbSet<StaticPage> StaticPage { get; set; }
        public DbSet<StaticContent> StaticContent { get; set; }
        public DbSet<Map> Map { get; set; }



    }
}