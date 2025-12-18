using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [MaxLength(100)]
        // Sửa FullName -> Name để khớp với Views
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        // Thêm thuộc tính này vì Views đang cần hiển thị CMND/CCCD
        [Required(ErrorMessage = "Vui lòng nhập CMND/CCCD")]
        [MaxLength(20)]
        public string IdentityCardNumber { get; set; } = null!;

        // Navigation Property: Một khách hàng có thể có nhiều đơn hàng
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
