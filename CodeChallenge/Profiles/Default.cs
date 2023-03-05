using AutoMapper;
using CodeChallenge.ViewModel;
using Entities;

namespace CodeChallenge.Profiles
{
    public class Default:Profile
    {
        public Default()
        {
            CreateMap<Car, CarViewModel>().ReverseMap();
            CreateMap<Car, CreateCarViewModel>().ReverseMap();            
        }
    }
}
