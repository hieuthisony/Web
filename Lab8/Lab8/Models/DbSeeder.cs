namespace Lab8.Models
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Kiểm tra xem database có dữ liệu chưa, nếu chưa thì mới thêm
            if (!context.Brands.Any())
            {
                // 1. Tạo Brands (Hãng xe)
                var toyota = new Brand { Name = "Toyota", Country = "Japan" };
                var hyundai = new Brand { Name = "Hyundai", Country = "Korea" };
                var ford = new Brand { Name = "Ford", Country = "USA" };

                context.Brands.AddRange(toyota, hyundai, ford);
                context.SaveChanges(); // Lưu để lấy Id

                // 2. Tạo CarModels (Dòng xe)
                var vios = new CarModel { Name = "Vios", BrandId = toyota.Id };
                var camry = new CarModel { Name = "Camry", BrandId = toyota.Id };
                var santafe = new CarModel { Name = "SantaFe", BrandId = hyundai.Id };
                var ranger = new CarModel { Name = "Ranger", BrandId = ford.Id };

                context.CarModels.AddRange(vios, camry, santafe, ranger);
                context.SaveChanges();

                // 3. Tạo Cars (Xe cụ thể)
                context.Cars.AddRange(
                    new Car { Name = "Vios E 2023", CarModelId = vios.Id },
                    new Car { Name = "Vios G 2023", CarModelId = vios.Id },
                    new Car { Name = "Camry 2.5Q", CarModelId = camry.Id },
                    new Car { Name = "SantaFe Diesel Premium", CarModelId = santafe.Id },
                    new Car { Name = "Ford Ranger Wildtrak", CarModelId = ranger.Id }
                );

                // 4. Tạo Customers (Khách hàng mẫu)
                var cus1 = new Customer { Name = "Nguyễn Văn An", Address = "HCM", PhoneNumber = "0901234567", IdentityCardNumber = "079090123456" };
                var cus2 = new Customer { Name = "Trần Thị Lan", Address = "HN", PhoneNumber = "0909888777", IdentityCardNumber = "001090888777" };

                context.Customers.AddRange(cus1, cus2);
                context.SaveChanges();

                // 5. Tạo Orders (Đơn hàng mẫu - NÊN CÓ)
                context.Orders.AddRange(
                    new Order
                    {
                        OrderDate = DateTime.Now.AddDays(-2), // Đặt cách đây 2 ngày
                        CustomerId = cus1.Id
                    },
                    new Order
                    {
                        OrderDate = DateTime.Now, // Đặt hôm nay
                        CustomerId = cus2.Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
