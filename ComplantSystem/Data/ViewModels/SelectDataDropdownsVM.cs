using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ComplantSystem.Models.Data.ViewModels
{
    public class SelectDataDropdownsVM
    {
        //SelectDataDropdownsForNewCompalintVM
        public SelectDataDropdownsVM()
        {
        
            TypeComplaints = new List<TypeComplaint>();
            StatusCompalints = new List<StatusCompalint>();
            //identityRoles = new List<ApplicationRole>();


        }

        //public int ID { get; set; }
      
      
        public List<TypeComplaint> TypeComplaints { get; set;}
        public List<StatusCompalint> StatusCompalints { get; set; }
        //public List<ApplicationRole> identityRoles { get; set; }
    }
}
