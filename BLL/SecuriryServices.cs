using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class SecuriryServices
    {
        UserPermissBLL userpermiss;
        public bool HasPermission(TypeAudit audit, int permission)
        {
            if (((int)audit & permission) == (int)audit)
            {
                return true;
            }
            return false;
        }

        //public Boolean Check_Permission(int uid, int permissfunctid, TypeAudit audit)
        //{
        //    userpermiss = new UserPermissBLL();
        //    List<UserPermiss> lstU = userpermiss.getUserPermissWithUidPerid(uid, permissfunctid);
        //    UserPermiss up = lstU.FirstOrDefault();
        //    return HasPermission(audit, up.PermisstionNumber);
        //}
        public Boolean Check_PermissionFunct(int uid, string pode)
        {
            userpermiss = new UserPermissBLL();
            List<UserPermiss> lstP = userpermiss.lstPermissWithCode(uid, pode);
            UserPermiss up = lstP.FirstOrDefault();
            if(up!=null)
            {
                return true;
            }
            return false;
        }

    }
}
