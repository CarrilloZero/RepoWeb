using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesisWenAdmin.Models
{
    public class RecorridoParaderoViewModel
    {
        public int ParaderoId { get; set; }
        public int RecorridoId { get; set; }
        public SelectList paraderos { get; set; }
        public SelectList recorridos { get; set; }
    }
}