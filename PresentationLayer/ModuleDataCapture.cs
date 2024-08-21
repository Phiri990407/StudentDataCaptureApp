using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group4_Project_PRG281.BusinessLogicLayer;
using System.Xml.Linq;
using Group4_Project_PRG281.DataAccessLayer;


namespace Group4_Project_PRG281.PresentationLayer
{
    public partial class ModuleDataCapture : Form
    {
        public ModuleDataCapture()
        {
            InitializeComponent();
        }
        DataHandler handler = new DataHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm form = new MainForm();
            form.ShowDialog();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = handler.getModules();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtModuleCode.Text;
            handler.deleteModule(id);

            dataGridView2.DataSource = handler.getModules();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modules m = new Modules(txtModuleCode.Text, txtModuleName.Text, txtModuleDescription.Text, txtResourceLink.Text);
            handler.UpdateModule(m);

            dataGridView2.DataSource = handler.getModules();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            Modules module = new Modules();
            module.ModuleCode1 = txtSearchModule.Text;
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            dataGridView2.DataSource = handler.searchModule(module.ModuleCode1);
        }
    }
}
