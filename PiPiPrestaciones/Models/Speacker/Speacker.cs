using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PiPiPrestaciones.Models
{
    public class Speacker
    {
        public string Id { get; set; }
        public string TitleModal { get; set; }
        public string FullName { get; set; }
        public List<string> DescriptionList { get; set; }
        public string ImageUrl { get; set; }
        public string NationalityUrl { get; set; }
        public string WebUrl { get; set; }
        public CssSpeacker CssSpeacker{ get; set; }
    }
}