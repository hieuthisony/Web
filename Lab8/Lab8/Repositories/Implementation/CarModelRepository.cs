using Lab8.Models;
using Lab8.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace Lab8.Repositories.Implementation
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Sửa hàm GetAll: Trả về trực tiếp CarModel
        public List<CarModel> GetAll()
        {
            return _context.CarModels
                .Include(cm => cm.Brand) 
                .ToList();
        }

        // Các hàm khác giữ nguyên
        public CarModel? GetById(int id)
        {
            return _context.CarModels.Find(id);
        }

        public void Add(CarModel carModel)
        {
            _context.CarModels.Add(carModel);
            _context.SaveChanges();
        }

        public void Update(CarModel carModel)
        {
            _context.CarModels.Update(carModel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var carModel = _context.CarModels.Find(id);
            if (carModel != null)
            {
                _context.CarModels.Remove(carModel);
                _context.SaveChanges();
            }
        }
    }
}
