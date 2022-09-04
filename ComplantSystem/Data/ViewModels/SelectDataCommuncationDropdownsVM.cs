using ComplantSystem.Models;
using System.Collections.Generic;

namespace ComplantSystem.Data.ViewModels
{
    public class SelectDataCommuncationDropdownsVM
    {
        public SelectDataCommuncationDropdownsVM()
        {
            ApplicationUsers = new List<ApplicationUser>();
            TypeCommunications = new List<TypeCommunication>();
        }

        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<TypeCommunication> TypeCommunications { get; set; }
    }
}
