using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace KFC_Menu
{
    public partial class Form1 : Form
    {
        BillBuilder PrintBill = new BillConcreteBuilder();
        Bill BillDisplay;
        public void ViewBill()
        {
            BillDisplay = PrintBill.build();
            if (!PrintBill.DaChonMon) { MessageBox.Show("Vui lòng chọn món"); goto E; }
            lbBill.Items.Clear();
            string BillContent = BillDisplay.toString();
            foreach (string s in Regex.Split(BillContent, "\n"))
                lbBill.Items.Add(s);
            E: { };
        }
        public Form1()
        {
            InitializeComponent();
            comboBoxMaGiamGia.SelectedIndex = 0;
            textBoxTienKhachDua.Text = "";
        }

        private void NumericUpDownComboA_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboA,Decimal.ToInt32(numericUpDownComboA.Value));
        }

        private void NumericUpDownComboB_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboB, Decimal.ToInt32(numericUpDownComboB.Value));
        }

        private void NumericUpDownComboDGA_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboGDA, Decimal.ToInt32(numericUpDownComboGDA.Value));
        }
        private void NumericUpDownComboC_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboC, Decimal.ToInt32(numericUpDownComboC.Value));
        }

        private void NumericUpDownComboD_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboD, Decimal.ToInt32(numericUpDownComboD.Value));
        }

        private void NumericUpDownComboE_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboE, Decimal.ToInt32(numericUpDownComboE.Value));
        }

        private void NumericUpDownComboF_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboF, Decimal.ToInt32(numericUpDownComboF.Value));
        }

        private void NumericUpDownComboGDB_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.ComboGDB, Decimal.ToInt32(numericUpDownComboGDB.Value));
        }

        private void NumericUpDownGaRan_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.GaRan, Decimal.ToInt32(numericUpDownGaRan.Value));
        }

        private void NumericUpDownGaQuay_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.GaQuay, Decimal.ToInt32(numericUpDownGaQuay.Value));
        }

        private void NumericUpDownHotWingsX3_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.HotWingx3, Decimal.ToInt32(numericUpDownHotWingsX3.Value));
        }

        private void NumericUpDownHotWingsX5_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.HotWingx5, Decimal.ToInt32(numericUpDownHotWingsX5.Value));
        }

        private void NumericUpDownCocaL_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.CocaL, Decimal.ToInt32(numericUpDownCocaL.Value));
        }

        private void NumericUpDownBgTom_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.BurgerTom, Decimal.ToInt32(numericUpDownBgTom.Value));
        }

        private void NumericUpDownBgGa_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.BugerGa, Decimal.ToInt32(numericUpDownBgGa.Value));
        }

        private void NumericUpDownBgZinger_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.BugerZinger, Decimal.ToInt32(numericUpDownBgZinger.Value));
        }

        private void NumericUpDownKhoaiChienL_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.KhoaiChienL, Decimal.ToInt32(numericUpDownKhoaiChienL.Value));
        }

        private void NumericUpDownGaPcL_ValueChanged(object sender, EventArgs e)
        {
            PrintBill.set(KFC_Menu.Menu.GaPopcornL, Decimal.ToInt32(numericUpDownGaPcL.Value));
        }

        private void ComboBoxMaGiamGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaGiamGia.SelectedItem != null)
            {
                long x = Convert.ToInt64(comboBoxMaGiamGia.SelectedItem.ToString());
                PrintBill.Discount(x);
            }
            else PrintBill.Discount(0);
        }

        private void TextBoxTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTienKhachDua.Text != "")
            {
                PrintBill.Pay(Convert.ToInt64(textBoxTienKhachDua.Text));
                lblSoTien.Text = String.Format("{0:#,###,###.##}", Convert.ToInt64(textBoxTienKhachDua.Text)) + " VND";
            }
            else
            {
                PrintBill.Pay(0);
                lblSoTien.Text = "0 VND";
            }
        }
        private void ButtonXem_Click(object sender, EventArgs e)
        {
            ViewBill();
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            ViewBill();
            if (!PrintBill.DuThanhToan) MessageBox.Show("Không đủ thanh toán");
            else if (PrintBill.DaChonMon) MessageBox.Show("In thành công");
        }

        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            numericUpDownBgGa.Value = 0;
            numericUpDownBgTom.Value = 0;
            numericUpDownBgZinger.Value = 0;
            numericUpDownCocaL.Value = 0;
            numericUpDownComboA.Value = 0;
            numericUpDownComboB.Value = 0;
            numericUpDownComboC.Value = 0;
            numericUpDownComboD.Value = 0;
            numericUpDownComboE.Value = 0;
            numericUpDownComboF.Value = 0;
            numericUpDownComboGDA.Value = 0;
            numericUpDownComboGDB.Value = 0;
            numericUpDownGaPcL.Value = 0;
            numericUpDownGaQuay.Value = 0;
            numericUpDownGaRan.Value = 0;
            numericUpDownHotWingsX3.Value = 0;
            numericUpDownHotWingsX5.Value = 0;
            numericUpDownKhoaiChienL.Value = 0;
            comboBoxMaGiamGia.SelectedIndex = 0;
            textBoxTienKhachDua.Text = "";
            PrintBill.DaChonMon = false;
            PrintBill.DuThanhToan = false;
            lbBill.Items.Clear();
        }

        private void TextBoxTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
