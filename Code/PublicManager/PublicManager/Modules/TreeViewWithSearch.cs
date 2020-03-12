using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PublicManager.Modules
{
    public partial class TreeViewWithSearch : UserControl
    {
        private List<TreeNode> listSearchTreeNodes;

        public Label SearchTextBoxLabel { get { return lblHint; } }

        public TextBox SearchTextBox { get { return txtNodeKeys; } }

        public TreeViewEx ContentTreeView { get { return tvDetail; } }

        public TreeViewWithSearch()
        {
            InitializeComponent();
        }

        private void txtNodeKeys_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text.Trim()))
            {
                if (listSearchTreeNodes != null)
                {
                    for (int i = 0; i < listSearchTreeNodes.Count; i++)
                    {
                        TreeNode trNode = listSearchTreeNodes[i];
                        trNode.BackColor = ContentTreeView.NoFocusNodeBackColor;
                        trNode.ForeColor = ContentTreeView.NoFocusNodeFontColor;
                    }
                    ContentTreeView.SelectedNode = null;
                }
                return;
            }

            if (listSearchTreeNodes != null)
            {
                for (int i = 0; i < listSearchTreeNodes.Count; i++)
                {
                    TreeNode trNode = listSearchTreeNodes[i];
                    trNode.BackColor = ContentTreeView.NoFocusNodeBackColor;
                    trNode.ForeColor = ContentTreeView.NoFocusNodeFontColor;
                }
                ContentTreeView.SelectedNode = null;
            }

            listSearchTreeNodes = new List<TreeNode>();
            foreach (TreeNode node in ContentTreeView.Nodes)  //Mange_TreeView是treeview控件名称
            {
                SearchLayer(node, this.SearchTextBox.Text.Trim());
            }

            for (int i = 0; i < listSearchTreeNodes.Count; i++)
            {
                TreeNode trNode = listSearchTreeNodes[i];
                ExpandNode(trNode);
                if (i == 0 && trNode.Parent != null)
                {
                    ContentTreeView.SelectedNode = trNode.Parent;
                }
                trNode.BackColor = ContentTreeView.FocusNodeBackColor;
                trNode.ForeColor = ContentTreeView.FocusNodeFontColor;
            }
        }

        /// <summary>
        /// 节点查询
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        private void SearchLayer(TreeNode node, string name)
        {
            if (node.Nodes.Count != 0)
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    SearchLayer(node.Nodes[i], name);
                }
            }

            if (string.Equals(node.Text, name) || node.Text.Contains(name))
            {
                listSearchTreeNodes.Add(node);
            }

            node.BackColor = ContentTreeView.NoFocusNodeBackColor;
            node.ForeColor = ContentTreeView.NoFocusNodeFontColor;
        }

        /// <summary>
        /// 展开节点
        /// </summary>
        /// <param name="node"></param>
        public void ExpandNode(TreeNode node)
        {
            node.Expand();

            if (node.Parent != null)
            {                
                ExpandNode(node.Parent);
            }
        }
    }

    public class TreeViewEx : TreeView
    {
        private Color focusNodeLineColor = Color.Gray;
        public Color FocusNodeLineColor
        {
            get { return focusNodeLineColor; }
            set { focusNodeLineColor = value; }
        }

        private Color focusNodeBackColor = Color.Green;
        public Color FocusNodeBackColor
        {
            get { return focusNodeBackColor; }
            set { focusNodeBackColor = value; }
        }

        private Color focusNodeFontColor = Color.White;
        public Color FocusNodeFontColor
        {
            get { return focusNodeFontColor; }
            set { focusNodeFontColor = value; }
        }

        private Color nofocusNodeLineColor = Color.Black;
        public Color NofocusNodeLineColor
        {
            get { return nofocusNodeLineColor; }
            set { nofocusNodeLineColor = value; }
        }

        private Color nofocusNodeBackColor = Color.White;
        public Color NoFocusNodeBackColor
        {
            get { return nofocusNodeBackColor; }
            set { nofocusNodeBackColor = value; }
        }

        private Color nofocusNodeFontColor = Color.Black;
        public Color NoFocusNodeFontColor
        {
            get { return nofocusNodeFontColor; }
            set { nofocusNodeFontColor = value; }
        }

        private Color selectedNodeBackColor = Color.LightGreen;
        public Color SelectedNodeBackColor
        {
            get { return selectedNodeBackColor; }
            set { selectedNodeBackColor = value; }
        }

        private Color selectedNodeFontColor = Color.White;
        public Color SelectedNodeFontColor
        {
            get { return selectedNodeFontColor; }
            set { selectedNodeFontColor = value; }
        }

        public TreeViewEx() : base()
        {
            HideSelection = false;
            DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            switch (e.State)
            {
                case TreeNodeStates.Checked:
                    drawCustomNode(e, FocusNodeBackColor, FocusNodeFontColor);
                    break;
                case TreeNodeStates.Default:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    break;
                case TreeNodeStates.Focused:
                    drawCustomNode(e, FocusNodeBackColor, FocusNodeFontColor);
                    break;
                case TreeNodeStates.Grayed:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    break;
                case TreeNodeStates.Hot:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    drawRectWithCustomNode(e, FocusNodeLineColor);
                    break;
                case TreeNodeStates.Indeterminate:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    break;
                case TreeNodeStates.Marked:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    drawRectWithCustomNode(e, FocusNodeLineColor);
                    break;
                case TreeNodeStates.Selected:
                    drawCustomNode(e, SelectedNodeBackColor, SelectedNodeFontColor);
                    break;
                case TreeNodeStates.ShowKeyboardCues:
                    drawCustomNode(e, NoFocusNodeBackColor, NoFocusNodeFontColor);
                    drawRectWithCustomNode(e, FocusNodeLineColor);
                    break;
            }
        }

        /// <summary>
        /// 画选择框
        /// </summary>
        /// <param name="e"></param>
        /// <param name="color"></param>
        public void drawRectWithCustomNode(DrawTreeNodeEventArgs e, Color color)
        {
            //线的颜色
            Pen focusPen = new Pen(color);
            focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            //画线框
            Rectangle focusBounds = e.Node.Bounds;
            focusBounds.Size = new Size(focusBounds.Width - 1,
            focusBounds.Height - 1);
            e.Graphics.DrawRectangle(focusPen, focusBounds);
        }

        /// <summary>
        /// 画树节点
        /// </summary>
        /// <param name="e"></param>
        /// <param name="backColor"></param>
        /// <param name="fontColor"></param>
        public void drawCustomNode(DrawTreeNodeEventArgs e, Color backColor, Color fontColor)
        {
            //画背景色
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Node.Bounds);

            //确定字体
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null)
            {
                nodeFont = Font;
            }

            //画文字
            e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(fontColor), Rectangle.Inflate(e.Bounds, 2, 0));
        }
    }
}