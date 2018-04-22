using EmployeesTest.Data.UnitOfWork;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeesTest.Data.Context;
using EmployeesTest.Helpers;

namespace EmployeesTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var unit = new UnitOfWork(new EmployeeContext()))
            {
                employeeBindingSource.DataSource = unit.Employee.GetAll().OrderByDescending(x => x.BornDate);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEmployee().ShowDialog();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var validate = ValidateAll();
            if (!string.IsNullOrWhiteSpace(validate))
            {
                MessageBox.Show(validate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(filter.Text))
            {
                LoadData();
            }
            else
            {
                using (var unit = new UnitOfWork(new EmployeeContext()))
                {
                    employeeBindingSource.DataSource = unit.Employee.Find(x => x.RFC == filter.Text).OrderBy(x => x.BornDate);
                }
            }
        }

        private string ValidateAll()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(filter.Text))
            {
                if (!filter.Text.IsRfcValid())
                {
                    sb.AppendLine("RFC is not formatted correctly");
                }
            }
            return sb.ToString();
        }

        private void btnFilterName_Click(object sender, EventArgs e)
        {
            using (var unit = new UnitOfWork(new EmployeeContext()))
            {
                employeeBindingSource.DataSource = unit.Employee.GetAll().OrderByDescending(x => x.Name);
            }
        }
    }
}
