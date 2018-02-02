using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PiPiPrestaciones.Models
{
    [Table("Aplicacion")]
    public class Aplicacion
    {
        [Key]
        [Column("AplicacionId")]
        public int AplicacionId { get; set; }


        [Display(Name = "Título")]
        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("AppIndependiente")]
        [Display(Name = "App independiente")]
        public bool AppIndependiente { get; set; }

        [Column("Idioma")]
        public string Idioma { get; set; }

        [Column("LenguajePorDefecto")]
        public bool LenguajePorDefecto { get; set; }

        [Column("ClaveApp")]
        public string ClaveApp { get; set; }

        [Column("AdminUser")]
        public string AdminUser { get; set; }

        [Column("AdminPasword")]
        [DataType(DataType.Password)]
        public string AdminPasword { get; set; }

        [Column("ApiKey")]
        public string ApiKey { get; set; }

        [Column("Canal")]
        public string Canal { get; set; }

        [Column("UrlImagenN")]
        public string UrlImagenN { get; set; }

        [Column("UrlImagen2")]
        public string UrlImagen2 { get; set; }

        [Column("UrlImagen1")]
        public string UrlImagen1 { get; set; }

        [Column("HashTagTwiter")]
        public string HashTagTwiter { get; set; }

        [Column("CssAplicacionId")]
        public int? CssAplicacionId { get; set; }

        [ForeignKey("CssAplicacionId")]
        public virtual CssModel CssAplicacion { get; set; }

        public virtual List<Menu> Menus { get; set; }

        [Display(AutoGenerateField = false,Name = "VersionId")]
        public string VersionId { get; set; }

        [Display(AutoGenerateField = false, Name = "Última modiicación")]
        public DateTime? LastModification { get; set; }


        [Display(AutoGenerateField = false, Name = "CreateAt")]
        public DateTime CreateAt { get; set; }


        [Display(AutoGenerateField = false, Name = "CreateBy")]
        public string CreateBy { get; set; }

        public Aplicacion() { }

        public Aplicacion(AplicacionCreateView a) {
            this.AdminPasword = a.AdminPasword;
            this.AdminUser = a.AdminUser;
            this.ApiKey = a.ApiKey;
            this.AppIndependiente = a.AppIndependiente;
            this.Canal = a.Canal;
            this.ClaveApp = a.ClaveApp;
            this.CreateAt = DateTime.Now;
            this.CssAplicacion = a.CssAplicacion;
            this.HashTagTwiter = a.HashTagTwiter;
            this.Idioma = a.Idioma;
            this.LenguajePorDefecto = a.LenguajePorDefecto;
            this.Titulo = a.Titulo;
            this.UrlImagen1 = a.UrlImagen1;
            this.UrlImagen2 = a.UrlImagen2;
            this.UrlImagenN = a.UrlImagenN;
            var guid = Guid.NewGuid();
            this.VersionId = guid.ToString();
            this.LastModification = DateTime.Now;
            this.CssAplicacion = new CssModel();
            this.CssAplicacion.ColorBack = a.CssAplicacion.ColorBack;
           


        }

    }


    public class AplicacionCreateView {

        [Key]  
        public int AplicacionId { get; set; }

      
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "App independiente")]     
        public bool AppIndependiente { get; set; }

        public string Idioma { get; set; }

        public bool LenguajePorDefecto { get; set; }

        public string ClaveApp { get; set; }

        public string AdminUser { get; set; }

        [DataType(DataType.Password)]
        public string AdminPasword { get; set; }

        public string ApiKey { get; set; }

        public string Canal { get; set; }

        public string UrlImagenN { get; set; }

        public string UrlImagen2 { get; set; }

        public string UrlImagen1 { get; set; }

        public string HashTagTwiter { get; set; }

        public CssModel CssAplicacion { get; set; }

        public virtual IEnumerable<Menu> Menus { get; set; }

        [Display(Name = "VersionId")]
        public string VersionId { get; set; }
     
        [Display(AutoGenerateField = false,Name = "Última modiicación")]
        public DateTime? LastModification { get; set; }

       
        [Display(AutoGenerateField = false,Name = "CreateAt")]
        public DateTime CreateAt { get; set; }

      
        [Display(AutoGenerateField = false,Name = "CreateBy")]
        public string CreateBy { get; set; }



    }


    public class PaletaColores
    {
        public string FondoGeneral { get; set; }

        public string LetrasGeneral { get; set; }

        public string FondoBotones { get; set; }

        public string LetrasBotones { get; set; }

        public string CompartirFondo { get; set; }

        public string CompartirTexto { get; set; }

        public string FondoTabs { get; set; }

        public string LetrasTabs { get; set; }


    }
}