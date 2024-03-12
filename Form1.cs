using System;
using System.Windows.Forms;

namespace DBkp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LR1.AboutBox1 ab1 = new LR1.AboutBox1();
            ab1.ShowDialog();
        }

        private void учетПосещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void учетУспеваемостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void учетПреподавателейИДисциплинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void рейтингСтудентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void списокНеуспевающихСтудентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
