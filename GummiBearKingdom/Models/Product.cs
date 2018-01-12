using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBearKingdom.Models
{
    [Table(Product.TableName)]
    public class Product
    {
        public const string TableName = "Products";

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public override bool Equals(object obj)
        {
            Product other = obj as Product;
            if (other != null)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public string GetCostAsUSD()
        {
            return $"${String.Format("{0:.00}", Cost)}";
        }

        public decimal GetAverageRating()
        {
            decimal total = 0;
            if (Reviews == null)
            {
                return total;
            }

            foreach (Review review in Reviews)
            {
                total += review.Rating;
            }

            return total / Reviews.Count;
        }
    }
}
