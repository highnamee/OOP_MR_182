using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Menu
{
    public enum Menu
    {
        ComboA, ComboB, ComboC, ComboD, ComboE, ComboF,
        ComboGDA, ComboGDB,
        GaRan,
        GaQuay,
        HotWingx3,
        HotWingx5,
        CocaL,
        BurgerTom,
        BugerGa,
        BugerZinger,
        KhoaiChienL,
        GaPopcornL
    }
    class Bill
    {
        private Dictionary<Menu, int> order;
        private long pay;
        private long discount;
        private string show; 
        
        public Bill(Dictionary<Menu, int> order, long discount, long givenMoney, string show)
        {
            this.order = order;
            this.discount = discount;
            this.pay = givenMoney;
            this.show = show;
        }
        public string toString()
        {
            return show;
        }
    }
}
