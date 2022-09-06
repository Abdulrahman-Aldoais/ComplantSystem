using ComplantSystem.Models;
using System.Collections.Generic;

namespace ComplantSystem.Data.ViewModels
{
    public class ProvideSolutionsVM
    {
        public UploadsComplainte compalint { get; set; }

        public IEnumerable<Compalints_Solution> Compalints_SolutionList { get; set; }

        public AddSolutionVM AddSolution { get; set; }
        public IEnumerable<ComplaintsRejected> ComplaintsRejectedList { get; set; }
        public ComplaintsRejectedVM RejectedComplaintVM { get; set; }
    }
}
