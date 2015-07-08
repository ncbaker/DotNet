using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCB.DataStructures;

namespace NCB.Windows
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        public void BuildTree(BinaryTree<int> tree)
        {
            TreeNode root = BuildNode(tree.Root);
            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }

        public TreeNode BuildNode(BinaryNode<int> node)
        {
            TreeNode n = new TreeNode() { Text = node.Value.ToString() };
            
            if(node.LeftNode != null)
                n.Nodes.Add(BuildNode(node.LeftNode));

            if (node.RightNode != null)
                n.Nodes.Add(BuildNode(node.RightNode));

            return n;
        }

        private StringBuilder PrintList(List<List<int>> list)
        {
            StringBuilder sb = new StringBuilder();
            int ix = 0;
            foreach (var item in list)
            {
                if (item.Count == 0) continue;

                sb.AppendFormat("Ix - {0}, Sum {1} - List ", ix++, item.Sum());
                sb.Append("{");
                foreach (var i in item)
                    sb.Append(i + ",");

                if (sb.Length > 1)
                    sb.Remove(sb.Length - 1, 1);
                
                sb.Append("}");
                sb.AppendLine();
            }
            sb.AppendLine();
            sb.AppendFormat("Count - {0}", list.Count);

            return sb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                SummaryBinaryTree<int> tree = TreeFactory.GetCareerCupTree();
                BuildTree(tree);

                List<List<int>> exploded = tree.ExplodeTree();
                textBox1.Text = PrintList(exploded).ToString();

                int search = 0;
                if (Int32.TryParse(textBox3.Text, out search))
                {
                    List<List<int>> searched = tree.SearchBranchSummaries(search).Values.ToList();
                    textBox2.Text = PrintList(searched).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
        }
    }
}
