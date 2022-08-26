using ComplantSystem.Data.ViewModels;

using System.Threading.Tasks;


namespace ComplantSystem.Service
{
    public interface ISolveCompalintService
    {

        Task UpdateMovieAsync(CompalintSolutionVM data);
    }
}
