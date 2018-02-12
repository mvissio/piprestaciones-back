using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    [Table("Type")]
    public class Type
    {

        [Key]
        [Column("TypeId")]
        public int TypeId { get; set; }

        [Column("TypeName")]
        public string TypeName { get; set; }

        [Column("Status")]
        public bool Status { get; set; }


        public Type() { }

        public Type(string typeName, bool status) {
            this.TypeName = typeName;
            this.Status = status;
        }

        public void InflateType() {
            var db = new PiPiPrestacionesDBContext();
            var listType = new List<Type> {
                new Type("Agenda",true),
                 new Type("Favoritos",true),
                  new Type("Alojamientos",true),
                   new Type("Mapa",true),
                    new Type("Exposición",true),
                     new Type("Formulario",true),
                      new Type("Certificado",true),
                       new Type("Link",true),
                         new Type("Disertantes",true),
                        new Type("Noticias",true),
                         new Type("Paginas",true)
            };
            
            foreach (var item in listType) {
                db.Type.Add(item);              
            }
            db.SaveChanges();

        }
    }
}