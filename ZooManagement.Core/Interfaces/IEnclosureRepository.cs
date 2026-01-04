using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Interfaces
{
    public interface IEnclosureRepository
    {
        IEnumerable<Enclosure> GetAll();
        Enclosure? GetById(int id);
        Enclosure Add(Enclosure enclosure);
        Enclosure Update(Enclosure enclosure);
        void Delete(int id);
    }
}
