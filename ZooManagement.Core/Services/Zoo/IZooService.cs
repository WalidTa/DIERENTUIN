namespace ZooManagement.Core.Services.Zoo
{
    public interface IZooService
    {
        IEnumerable<string> Sunrise();
        IEnumerable<string> Sunset();
        IEnumerable<string> FeedingTime();
        IEnumerable<string> CheckConstraints();
        // Task<List<string>> AutoAssignAsync();
    }
}
