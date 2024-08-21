using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Collections;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using Group4_Project_PRG281.BusinessLogicLayer;
using Group4_Project_PRG281.PresentationLayer;

namespace Group4_Project_PRG281.DataAccessLayer
{
    internal class DataHandler
    {
        string path = "users.txt";
        string connect = "Server = DESKTOP-BTLFI4H\\SQLEXPRESS ; Initial Catalog = BelgiumCampusCapture; Integrated Security = SSPI";
        string query;
        SqlDataAdapter adapter;
        DataTable table;

        public bool LoginAuthenticator(string username, string password)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 2)
                {
                    string storedUsername = parts[0].Trim();
                    string storedPassword = parts[1].Trim();

                    if (username == storedUsername && password == storedPassword)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UsernameExists(string username)
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length > 0)
                {
                    string storedUsername = parts[0].Trim();

                    if (username == storedUsername)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void UserRegisteration(string username, string password)
        {
            File.AppendAllText(path, $"{username},{password}{Environment.NewLine}");
        }
        public DataTable getStudents()
        {
            string query = @"SELECT * FROM Students";
            adapter = new SqlDataAdapter(query, connect);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void delete(int stdNo)
        {
            string query = $"DELETE FROM Students WHERE StudentNumber = '{stdNo}'";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show($"Data for student {stdNo} deleted successfully");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public void Insert(Students s)
        {
            
            query = $"INSERT INTO Students VALUES\r\n(StudentNumber = '{s.StudentNumber1}', StudentNameSurname = '{s.StudentNameSurname1}', StudentImage = '{s.StudentImage1}', DOB = '{s.DOB1}', Gender = '{s.Gender1}', Phone = '{s.Phone1}', Address = '{s.Address1}', ModuleCodes = '{s.ModuleCodes1}');";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("The new student has been entered into the Student table.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable getModules()
        {
            string query = @"SELECT * FROM Modules";
            adapter = new SqlDataAdapter(query, connect);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void deleteModule(string mdlCode)
        {
            string query = $"DELETE FROM Modules WHERE ModuleCode = '{mdlCode}'";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show($"Data for student {mdlCode} deleted successfully");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateModule(Modules m)
        {
            query = $"UPDATE Modules\r\nSET ModuleName = '{m.ModuleName1}', ModuleDescription = '{m.ModuleDescription1}', OnlineResourcesLink = '{m.OnlineResourcesLink1}'\r\nWHERE ModuleCode = '{m.ModuleCode1}';";
            try
            {
                using (SqlConnection con = new SqlConnection(connect))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Module table has been Updated.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataTable searchModule(string mdlCode)
        {
            string query = $"SELECT * FROM Modules WHERE ModuleCode = '{mdlCode}'";
            adapter = new SqlDataAdapter(query, connect);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable searchStudent(int stdNo)
        {
            string query = $"SELECT * FROM Students WHERE StudentNumber = '{stdNo}'";
            adapter = new SqlDataAdapter(query, connect);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }



    }
}
