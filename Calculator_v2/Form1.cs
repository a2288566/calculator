namespace Calculator_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        bool clearcheck = false;
        //�]�w���U�p����b���U�Ʀr��~�|�B��
        bool operatorcheck = false;

        private void numberclickbutton(object sender, EventArgs e)
        {
            //�N�Ҧ��Ʀr�䳣�]�w����W�Ʀr(�X�F0)
            var button = (Button)sender  ;
            var text = button.Text;
            //���U�p����b���U���U�Ʀr���|�k0
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
            {   //�䤣��-�����L-��
                if (showtextBox.Text.IndexOf("-") == -1)
                    showtextBox.Text = "-" + showtextBox.Text;
                //�Y�O-�Ƨ⥦�ܥ�
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

        //��B��Ÿ����ӲŸ����B��
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
            else if (sign == "��")
            {
                showtextBox.Text = Convert.ToDouble((Convert.ToDecimal(savelabel.Text.Remove(savelabel.Text.Length - 1, 1)) / Convert.ToDecimal(showtextBox.Text))).ToString();
            }
        }

        //��J�Ÿ�
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
                {   //���Ʀr���b���B��Ÿ��~�|�p��
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
            signjudge("��");
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