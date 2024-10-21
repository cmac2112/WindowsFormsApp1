using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddDocumentForm : Form
    {
        public string DocumentName { get; private set; }
        public string MartialStatus { get; private set; }
        public string DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public AddDocumentForm()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.textBoxDocumentName = new System.Windows.Forms.TextBox();
            this.textBoxMaritalStatus = new System.Windows.Forms.TextBox();
            this.textBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.textBoxMaritalStatus.Location = new System.Drawing.Point(12, 38);
            this.textBoxMaritalStatus.Name = "textBoxMaritalStatus";
            this.textBoxMaritalStatus.Size = new System.Drawing.Size(260, 20);
            this.textBoxMaritalStatus.TabIndex = 1;
       

            this.textBoxDateOfBirth.Location = new System.Drawing.Point(12, 64);
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(260, 20);
            this.textBoxDateOfBirth.TabIndex = 2;
           

            this.textBoxAddress.Location = new System.Drawing.Point(12, 90);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(260, 20);
            this.textBoxAddress.TabIndex = 3;
  

            this.textBoxPhone.Location = new System.Drawing.Point(12, 116);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(260, 20);
            this.textBoxPhone.TabIndex = 4;


            this.textBoxDocumentName.Location = new System.Drawing.Point(12, 12);
            this.textBoxDocumentName.Name = "textBoxDocumentName";
            this.textBoxDocumentName.Size = new System.Drawing.Size(260, 20);
            this.textBoxDocumentName.TabIndex = 0;

            this.buttonOK.Location = new System.Drawing.Point(116, 142);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            
            this.buttonCancel.Location = new System.Drawing.Point(197, 142);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            

            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxDocumentName);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxDateOfBirth);
            this.Controls.Add(this.textBoxMaritalStatus);
            this.Controls.Add(this.textBoxDocumentName);
            this.Name = "AddDocumentForm";
            this.Text = "Add Document";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            DocumentName = textBoxDocumentName.Text;
            MartialStatus = textBoxMaritalStatus.Text;
            DateOfBirth = textBoxDateOfBirth.Text;
            Address = textBoxAddress.Text;
            Phone = textBoxPhone.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private System.Windows.Forms.TextBox textBoxDocumentName;
        private System.Windows.Forms.TextBox textBoxMaritalStatus;
        private System.Windows.Forms.TextBox textBoxDateOfBirth;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}
