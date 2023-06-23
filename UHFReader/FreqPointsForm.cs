#define _DEBUG

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UHFReader
{
    public partial class FreqPointsForm : Form
    {
        public static int freqnum = 0;
        public static int[] freqpoints =new int[124];
        List<TreeNode> nodeList = new List<TreeNode>();
        int cnt = 0;

        const string tag = "2";  //Tag标签
        StringBuilder nodesTag;     //存放被选项

        public FreqPointsForm()
        {
            InitializeComponent();
        }

        private void FreqPoints_Load(object sender, EventArgs e)
        {
            FreqPoints_treeView.CheckBoxes = true;
            //根节点
            TreeNode rootNode = new TreeNode("读写器射频参数-频点");
            ImageList myImageList = new ImageList();
#if _DEBUG
            myImageList.Images.Add(Image.FromFile("Unselected.bmp"));
            myImageList.Images.Add(Image.FromFile("Selected.bmp"));
#endif
            FreqPoints_treeView.ImageList = myImageList;
            FreqPoints_treeView.ImageIndex = 0;
            FreqPoints_treeView.SelectedImageIndex = 1;
            
            FreqPoints_treeView.Nodes.Add(rootNode);

            //一级节点
            for (int i = 900; i < 931; i++)
            {
                FreqPoints_treeView.Nodes[0].Nodes.Add(i.ToString());
            }

            //二级节点
            for (int i = 0; i < FreqPoints_treeView.Nodes[0].Nodes.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    FreqPoints_treeView.Nodes[0].Nodes[i].Nodes.Add((900 + i + j / 4.00F).ToString("F02"));//保留两位小数
                    FreqPoints_treeView.Nodes[0].Nodes[i].Nodes[j].Tag = cnt++;
                }
            }

            GetNodeCheckStatus();
            FreqPoints_treeView.ExpandAll();
        }

        /// <summary>
        /// 判断同级的节点是否全选
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool nextChecked(TreeNode node)
        {
            if (node.Checked == false)
                return false;
            if (node.NextNode == null)
                return true;
            return nextChecked(node.NextNode);
        }

        /// <summary>
        /// 判断同级的节点是否全不选
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool nextUnchecked(TreeNode node)
        {
            if (node.Checked)
                return false;
            if (node.NextNode == null)
                return true;
            return nextUnchecked(node.NextNode);
        }

        bool bCheck = false;
        private void FreqPoints_treeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //非递归实现
            //if (bCheck)
            //    return;

            ////要求父节点被勾选则子节点全部被勾选；父节点不被勾选则子节点全部不被勾选
            //if (e.Node.Parent == null && e.Node.Nodes.Count != 0)  //父节点
            //{
            //    if (e.Node.Checked)
            //    {
            //        for (int i = 0; i < e.Node.Nodes.Count; i++)
            //        {
            //            if (!e.Node.Nodes[i].Checked)
            //            {
            //                bCheck = true;
            //                e.Node.Nodes[i].Checked = true; //父节点选中则子节点全部选中
            //            }
            //        }
            //        e.Node.ForeColor = Color.Black;
            //        bCheck = false;
            //    }
            //    return;
            //}

            ///*要求子节点全部不勾选则父节点不被勾选且文本呈黑色；
            // *子节点部分被勾选则父节点不被勾选文本呈蓝色；
            // *子节点全部勾选则父节点被勾选且文本呈黑色
            // */
            //if (e.Node.Parent == null && e.Node.Nodes.Count == 0)  //子节点
            //{
            //    if (nextChecked(e.Node.Parent.FirstNode))    //全部勾选
            //    {
            //        bCheck = true;
            //        e.Node.Parent.Checked = true;
            //        e.Node.Parent.ForeColor = Color.Black;
            //    }
            //    else if (nextUnchecked(e.Node.Parent.FirstNode)) //全部不勾选
            //    {
            //        bCheck = true;
            //        e.Node.Parent.Checked = false;
            //        e.Node.Parent.ForeColor = Color.Black;
            //    }
            //    else
            //    {
            //        bCheck = true;
            //        e.Node.Parent.Checked = false;
            //        e.Node.Parent.ForeColor = Color.CornflowerBlue;
            //    }
            //}

            //递归实现
            if (e.Action != TreeViewAction.Unknown)
            {
                TreeNode node = e.Node;
                if (node.Tag == null)
                    node.Tag = tag;     //附加节点信息
                else
                    node.Tag = null;
                //Event call by mouse or key-press
                SetNodeCheckStatus(e.Node, e.Node.Checked);
            }
        }

        private void SetNodeCheckStatus(TreeNode tn, bool Checked)
        {
            if (tn == null)
                return;

            //Check children nodes
            foreach (TreeNode tnChild in tn.Nodes)
            {
                tnChild.Checked = Checked;
                //tnChild.Tag = Checked ? tag : null;
                SetNodeCheckStatus(tnChild, Checked);
            }

            //Set parent check status
            TreeNode tnParent = tn;
            int nNodeCount = 0;
            while (tnParent.Parent != null)
            {
                tnParent = tnParent.Parent;
                nNodeCount = 0;
                foreach (TreeNode tnTemp in tnParent.Nodes)
                {
                    if (tnTemp.Checked == Checked)
                        nNodeCount++;
                }
                if (nNodeCount == tnParent.Nodes.Count)
                    tnParent.Checked = Checked;
                else
                    tnParent.Checked = false;
            }
        }

        /// <summary>
        /// 遍历节点
        /// </summary>
        /// <param name="node"></param>
        private void TraverseNodes(TreeNode node)
        {
            if (node != null)
            {
                if (node.Tag != null && node.Tag.ToString() == tag)
                {
                    nodeList.Add(node);
                }
                if (node.FirstNode != null)         //如果node节点还有子节点则进入遍历
                {
                    TraverseNodes(node.FirstNode);
                }
                if (node.NextNode != null)          //如果node节点后面有同级节点则进入遍历
                {
                    TraverseNodes(node.NextNode);
                }
            }
        }

        private void GetNode(TreeNode node)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                if(node.Nodes[i].Checked)
                    nodeList.Add(node);
                GetNode(node.Nodes[i]);
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_button_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < FreqPoints_treeView.Nodes.Count; i++)
            //{
            //    GetNode(FreqPoints_treeView.Nodes[i]);
            //}
            //for (int i = 1; i < nodeList.Count; i += 5)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        string s = nodeList[i].Nodes[j].Text;
            //    } 
            //}
            TreeNode node = FreqPoints_treeView.TopNode;   //得到TreeView的根节点，注意根结点只有一个
            //每次搜寻到根节点
            while (node.PrevNode != null)
            {
                node = node.PrevNode;
            }
            TraverseNodes(node);    //遍历根节点

            for (int i = 0; i < FreqPoints_treeView.Nodes[0].Nodes.Count; i++)
            {
                for (int j = 0; j < FreqPoints_treeView.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    if (FreqPoints_treeView.Nodes[0].Nodes[i].Nodes[j].Checked)
                        freqpoints[freqnum++] = Convert.ToInt32(FreqPoints_treeView.Nodes[0].Nodes[i].Nodes[j].Tag);
                }
            }
            Array.Copy(freqpoints, MainForm.Freqpoints, 124);
            MainForm.Freqnum = freqnum;
            Array.Clear(freqpoints, 0, 124);
            freqnum = 0;
            Close();
        }

        private void GetNodeCheckStatus()
        {
            for (int i = 0; i < FreqPoints_treeView.Nodes[0].Nodes.Count; i++)
            {
                for (int j = 0; j < FreqPoints_treeView.Nodes[0].Nodes[i].Nodes.Count; j++)
                {
                    for (int k = 0; k < 124; k++)
                    {
                        if (Convert.ToInt32(FreqPoints_treeView.Nodes[0].Nodes[i].Nodes[j].Tag) 
                            == MainForm.Freqpoints[k])
                            FreqPoints_treeView.Nodes[0].Nodes[i].Nodes[j].Checked = true;
                    }
                }
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Array.Clear(freqpoints, 0, 124);
            freqnum = 0;
            Close();
        }

        //private void FreqPoints_treeView_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    e.Node.Checked = true;
        //}
    }
}
