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

        [Column("NombreAplicacion")]
        [Display(Name = "Nombre Aplicación")]
        public string NombreAplicacion { get; set; }

        [Column("VersionId")]
        [Display(Name = "VersionId")]
        public int? VersionId { get; set; }

        [Column("LastModification")]
        [Display(Name = "Última modiicación")]
        public DateTime? LastModification { get; set; }

        [Column("CreateAt")]
        [Display(Name = "CreateAt")]
        public DateTime CreateAt { get; set; }

        [Column("CreateBy")]
        [Display(Name = "CreateBy")]
        public string CreateBy { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
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

      


        [Display(Name = "VersionId")]
        public int? VersionId { get; set; }
     
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