namespace ApiAmbev.Models
{
    public class Products
    {
        public int id { get; set; }
        public string nome { get; set; }

        public float volume { get; set; }

        public string tipo { get; set; }

        public string marca { get; set; }

        public string frasco { get; set; }

        public DateTime data {get;set;}
    }
}
