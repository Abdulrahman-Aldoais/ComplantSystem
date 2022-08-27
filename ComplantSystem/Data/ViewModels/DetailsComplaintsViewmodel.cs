using ComplantSystem.Models;
using System.Collections.Generic;

namespace ComplantSystem.Data.ViewModels
{
    public class DetailsComplaintsViewmodel
    {
        public UploadsComplainte compalint { get; set; }

        public IEnumerable<Compalints_Solution> Compalints_SolutionList { get; set; }
    }
}
