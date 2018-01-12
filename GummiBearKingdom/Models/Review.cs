using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBearKingdom.Models
{
    [Table("Reviews")]
    public class Review
    {
        private int rating;

        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string ContentBody { get; set; }
        public int Rating
        {
            get => rating;
            set => rating = Math.Max(1, Math.Min(value, 5));
        }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public override bool Equals(object obj)
        {
            Review other = obj as Review;
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
    }
}
