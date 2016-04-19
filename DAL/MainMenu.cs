using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MainMenu
    {
        private int menuID;
        private string itemName;
        private string permalink;
        private int itemIndex;
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

        public string ItemName
        {
            get
            {
                return itemName;
            }

            set
            {
                itemName = value;
            }
        }

        public string Permalink
        {
            get
            {
                return permalink;
            }

            set
            {
                permalink = value;
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
