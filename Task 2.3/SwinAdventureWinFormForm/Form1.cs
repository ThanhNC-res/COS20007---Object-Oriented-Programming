using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swin_Adventure
{
    public partial class Form1 : Form
    {
        InputForm _form;
        public Form1()
        {
            InitializeComponent();
            _form = new InputForm();
            commandBox.Text = _form.Output;
        }


        private void mainConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadCommand_Click(object sender, EventArgs e)
        {
            commandBox.Text = "\n" + _form.EnterCommand(mainConsole.Text);
            mainConsole.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void commandBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loadCommand_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
