using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Menu
{
    abstract class BillBuilder
    {
        protected Dictionary<Menu, int> order = new Dictionary<Menu, int>();

        protected long pay;

        protected long discount;

        protected string show;

        public bool DaChonMon = false;

        public bool DuThanhToan = false;

        protected int[] price = { 129, 149, 185, 185, 199, 205, 359, 359, 36, 68, 49, 71, 17, 42, 47, 51, 27, 57 };
        public abstract BillBuilder set(Menu option, int val);
        public abstract BillBuilder Discount(long discount);
        public abstract BillBuilder Pay(long givenMoney);
        public abstract void Show();
        public abstract Bill build();
    }
}
