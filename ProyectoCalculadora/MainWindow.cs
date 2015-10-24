using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuCalculatorLogicLib;

namespace ProyectoCalculadora
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            
            calculator = new CalculatorLogicLib();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
            txtDisplay.ReadOnly = true;
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            txtDisplay.MaxLength = 15;
            Text = "DuarteCalculator";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.backspaceClicked(ref display);
            txtDisplay.Text = display;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.clear(ref display);
            txtDisplay.Text = display;
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.clearAll(ref display);
            txtDisplay.Text = display;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            calculator.clearMemory();
        }

        private void digitClicked(int value)
        {
            string display = txtDisplay.Text;
            calculator.digitClicked(value, ref display);
            txtDisplay.Text = display;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            digitClicked(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            digitClicked(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            digitClicked(9);
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.multiplicativeOperatorClicked("/", ref display);
            txtDisplay.Text = display;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.unaryOperatorClicked("Sqrt", ref display);
            txtDisplay.Text = display;
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.readMemory(ref display);
            txtDisplay.Text = display;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            digitClicked(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            digitClicked(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            digitClicked(6);
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.multiplicativeOperatorClicked("*", ref display);
            txtDisplay.Text = display;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.unaryOperatorClicked("x^2", ref display);
            txtDisplay.Text = display;
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.setMemory(ref display);
            txtDisplay.Text = display;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            digitClicked(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            digitClicked(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            digitClicked(3);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.additiveOperatorClicked("-", ref display);
            txtDisplay.Text = display;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.unaryOperatorClicked("1/x", ref display);
            txtDisplay.Text = display;
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.addToMemory(ref display);
            txtDisplay.Text = display;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            digitClicked(0);
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.pointClicked(ref display);
            txtDisplay.Text = display;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.changeSignClicked(ref display);
            txtDisplay.Text = display;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.additiveOperatorClicked("+", ref display);
            txtDisplay.Text = display;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            string display = txtDisplay.Text;
            calculator.equalClicked(ref display);
            txtDisplay.Text = display;
        }

        private CalculatorLogicLib calculator;
    }
}
