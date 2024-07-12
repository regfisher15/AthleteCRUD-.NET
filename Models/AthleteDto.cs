using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Athletes.Models
{
    public class AthleteDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        [Required]
        public decimal PointsPerGame { get; set; }
        [Required]
        public decimal ReboundsPerGame { get; set; }
        [Required]
        public decimal AssistsPerGame { get; set; }
        [Required]
        public decimal FieldGoalPercentage { get; set; }
        [Required]
        public decimal ThreePointPercentage { get; set; }
        [Required]
        public int Championships { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
