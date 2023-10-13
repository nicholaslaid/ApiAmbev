using System.Drawing;

namespace ApiAmbev.Models
{
    public class info
    {

        public int id_venda { get; set; }   
       public int id_produto { get; set; }
        
        public int qtd { get; set; }

        public double valor_unitario { get; set; }

        public double subtotal { get; set; }

    }
}
