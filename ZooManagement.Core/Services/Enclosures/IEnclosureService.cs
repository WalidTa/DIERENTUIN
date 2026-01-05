using ZooManagement.Core.Entities;

namespace ZooManagement.Core.Services.Enclosures
{
    public interface IEnclosureService
    {
        IEnumerable<Enclosure> GetAll();
        Enclosure? GetById(int id);
        Enclosure Create(Enclosure enclosure);
        Enclosure Update(Enclosure enclosure);
        void Delete(int id);
        IEnumerable<string> Sunrise(int enclosureId);
        IEnumerable<string> Sunset(int enclosureId);
        IEnumerable<string> FeedingTime(int enclosureId);
        IEnumerable<string> CheckConstraints(int enclosureId);

    }
}
