using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int CategorieId { get; set; }
        public double Prijs { get; set; }
        public bool Actief { get; set; }

        [JsonIgnore]
        public Categorie Categorie { get; set; }
    }
}