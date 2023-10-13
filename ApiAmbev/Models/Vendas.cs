using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiAmbev.Models
{
    public class Vendas
    {
        public int id { get; set; }
        public DateTime dataVenda { get; set; }

        public string Cliente { get; set;}

        public string Vendedor { get; set; }

        public int qtd_produtos { get; set; }

        public double valorTotal { get; set; }
       
    }
}
