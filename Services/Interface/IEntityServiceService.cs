using Entities;

namespace Services.Interface
{
    public interface IEntityServiceService<T>
    {
        List<T> GetAll();
        void Add(T car);
        void Remove(int carId);
        bool GessPrice(int id, int price);
    }
}