using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlidesOnline.Models
{
    public class Slide
    {
        public int id{ get; set; }
        public string titulo { get; set; }
        public string album { get; set; }
        public string artista { get; set; }
        public string[] estrofes { get; set; }
    }
}