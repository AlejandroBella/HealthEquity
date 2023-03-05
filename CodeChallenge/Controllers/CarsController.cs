using AutoMapper;
using CodeChallenge.ViewModel;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

namespace CodeChallenge.Controllers
{
    public class CarsController : Controller
    {
        private ILogger<CarsController> _logger;
        private IEntityServiceService<Car> _carService;
        private IMapper _mapper;

        public CarsController(IEntityServiceService<Car> carService, IMapper mapper, ILogger<CarsController> logger)
        {
            _logger = logger;
            _carService = carService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {

            return View(GetMappedCarList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCarViewModel newCar)
        {
            var mappedCar = GetCarEntity(newCar);
            _carService.Add(mappedCar);
            return View("Index", GetMappedCarList());
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _carService.Remove(id);
            return View("Index", GetMappedCarList());
        }


        [HttpGet]
        public IActionResult GuessPrice(int id, int price)
        {
            var result = _carService.GessPrice(id, price);
            var carList = GetMappedCarList();
            var car = carList.Find(x => x.Id == id);
            if (car != null)
                car.Guessed = true;
            return View("Index", carList);
        }
        private List<CarViewModel> GetMappedCarList()
        {
            return (List<CarViewModel>)_mapper.Map(_carService.GetAll(), typeof(List<Car>), typeof(List<CarViewModel>));
        }

        private Car GetCarEntity(CarViewModel newCar)
        {
            return (Car)_mapper.Map(newCar, typeof(CarViewModel), typeof(Car));
        }
        private Car GetCarEntity(CreateCarViewModel newCar)
        {
            return (Car)_mapper.Map(newCar, typeof(CreateCarViewModel), typeof(Car));
        }
    }
}
