using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFC_Menu
{
    class BillConcreteBuilder : BillBuilder
    { 
        public override BillBuilder set(Menu option, int val)
        {
            if (order.ContainsKey(option)) order[option] = val;
            else order.Add(option, val);
            if (val == 0) order.Remove(option);
            return this;
        }
        public override BillBuilder Discount(long discount)
        {
            this.discount = discount;
            return this;
        }

        public override BillBuilder Pay(long pay)
        {
            this.pay = pay;
            return this;
        }

        public override void Show()
        {
            long total = 0;
            show = "\n";
            show += "\n";
            show += "       CUA HANG KFC DAI HOC BACH KHOA \n";
            show += "\n";
            show += "Thời gian lập hóa đơn:";
            show += DateTime.Now + "\n";
            show += "\n";
            show += String.Format("{0,-15} | {1,-5} | {2,-12}", "Tên món ăn", "Số lượng", "  Thành tiền");
            show += "\n";
            foreach (KeyValuePair<Menu, int> kvp in order)
            {
                long add =Convert.ToInt64(price[(int)kvp.Key] * kvp.Value * 1000);
                show += String.Format("{0,-20}  {1,-5}  {2,12}", kvp.Key, kvp.Value, String.Format("{0:#,###,###.##}", add));
                show += "\n";
                total += add;
            }
            show += "\n------------------------------------------\n";
            show += String.Format("{0,-30} {1,10}", "Tổng hóa đơn:", String.Format("{0:#,###,###.##}", total)); show += "\n";
            show += String.Format("{0,-30} {1,10}", "Khuyến mãi:", String.Format("{0}", discount)); show += "%\n";
            long res =Convert.ToInt64(total * (100 - discount) / 100);
            show += String.Format("{0,-30} {1,10}", "Phải thanh toán:", String.Format("{0:#,###,###.##}", res)); show += "\n";
            show += String.Format("{0,-30} {1,10}", "Khách hàng đưa:", String.Format("{0:#,###,###.##}", pay)); show += "\n";
            long left = pay - res;
            show += String.Format("{0,-30} {1,10}", "Thối lại:", String.Format("{0:#,###,###.##}", left)); show += "\n";
            if (total > 0) DaChonMon = true;
            else DaChonMon = false;
            if (left >= 0) DuThanhToan = true;
            else DuThanhToan = false;
           }
        public override Bill build()
        {
            Show();
            return new Bill(order, discount, pay, show);
        }
    }
}

