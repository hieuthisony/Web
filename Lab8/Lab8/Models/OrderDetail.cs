using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab8.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        // Foreign Key: Thuộc về đơn hàng nào
        [Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        // Foreign Key: Mua xe nào (Liên kết với bảng Car đã tạo ở bước trước)
        [Required]
        public int CarId { get; set; }
        [ForeignKey(nameof(CarId))]
        public Car Car { get; set; } = null!;

        [Required]
        public int Quantity { get; set; } // Số lượng mua

        [Required]
        public decimal UnitPrice { get; set; } // Giá tại thời điểm mua
    }
}
