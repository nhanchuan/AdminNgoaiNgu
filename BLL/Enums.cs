using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public enum TypeAudit
    {
        AddNew = 1,//00000001
        Edit = 2,  //00000010
        Delete = 4,//00000100
        View = 8   //00001000 
    }
}
