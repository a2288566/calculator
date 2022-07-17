namespace Calculator_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool clearcheck = false;
        //設定按下計算鍵在按下數字鍵才會運算
        bool operatorcheck = false;

        private void numberclickbutton(object sender, EventArgs e)
        {
            //將所有數字鍵都設定為鍵上數字(出了0)
            var button = (Button)sender  ;
            var text = button.Text;
            //按下計算鍵在按下按下數字鍵後會歸0
            if (clearcheck == true)
            {
                showtextBox.Text = "";
                clearcheck = false;
            }
            showtextBox.Text += text;
            operatorcheck = true;
        }

        private void cleanbutton_Click(object sender, EventArgs e)
        {
            showtextBox.Text = "";
        }

        private void cebutton_Click(object sender, EventArgs e)
        {
            showtextBox.Text = "";
            savelabel.Text = "";
        }

        private void signbutton_Click(object sender, EventArgs e)
        {
            if (showtextBox.Text == "")
            {
                showtextBox.Text = "";
            }
            else
            {   //找不到-號給他-號
                if (showtextBox.Text.IndexOf("-") == -1)
                    showtextBox.Text = "-" + showtextBox.Text;
                //若是-數把它變正
                else
                    showtextBox.Text = (0 - Int32.Parse(showtextBox.Text)) + "";
            }
            
        }

        private void dotbutton_Click(object sender, EventArgs e)
        {
            while (showtextBox.Text.IndexOf(".") == -1)
                showtextBox.Text += ".";
            while (showtextBox.Text.Substring(0, 1) == ".")
                showtextBox.Text = "0.";
            if (clearcheck == true)
            {
                showtextBox.Text = "";
                clearcheck = false;
                showtextBox.Text = "0.";
            }
        }

        //抓運算符號做該符號的運算
        public void operatorjudge()
        {
            string sign = savelabel.Text.Substring(savelabel.Text.Length - 1, 1);
            if (sign == "+")
            {
                showtextBox.Text = Convert.ToDouble((Convert.ToDecimal(savelabel.Text.Remove(savelabel.Text.Length - 1, 1)) + Convert.ToDecimal(showtextBox.Text))).ToString();
            }
            else if (sign == "-")
            {
                showtextBox.Text = Convert.ToDouble((Convert.ToDecimal(savelabel.Text.Remove(savelabel.Text.Length - 1, 1)) - Convert.ToDecimal(showtextBox.Text))).ToString();
            }
            else if (sign == "x")
            {
                showtextBox.Text = Convert.ToDouble((Convert.ToDecimal(savelabel.Text.Remove(savelabel.Text.Length - 1, 1)) * Convert.ToDecimal(showtextBox.Text))).ToString();
            }
            else if (sign == "÷")
            {
                showtextBox.Text = Convert.ToDouble((Convert.ToDecimal(savelabel.Text.Remove(savelabel.Text.Length - 1, 1)) / Convert.ToDecimal(showtextBox.Text))).ToString();
            }
        }

        //輸入符號
        public void signjudge(string sign)
        {
            if (showtextBox.Text == "")
            {
                showtextBox.Text = "";
            }
            else
            {
                if (savelabel.Text == "")
                {
                    savelabel.Text = showtextBox.Text + sign;
                    operatorcheck = false;
                }
                else
                {   //按數字鍵後在按運算符號才會計算
                    if (operatorcheck == true)
                    {
                        operatorjudge();
                        savelabel.Text = showtextBox.Text + sign;
                    }
                    operatorcheck = false;
                    savelabel.Text = savelabel.Text.Remove(savelabel.Text.Length - 1, 1) + sign;
                }
            }
            clearcheck = true;
        }

        private void Plusbutton_Click(object sender, EventArgs e)
        {
            signjudge("+");
        }


        private void minusbutton_Click(object sender, EventArgs e)
        {
            signjudge("-");
        }

        private void multiplybutton_Click(object sender, EventArgs e)
        {
            signjudge("x");
        }

        private void dividedbutton_Click(object sender, EventArgs e)
        {
            signjudge("÷");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (showtextBox.Text == "0")
            {
                showtextBox.Text = "0";
            }
            else
                showtextBox.Text += 0;
            if (clearcheck == true)
            {
                showtextBox.Text = "";
                clearcheck = false;
                showtextBox.Text = "0";
            }
            operatorcheck = true;
        }

        private void equalsbutton_Click(object sender, EventArgs e)
        {
            if (showtextBox.Text == "")
            {
                showtextBox.Text = "";
            }
            else
            {
                operatorjudge();
                savelabel.Text = showtextBox.Text + "=";
                clearcheck = true;
            }            
        }
    }
}