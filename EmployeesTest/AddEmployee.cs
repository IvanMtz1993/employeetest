using System;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeesTest.Data.Context;
using EmployeesTest.Data.Models;
using EmployeesTest.Data.UnitOfWork;
using EmployeesTest.Helpers;

namespace EmployeesTest
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            LoadComboBoxStatusFromEnum();
            employeeBindingSource.DataSource = new Employee();
            
        }

        private void LoadComboBoxStatusFromEnum()
        {
            cmbStatus.DataSource = Enum.GetValues(typeof(EmployeeStatus));
        }

        private void button_Click(object sender, EventArgs e)
        {
            var validate = ValidateAll();
            if (!string.IsNullOrWhiteSpace(validate))
            {
                MessageBox.Show(validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            try
            {
                using (var unit = new UnitOfWork(new EmployeeContext()))
                {

                    var data = employeeBindingSource.Current as Employee;
                    data.BornDate = dtpDob.Value.Date;
                    unit.Employee.Add(data);
                    unit.SaveChanges();
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The RFC is already registered! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private string ValidateAll()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                sb.AppendLine("Name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(txtLastname.Text))
            {
                sb.AppendLine("Last Name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(txtRfc.Text))
            {
                sb.AppendLine("RFC cannot be empty");
            }

            if (!txtRfc.Text.IsRfcValid())
            {
                sb.AppendLine("RFC is not formatted correctly");
                txtRfc.Text = "";
            }

            return sb.ToString();
        }
    }
}
