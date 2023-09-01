using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public virtual List<Rating> Ratings{ get; set; } = new List<Rating>();
        public float AverageRating
        {
            get
            {
                if (Ratings.Count == 0)
                {
                    return 0;
                }

            float total = 0.0f;
            foreach (Rating rating in Ratings)
            {
                total +=(float) rating.Score;
            }
            return total / Ratings.Count;
            }
        }
    }
}