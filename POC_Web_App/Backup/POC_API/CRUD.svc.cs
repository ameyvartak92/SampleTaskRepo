using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace POC_API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CRUD" in code, svc and config file together.
    public class CRUD : ICRUD
    {

        public static string connectionString()
        {
            // should be define in webconfig
            return "Data Source=103.241.181.75;Initial Catalog=Smartwash_DB;Persist Security Info=True;User ID=smartwash;Password=Welcome@123";
        }
        public bool AddnewStudent(string Name, string Address, string Contact, string Roll)
        {
            using (SqlConnection cn = new SqlConnection(CRUD.connectionString()))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO tblStudentInfo (studentName, studentAddress, studentContact, studentRollnumber) VALUES (@studentName, @studentAddress, @studentContact, @studentRollnumber)";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@studentName", Name);
                cmd.Parameters.AddWithValue("@studentAddress", Address);
                cmd.Parameters.AddWithValue("@studentContact", Contact);
                cmd.Parameters.AddWithValue("@studentRollnumber", Roll);

                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            return false;
        }

        public bool UpdateStudent(string id, string Name, string Address, string Contact, string Roll)
        {
            using (SqlConnection cn = new SqlConnection(CRUD.connectionString()))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE tblStudentInfo SET  studentName =@studentName, studentAddress =@studentAddress, studentContact =@studentContact, studentRollnumber =@studentRollnumber where studentid = @studentid";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@studentid", Convert.ToInt32( id));
                cmd.Parameters.AddWithValue("@studentName", Name);
                cmd.Parameters.AddWithValue("@studentAddress", Address);
                cmd.Parameters.AddWithValue("@studentContact", Contact);
                cmd.Parameters.AddWithValue("@studentRollnumber", Roll);

                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            return false;
        }

        public bool DeleteStudent(string studentid)
        {
            using (SqlConnection cn = new SqlConnection(CRUD.connectionString()))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM tblStudentInfo where studentid = @studentid";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@studentid", Convert.ToInt32( studentid));
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            return false;
        }

        public List<bizStudent> GetAllStudents()
        {
            List<bizStudent> students = new List<bizStudent>();
            using (SqlConnection cn = new SqlConnection(CRUD.connectionString()))
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandTimeout = 240;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  *  FROM tblStudentInfo";
                cmd.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.Dispose();

                if (!dt.HasErrors && dt != null)
                    foreach (DataRow row in dt.Rows)
                    {
                        students.Add(new bizStudent()
                                {
                                    id = Convert.ToInt32(row["studentid"]),
                                    Name = Convert.ToString(row["studentName"] != DBNull.Value ? row["studentName"].ToString() : string.Empty),
                                    Address = Convert.ToString(row["studentAddress"] != DBNull.Value ? row["studentAddress"].ToString() : string.Empty),
                                    Contact = Convert.ToString(row["studentContact"] != DBNull.Value ? row["studentContact"].ToString() : string.Empty),
                                    Roll = Convert.ToString(row["studentRollnumber"] != DBNull.Value ? row["studentRollnumber"].ToString() : string.Empty)

                                });
                    }

            }
            return students;
        }

        public List<bizStudent> GetAllStudents_startwith(string startwithName)
        {
            List<bizStudent> students = GetAllStudents();
            return students != null ? students.Where(a => a.Name.StartsWith(startwithName)).ToList<bizStudent>() : new List<bizStudent>();
        }
    }
}
