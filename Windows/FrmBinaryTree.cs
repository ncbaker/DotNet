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
    public partial class FrmBinaryTree : Form
    {
        #region constructor, load
        public FrmBinaryTree()
        {
            InitializeComponent();
        }
        private void FrmBinaryTree_Load(object sender, EventArgs e)
        {
        }
        #endregion


        #region methods - Quick First Pass Single Method Algorithm
        public void LoadDataSimple()
        {
            try
            {
                int search = 0;
                if (Int32.TryParse(txtSearchNumber.Text, out search))
                {
                    treeView1.Nodes.Clear();
                    SimpleBinaryNode tree = TreeFactory.GetCareerCupTreeSimple();

                    List<List<int>> results = new List<List<int>>();
                    GetBranches(tree, 7, new List<int>(), results);

                    textBox1.Text = PrintList(results).ToString();
                }
                else
                    MessageBox.Show("Search input is invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
        }

        public List<int> GetBranches(SimpleBinaryNode node, int total, List<int> intermediateResults, List<List<int>> results)
        {
            intermediateResults.Add(node.Value);

            Console.WriteLine("Parent - " + node.Value + "  ->   " + string.Join(",", intermediateResults.ToArray()));
            if (node.RightNode != null && node.RightNode.Value == 5)
            { }

            if (intermediateResults.Sum() == total)
            {
                results.Add(intermediateResults);    //(new List<int>() {node.Value});
            }

            if (node.LeftNode != null)
            {
                List<int> t = GetBranches(node.LeftNode, total, new List<int>(intermediateResults), results);
                Console.WriteLine("Left - " + node.LeftNode.Value + "  ->   " + string.Join(",", t.ToArray()));
                //intermediateResults.AddRange(t);
            }
            if (node.RightNode != null)
            {
                List<int> t = GetBranches(node.RightNode, total, new List<int>(intermediateResults), results);
                Console.WriteLine("Right - " + node.RightNode.Value + "  ->   " + string.Join(",", t.ToArray()));
                //intermediateResults.AddRange(t);
            }
            if (node.LeftNode == null && node.RightNode == null)
            {
                intermediateResults.Clear();
                Console.WriteLine("Clear");
                Console.WriteLine("");
            }

            return intermediateResults;
        }
        #endregion


        #region methods - More Engineered Solution Involving Inheritance
        public void LoadData()
        {
            try
            {
                treeView1.Nodes.Clear();
                SummaryBinaryTree tree = TreeFactory.GetCareerCupTree();
                BuildTree(tree);

                List<List<int>> exploded = tree.ExplodeTree();
                textBox1.Text = PrintList(exploded).ToString();

                int search = 0;
                if (Int32.TryParse(txtSearchNumber.Text, out search))
                {
                    List<List<int>> searched = tree.SearchBranchSummaries(search).Values.ToList();
                    textBox2.Text = PrintList(searched).ToString();
                }
                else
                    MessageBox.Show("Search input is invalid");
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
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

            if (node.LeftNode != null)
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
        #endregion


        #region events
        private void button1_Click(object sender, EventArgs e)
        {
            if (rbSimple.Checked)
                LoadDataSimple();
            else
                LoadData();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
        #endregion

    }
}
