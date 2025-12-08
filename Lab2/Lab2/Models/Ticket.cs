using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
