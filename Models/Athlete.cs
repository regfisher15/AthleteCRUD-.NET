using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Athletes.Models
{
    public class Athlete
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [Precision(16, 1)]
        public decimal PointsPerGame { get; set; }
        [Precision(16, 1)]
        public decimal ReboundsPerGame { get; set; }
        [Precision(16, 1)]
        public decimal AssistsPerGame { get; set; }
        [Precision(16, 1)]
        public decimal FieldGoalPercentage { get; set; }
        [Precision(16, 1)]
        public decimal ThreePointPercentage { get; set; }
        public int Championships { get; set; }
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
