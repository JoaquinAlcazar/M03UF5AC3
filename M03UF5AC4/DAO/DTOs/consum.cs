namespace dao.DTOs
{
    public class consumDTO
    {
        public int Any { get; set; }
        public int CodiComarca { get; set; }
        public string Comarca { get; set; }
        public int Poblacio { get; set; }
        public int DomesticXarxa { get; set; }
        public int ActivitatsEconomiques { get; set; }
        public int Total { get; set; }
        public decimal ConsumDomestic { get; set; }

        public consumDTO(int any, int codiComarca, string comarca, int poblacio, int domesticXarxa, int activitatsEconomiques, int total, decimal consumDomestic)
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