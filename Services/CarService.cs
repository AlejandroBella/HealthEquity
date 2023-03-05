using Entities;
using Services.Interface;

namespace Services
{
    public class CarService : IEntityServiceService<Car>
    {
        private List<Car> carList;
        public CarService()
        {
            carList = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                new Car { Id = 3, Make = "Porsche", Model = " 911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 },
            };
        }
        
        public void Add(Car car)
        {
            if (!IsValid(car))
            {
                throw new Exception("The car is not Valid");
            }

            carList.Add(car);
        }

        public bool GessPrice(int id, int price)
        {
          return carList.Exists(x => x.Id == id && x.Price == price);            
        }

        public List<Car> GetAll()
        {
            return carList;
        }

        public void Remove(int carId)
        {
            var removeCar = carList.Find(x => x.Id == carId);

            if (removeCar != null)
                carList.Remove(removeCar);
        }

        private bool IsValid(Car car)
        {
            //Validation for later
            return true;
        }
    }
}