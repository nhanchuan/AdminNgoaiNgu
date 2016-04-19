using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Menu_Category
    {
        private int cMenuID;
        private int menuID;
        private int categoryID;
        private int itemIndex;
        public int CMenuID
        {
            get
            {
                return cMenuID;
            }

            set
            {
                cMenuID = value;
            }
        }

        public int MenuID
        {
            get
            {
                return menuID;
            }

            set
            {
                menuID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID;
            }

            set
            {
                categoryID = value;
            }
        }

        public int ItemIndex
        {
            get
            {
                return itemIndex;
            }

            set
            {
                itemIndex = value;
            }
        }
    }
}
