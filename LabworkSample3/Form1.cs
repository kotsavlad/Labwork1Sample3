using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabworkSample3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(itemTextBox.Text, out double value))
            {
                arrayListBox.Items.Add(value);
            }
            else
            {
                MessageBox.Show("Invalid item", "Value error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                itemTextBox.SelectAll();
                itemTextBox.Focus();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            arrayListBox.Items.Clear();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            var array = new double[arrayListBox.Items.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = double.Parse(arrayListBox.Items[i].ToString());
            }
            var resultList = GetResult(numbers: array);
            if (resultList.Count == 0)
            {
                MessageBox.Show("No solution", "No numbers found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var resultStr = string.Join("\n", resultList);
            MessageBox.Show(resultStr, "Solution", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Search array items which are less than at least 2 previous array elements.
        /// </summary>
        /// <param name="numbers">Input numeric array.</param>
        /// <returns>The list of sought numbers.</returns>
        private List<double> GetResult(double[] numbers)
        {
            var result = new List<double>();
            for (int i = 2; i < numbers?.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] < numbers[j])
                        count++;
                    if (count == 2)
                    {
                        result.Add(numbers[i]);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
