using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace StudentCrud
{
    public partial class StudentCrud : Form
    {
        private readonly EmployeeRepository repo = new EmployeeRepository();

        public StudentCrud()
        {
            InitializeComponent();
            StyleButtons();
            StyleGrid();

            try
            {
                repo.EnsureDatabase();   // creates DB + table on first run
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Styling ----------
        private void StyleButton(Button b, Color back, Color fore, bool outline = false)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = back;
            b.ForeColor = fore;
            b.Cursor = Cursors.Hand;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.FlatAppearance.BorderSize = outline ? 1 : 0;
            if (outline) b.FlatAppearance.BorderColor = Color.FromArgb(197, 205, 217);
        }

        private void StyleButtons()
        {
            StyleButton(btnSubmit, ColorTranslator.FromHtml("#2563EB"), Color.White);
            StyleButton(btnUpdate, ColorTranslator.FromHtml("#16A34A"), Color.White);
            StyleButton(btnDelete, ColorTranslator.FromHtml("#DC2626"), Color.White);
            StyleButton(btnClear, Color.White, Color.FromArgb(55, 65, 81), true);
        }

        private void StyleGrid()
        {
            var g = dgvEmployees;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Color.White;
            g.EnableHeadersVisualStyles = false;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.ReadOnly = true;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.RowTemplate.Height = 36;
            g.ColumnHeadersHeight = 38;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.GridColor = Color.FromArgb(221, 227, 236);
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 58, 95);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            g.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        // ---------- Helpers ----------
        private void LoadGrid()
        {
            dgvEmployees.DataSource = repo.GetAll();
            lblStatus.Text = $"Total records: {dgvEmployees.Rows.Count}";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbDepartment.SelectedIndex < 0)
            {
                MessageBox.Show("Please fill in all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Enter a valid email address.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtEmail.Clear();
            cmbDepartment.SelectedIndex = -1;
            txtId.ReadOnly = false;
            dgvEmployees.ClearSelection();
            txtId.Focus();
        }

        private static bool IsDuplicateError(SqlException ex) =>
            ex.Number == 2627 || ex.Number == 2601;

        // ---------- Events ----------
        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                if (repo.Exists(txtId.Text.Trim()))
                {
                    MessageBox.Show("This Employee ID already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                repo.Insert(txtId.Text.Trim(), txtName.Text.Trim(),
                            txtEmail.Text.Trim(), cmbDepartment.Text);
                MessageBox.Show("Employee added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadGrid();
            }
            catch (SqlException ex) when (IsDuplicateError(ex))
            {
                MessageBox.Show("This email is already used by another employee.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvEmployees.Rows[e.RowIndex];
            txtId.Text = row.Cells["ID"].Value?.ToString();
            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            cmbDepartment.Text = row.Cells["Department"].Value?.ToString();
            txtId.ReadOnly = true;   // ID is the primary key
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Select a record from the grid first.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInputs()) return;

            try
            {
                int rows = repo.Update(txtId.Text.Trim(), txtName.Text.Trim(),
                                       txtEmail.Text.Trim(), cmbDepartment.Text);
                if (rows == 0)
                {
                    MessageBox.Show("Record not found.", "Update",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Employee updated successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadGrid();
            }
            catch (SqlException ex) when (IsDuplicateError(ex))
            {
                MessageBox.Show("This email is already used by another employee.", "Duplicate",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Select a record from the grid first.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Delete this employee record?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                repo.Delete(txtId.Text.Trim());
                ClearFields();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        //private void btnUpdate_Click_1(object sender, EventArgs e)
        //{

        //}

        //private void btnSubmit_Click_1(object sender, EventArgs e)
        //{

        //}
    }
}