using System.Collections.Generic;

namespace ComplantSystem.Service.Helpers
{
    public static class Globals
    {
        public static List<RolesList> RolesLists { get; set; } = new List<RolesList>
        {
            new RolesList{ Id = 1 , Name = "مدير إتحاد عام"},
            new RolesList{ Id = 2 , Name = "مدير مديريه"},
            new RolesList{ Id = 3 , Name = "مدير مديريه"},
            new RolesList{ Id = 4 , Name = "dasdasd"},
            new RolesList{ Id = 5 , Name = "qweqwe"},
            new RolesList{ Id = 6 , Name = "مزارع"}
        };
    }
}
