using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_21_2018
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = connectionString;

            List<ExerciseResult> students = new List<ExerciseResult>();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM ExerciseResults";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                ExerciseResult student = new ExerciseResult();
                student.Id = sqlDataReader.GetInt32(0);
                student.StudentName = sqlDataReader.GetString(1);
                student.StudentIndex = sqlDataReader.GetString(2);
                student.Points = sqlDataReader.GetInt32(3);
                students.Add(student);
            }

            foreach(ExerciseResult s in students)
            {
                listBoxExerciseResults.Items.Add(s.Id + ". " + s.StudentName + " " + s.StudentIndex + "  = " + s.Points);
            }

            sqlConnection.Close();
        }
    }
}
