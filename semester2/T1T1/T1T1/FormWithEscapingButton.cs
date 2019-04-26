using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T1T1
{
    public partial class FormWithEscapeButton : Form
    {
        public Button myButton;

        /// <summary>
        /// Constructor initializing the initial state of the form
        /// </summary>
        public FormWithEscapeButton()
        {
            InitializeComponent();
            myButton = new Button();
            myButton.Size = new Size(40, 40);
            myButton.Location = new Point(30, 30);
            myButton.Text = "Click me";
            this.Controls.Add(myButton);
            myButton.Click += new EventHandler(myButton_Click);
            myButton.MouseEnter += new EventHandler(myButton_Escape);
            this.Resize += new EventHandler(WindowResized);
            this.MinimumSize = new Size(250, 250);
        }

        /// <summary>
        /// If you try to press a button, the button runs away
        /// </summary>
        private void myButton_Escape(object sender, EventArgs e)
        {
            Random r = new Random();
            myButton.Left = r.Next(0, this.ClientSize.Width - myButton.Width);
            myButton.Top = r.Next(0, this.ClientSize.Height - myButton.Height);
        }

        /// <summary>
        /// If you clicked on the button, the game ends
        /// </summary>
        private void myButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Well, you beat the button");
            this.Close();
        }

        /// <summary>
        /// Adequate button behavior when resizing a window
        /// </summary>
        private void WindowResized(object sender, EventArgs e)
        {
            if (myButton.Left + myButton.Width > this.ClientSize.Width || myButton.Height + myButton.Top > this.ClientSize.Height)
            {
                myButton_Escape(null, null);
            }
        }

        public void FormWithEscapeButton_Load(object sender, EventArgs e) { }
    }
}
