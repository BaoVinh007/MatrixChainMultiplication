using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixChainMultiplication
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public int[,] m = new int[100, 100];
        public int[,] s = new int[100, 100];
        public string str;

        private string prin(int i, int j)
        {
	        if(i == j)
	        {
                str += i;
		        //cout << i;
            }
	        else
	        {		
		        //cout << "(";
                str += "(";
		        prin(i, s[i, j]);
		        prin((s[i, j]+1), j);
                str += ")";
		        //cout << ")";
	        }
            return str;
        }

        private void matrixChain(int[] p,int n)
        {
	         int i, j, k, l, q;
	         for(i = 1; i < n; i++)
	         {
		        m[i, i] = 0;
	         }

	         for(l = 2; l < n; l++)
	         {
		        for(i = 1; i < n - l + 1; i++)
		        {
			        j = i + l - 1;
			        m[i, j] = (int)Math.Pow(10, 5);
			        for(k = i; k <= j - 1; k++)
			        {
				        q = m[i, k] + m[k+1, j] + p[i-1] * p[k] * p[j];
				        if(q < m[i,j])
				        {
					        m[i, j] = q;
					        s[i, j] = k;
				        }
			        }
		        }
	         }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToString();
            string[] arr = input.Split(' ');            
            int n = arr.Length;
            int[] p = new int[n];            

            for (int i = 0; i < n; i++)
            {
                p[i] = Int16.Parse(arr[i]);                
            }
            matrixChain(p, n);
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    richTextBox1.Text += m[i, j] + "\t";                    
                }
                richTextBox1.Text += "\n";                
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    richTextBox2.Text += s[i, j] + "\t";
                }
                richTextBox2.Text += "\n";
            }
            string str = prin(1, n-1);
            textBox2.Text = str;
            textBox3.Text = m[1, n-1].ToString();
        }
    }
}
