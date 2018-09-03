using System.Threading.Tasks;

namespace CinemaScheduler.App.Services.Interfaces
{
    public interface ISeeder
    {
        Task UpdateDb();
        Task Seed();
    }
}
