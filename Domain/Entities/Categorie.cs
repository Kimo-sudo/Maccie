using System.Collections.Generic;

namespace Domain.Entities
{
    public class Categorie
    {
        public Categorie()
        {
            Producten = new HashSet<Product>();

        }
        public int CategorieId { get; set; }
        public string CategorieNaam { get; set; }
        public ICollection<Product> Producten { get; set; }
    }
}