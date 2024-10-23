using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Folder;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Drawing.Text;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Folder> folderInstance = CreateAlphabetFolders();
            
            //attach event handler
            folderTreeView.MouseUp += new MouseEventHandler(folderTreeView_MouseUp);
            folderTreeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(folderTreeView_NodeMouseDoubleClick);

            folderTreeView.MouseUp += new MouseEventHandler(folderTreeView_MouseUp);
            contextMenuStrip1.Opening += new CancelEventHandler(contextMenuStrip1_Opening);


            ToolStripMenuItem addDocumentMenuItem = new ToolStripMenuItem("Add Document");
            addDocumentMenuItem.Click += new EventHandler(AddDocumentMenuItem_Click);
            contextMenuStrip1.Items.Add(addDocumentMenuItem);

            ToolStripMenuItem retrieveChildMenuItem = new ToolStripMenuItem("Retrieve Child");
            retrieveChildMenuItem.Click += new EventHandler(RetrieveChildMenuItem_Click);
            contextMenuStrip1.Items.Add(retrieveChildMenuItem);

            PopulateTreeView(folderInstance);
            
        }
        private List<Folder> CreateAlphabetFolders()
        { //create list of folders A-Z
            List<Folder> folders = new List<Folder>();
            for(char c ='A'; c <= 'Z'; c++)
            {
                folders.Add(new Folder(c.ToString()));
            }
            return folders;
        }
        private void PopulateTreeView(List<Folder> rootFolders)
        {
            foreach (var rootFolder in rootFolders)
            {
                TreeNode rootNode = new TreeNode(rootFolder.Name);
                folderTreeView.Nodes.Add(rootNode);
                AddSubFolders(rootNode, rootFolder.SubFolder);
            }
        }
        private void AddSubFolders(TreeNode parentNode, List<Folder> subFolders)
        {
            foreach(var folder in subFolders)
            {
                TreeNode childNode = new TreeNode(folder.Name);
                parentNode.Nodes.Add(childNode);
                AddSubFolders(childNode, folder.SubFolder);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("right test");
        }
        private void folderTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Implementation for the event handler
        }

        private void folderTreeView_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(folderTreeView, e.Location);

            }

        }

        private void folderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }
        private void AddDocumentMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("add document");
            using(AddDocumentForm addDocumentForm = new AddDocumentForm())
            {
                if(addDocumentForm.ShowDialog() == DialogResult.OK)
                {
                    string documentName = addDocumentForm.DocumentName;
                    string maritalStatus = addDocumentForm.MartialStatus;
                    string dateOfBirth = addDocumentForm.DateOfBirth;
                    string address = addDocumentForm.Address;
                    string phone = addDocumentForm.Phone;
                    /*Console.WriteLine("Document name: " + documentName);
                    Console.WriteLine("marital status:" + maritalStatus);
                    Console.WriteLine("date of birth:" + dateOfBirth);
                    Console.WriteLine("address:" + address);
                    Console.WriteLine("phone:" + phone);
                    */
                    string filePath = $"{documentName}.docx";
                    using(WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        Body body = new Body();

                        body.Append(new Paragraph(new Run(new Text($"Document Name: {documentName}"))));
                        body.Append(new Paragraph(new Run(new Text($"Marital Status: {maritalStatus}"))));
                        body.Append(new Paragraph(new Run(new Text($"Date of Birth: {dateOfBirth}"))));
                        body.Append(new Paragraph(new Run(new Text($"Address: {address}"))));
                        body.Append(new Paragraph(new Run(new Text($"Phone: {phone}"))));

                        mainPart.Document.Append(body);
                        mainPart.Document.Save();
                    }

                    Console.WriteLine($"Document '{filePath}' created");

                        if (folderTreeView.SelectedNode != null)
                    {
                        TreeNode selectedNode = folderTreeView.SelectedNode;
                        TreeNode newNode = new TreeNode(documentName);
                        newNode.Tag = filePath;
                        selectedNode.Nodes.Add(newNode);
                        selectedNode.Expand();
                    }
                    else
                    {
                        TreeNode newNode = new TreeNode(documentName);
                        newNode.Tag = filePath; //store the filepath as a tag so the event handler can process it
                        folderTreeView.Nodes.Add(newNode);
                    }
                    Process.Start(filePath);
                }
                
            }
        }

        private void RetrieveChildMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("retrieve child");
        }
        private void folderTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag != null)
            {
                string filePath = e.Node.Tag.ToString();
                Process.Start(filePath);
            }
        }
    }
}
