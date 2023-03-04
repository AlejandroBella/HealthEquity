using AutoMapper;
using CodingAssessment.ViewModel;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace CodingAssessment.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly IEntityServiceService<Car> _carService;
        private readonly IMapper _mapper;

        public CarController(IEntityServiceService<Car> carService, IMapper mapper, ILogger<CarController> logger)
        {
            _logger = logger;
            _carService = carService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
     
            return View(GetMappedCarList());
        }

        private List<CarViewModel> GetMappedCarList()
        {
            return (List<CarViewModel>)_mapper.Map(_carService.GetAll(), typeof(List<Car>), typeof(List<CarViewModel>));
        }

        public IActionResult Create()
        {
            return View(GetMappedCarList());
        }

        [HttpPost]
        public IActionResult Create(CarViewModel newCar)
        {
            var mappedCar = GeCarEntity(newCar);
            _carService.Add(mappedCar);
            return View("Index", _carService);
        }

        private Car GeCarEntity(CarViewModel newCar)
        {
            return (Car)_mapper.Map(newCar, typeof(CarViewModel), typeof(Car));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _carService.Remove(id);
            return View("Index",GetMappedCarList());
        }

    }
}