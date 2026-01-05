using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Roles
{
    public class LaicoRolFuncional
    {
        public int IdLaicoRolFuncional { get; set; }
        public int IdLaico { get; set; }
        public int IdRolFuncional { get; set; }

        public LaicoRolFuncional() { }

        public LaicoRolFuncional(int idLaicoRolFuncional, int idLaico, int idRolFuncional)
        {
            IdLaicoRolFuncional = idLaicoRolFuncional;
            IdLaico = idLaico;
            IdRolFuncional = idRolFuncional;
        }

        public LaicoRolFuncional(int idLaico, int idRolFuncional)
        {
            IdLaico = idLaico;
            IdRolFuncional = idRolFuncional;
        }
    }
}
