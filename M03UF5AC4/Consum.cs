using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M03UF5AC4
{
    public class consum
    {
        public int Any { get; set; }
        public int CodiComarca { get; set; }
        public string Comarca { get; set; }
        public int Poblacio { get; set; }
        public int DomesticXarxa { get; set; }
        public int ActivitatsEconomiques { get; set; }
        public int Total { get; set; }
        public double ConsumDomestic { get; set; }

        public consum(int any, int codiComarca, string comarca, int poblacio, int domesticXarxa, int activitatsEconomiques, int total, double consumDomestic)
        {
            Any = any;
            CodiComarca = codiComarca;
            Comarca = comarca;
            Poblacio = poblacio;
            DomesticXarxa = domesticXarxa;
            ActivitatsEconomiques = activitatsEconomiques;
            Total = total;
            ConsumDomestic = consumDomestic;
        }
    }
}