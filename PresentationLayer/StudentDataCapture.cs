using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Group4_Project_PRG281.BusinessLogicLayer;
using Group4_Project_PRG281.DataAccessLayer;
using System.IO;
using System.Data.SqlClient;

namespace Group4_Project_PRG281.PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        DataHandler handler = new DataHandler();
        string g;
        
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = handler.getStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStudentNumber.Text);
            handler.delete(id);

            dataGridView2.DataSource = handler.getStudents();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(txtImageFilePath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string connect = "Server =.; Initial Catalog = BelgiumCampusCapture; Integrated Security = SSPI";
            string query = "insert into Students (StudentNumber,StudentNameSurname,StudentImage,DOB,Gender,Phone,Address,ModuleCodes)" +
                "values('"+this.txtStudentNumber.Text+ "', '"+this.txtStudentNameSurname.Text+ "', @IMG,'"+this.dateTimePicker1.Text+ "', '"+this.g+ "','"+this.txtPhone.Text+ "','"+this.txtAddress.Text+ "', '"+this.txtModuleCodes.Text+"')";
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@IMG", imageBt));
                myreader = cmd.ExecuteReader();
                MessageBox.Show("Student added and saved to database Successfully!");
                while(myreader.Read())
                {

                }
            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                txtImageFilePath.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void rdbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            g = "Male";
        }
        private void rdbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            g = "Female";
        }
        private void rdbtnOther_CheckedChanged(object sender, EventArgs e)
        {
            g = "Other";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            byte[] imageBt = null;
            FileStream fstream = new FileStream(txtImageFilePath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBt = br.ReadBytes((int)fstream.Length);

            string connect = "Server = .; Initial Catalog = BelgiumCampusCapture; Integrated Security = SSPI";
            string query = "update Students set StudentNameSurname = '" + this.txtStudentNameSurname.Text + "',StudentImage = @IMG, DOB = '" + this.dateTimePicker1.Text + "', Gender = '" + this.g + "', Phone = '" + this.txtPhone.Text + "', Address = '" + this.txtAddress.Text + "', ModuleCodes = '" + this.txtModuleCodes.Text + "' where StudentNumber = '" + this.txtStudentNumber.Text +"';";
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                cmd.Parameters.Add(new SqlParameter("@IMG", imageBt));
                myreader = cmd.ExecuteReader();
                MessageBox.Show("Student updated and saved to database Successfully!");
                while (myreader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModule_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModuleDataCapture form = new ModuleDataCapture();
            form.ShowDialog();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();
            Students student = new Students();
            student.StudentNumber1 = int.Parse(txtSearchStudent.Text);
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            dataGridView2.DataSource = handler.searchStudent(student.StudentNumber1);
        }
    }
}
