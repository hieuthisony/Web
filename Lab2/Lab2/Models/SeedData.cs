using Lab2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lab2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Lab2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Lab2Context>>()))
            {
                // Kiểm tra nếu DB đã có phim thì dừng lại (Tránh trùng lặp)
                if (context.Movie.Any())
                {
                    return;
                }

                // ==========================================
                // 1. TẠO CATEGORY (THỂ LOẠI)
                // ==========================================
                var catRomance = new Category { Name = "Romantic Comedy" };
                var catComedy = new Category { Name = "Comedy" };
                var catWestern = new Category { Name = "Western" };
                var catAction = new Category { Name = "Action" };

                context.Category.AddRange(catRomance, catComedy, catWestern, catAction);

                // ==========================================
                // 2. TẠO CUSTOMER (KHÁCH HÀNG)
                // ==========================================
                var cus1 = new Customer { FullName = "Nguyen Van A", Email = "vana@gmail.com" };
                var cus2 = new Customer { FullName = "Tran Thi B", Email = "thib@gmail.com" };
                var cus3 = new Customer { FullName = "Le Van C", Email = "vanc@gmail.com" };

                context.Customer.AddRange(cus1, cus2, cus3);

                // Lưu Category và Customer trước để có ID
                context.SaveChanges();

                // ==========================================
                // 3. TẠO MOVIE (PHIM) - Gán Category
                // ==========================================
                var movieHarry = new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R",
                    Category = catRomance // Gán object Category
                };

                var movieGhost = new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "PG-13",
                    Category = catComedy
                };

                var movieGhost2 = new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "PG-13",
                    Category = catComedy
                };

                var movieRio = new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "R",
                    Category = catWestern
                };

                context.Movie.AddRange(movieHarry, movieGhost, movieGhost2, movieRio);
                context.SaveChanges(); // Lưu Movie để có ID dùng cho Ticket

                // ==========================================
                // 4. TẠO TICKET (VÉ) - Gán Movie và Customer
                // ==========================================
                context.Ticket.AddRange(
                    new Ticket
                    {
                        SeatNumber = "A1",
                        Price = 7.99M,
                        PurchaseDate = DateTime.Now,
                        Movie = movieHarry,   // Khách A xem phim Harry
                        Customer = cus1
                    },
                    new Ticket
                    {
                        SeatNumber = "A2",
                        Price = 7.99M,
                        PurchaseDate = DateTime.Now,
                        Movie = movieHarry,   // Khách B cũng xem phim Harry
                        Customer = cus2
                    },
                    new Ticket
                    {
                        SeatNumber = "B5",
                        Price = 8.99M,
                        PurchaseDate = DateTime.Now.AddDays(-1), // Mua hôm qua
                        Movie = movieGhost,   // Khách C xem Ghostbusters
                        Customer = cus3
                    }
                );

                // Lưu lần cuối
                context.SaveChanges();
            }
        }
    }
}