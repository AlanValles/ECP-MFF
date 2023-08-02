using System;
using System.Linq;
using System.Threading.Tasks;
using Antlr.Runtime.Misc;
using System.Collections.Generic;

namespace ECP_MFF.Models
{
    public class GraficaReporteGeneral
    {
        public string name { get; set; }
        public double y { get; set; }
        public bool sliced { get; set; }
        public bool selected{ get; set; }

        public GraficaReporteGeneral() { 
        
        }

        public GraficaReporteGeneral(string name,double y, bool sliced, bool selected) {
            this.name = name;
            this.y = y;
            this.sliced = sliced;
            this.selected= selected;
        }


        public List<GraficaReporteGeneral> GetDataDummy() 
        {
            List<GraficaReporteGeneral> lista = new List<GraficaReporteGeneral>();

            lista.Add(new GraficaReporteGeneral("Angular",45,true,true));
            lista.Add(new GraficaReporteGeneral("Angular", 45, true, true));
            lista.Add(new GraficaReporteGeneral("Angular",45,true,true));
            lista.Add(new GraficaReporteGeneral("Angular",45,true,true));
            return lista;
        }
    }
}