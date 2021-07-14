using System;
using System.Windows.Forms;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Component'ten bir nesne oluşturuyoruz.
            var recSquDiff = new MyRecursiveSquareDifference();

            // Sahip olduğu Factorial Metotunu çağırıyoruz ve sonuca ulaşıyoruz.
            var result = recSquDiff.Factorial((int)numericUpDown1.Value);

            // Sonuç
            label1.Text = result.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
