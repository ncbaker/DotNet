using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgrammingProblems.DataStructures;

namespace ProgrammingProblems.Windows
{
    public partial class FrmMain : Form
    {
        #region menu clicks
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            binaryTreesToolStripMenuItem_Click(null, null);
        }
        #endregion


        #region menu clicks
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void binaryTreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBinaryTree frm = new FrmBinaryTree();
            frm.MdiParent = this;
            frm.Show();
        }
        #endregion        
    }
}
