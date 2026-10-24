namespace StudentCrud
{
    partial class StudentCrud
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            pnlCard = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSubmit = new Button();
            cmbDepartment = new ComboBox();
            lblDept = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtId = new TextBox();
            lblId = new Label();
            dgvEmployees = new DataGridView();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(31, 58, 95);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(992, 80);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(37, 99, 235);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 76);
            panel2.Name = "panel2";
            panel2.Size = new Size(992, 4);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(325, 14);
            label1.Name = "label1";
            label1.Size = new Size(293, 46);
            label1.TabIndex = 0;
            label1.Text = "Employee Details";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(btnClear);
            pnlCard.Controls.Add(btnDelete);
            pnlCard.Controls.Add(btnUpdate);
            pnlCard.Controls.Add(btnSubmit);
            pnlCard.Controls.Add(cmbDepartment);
            pnlCard.Controls.Add(lblDept);
            pnlCard.Controls.Add(txtEmail);
            pnlCard.Controls.Add(lblEmail);
            pnlCard.Controls.Add(txtName);
            pnlCard.Controls.Add(lblName);
            pnlCard.Controls.Add(txtId);
            pnlCard.Controls.Add(lblId);
            pnlCard.Location = new Point(74, 100);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(836, 270);
            pnlCard.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.Cursor = Cursors.Hand;
            btnClear.Location = new Point(432, 190);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(124, 40);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(296, 190);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(124, 40);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Lime;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(160, 190);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(124, 40);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(24, 190);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(124, 40);
            btnSubmit.TabIndex = 9;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click_1;
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Items.AddRange(new object[] { "Human Resources", "Finance", "Engineering", "Marketing", "IT Support" });
            cmbDepartment.Location = new Point(432, 130);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(370, 31);
            cmbDepartment.TabIndex = 8;
            // 
            // lblDept
            // 
            lblDept.AutoSize = true;
            lblDept.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblDept.ForeColor = Color.FromArgb(55, 65, 81);
            lblDept.Location = new Point(432, 104);
            lblDept.Name = "lblDept";
            lblDept.Size = new Size(108, 23);
            lblDept.TabIndex = 7;
            lblDept.Text = "Department";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(24, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(370, 30);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(55, 65, 81);
            lblEmail.Location = new Point(24, 104);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 23);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email";
            // 
            // txtName
            // 
            txtName.Location = new Point(432, 44);
            txtName.Name = "txtName";
            txtName.Size = new Size(370, 30);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(55, 65, 81);
            lblName.Location = new Point(432, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(140, 23);
            lblName.TabIndex = 2;
            lblName.Text = "Employee Name";
            // 
            // txtId
            // 
            txtId.CausesValidation = false;
            txtId.Location = new Point(24, 44);
            txtId.Name = "txtId";
            txtId.Size = new Size(370, 30);
            txtId.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(55, 65, 81);
            lblId.Location = new Point(24, 18);
            lblId.Name = "lblId";
            lblId.Size = new Size(111, 23);
            lblId.TabIndex = 0;
            lblId.Text = "Employee ID";
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(74, 429);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(836, 250);
            dgvEmployees.TabIndex = 14;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.Location = new Point(74, 389);
            label2.Name = "label2";
            label2.Size = new Size(174, 25);
            label2.TabIndex = 15;
            label2.Text = "Employee Records";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 805);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(992, 26);
            statusStrip1.TabIndex = 16;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(151, 20);
            lblStatus.Text = "toolStripStatusLabel1";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(243, 245, 249);
            ClientSize = new Size(992, 831);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(dgvEmployees);
            Controls.Add(pnlCard);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button2;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel pnlCard;
        private Label lblId;
        private Label lblName;
        private TextBox txtId;
        private Label lblEmail;
        private TextBox txtName;
        private ComboBox cmbDepartment;
        private Label lblDept;
        private TextBox txtEmail;
        private DataGridView dgvEmployees;
        private Label label2;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnSubmit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}