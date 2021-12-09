using dbapp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace dbapp.Services
{
    public class CourseService
    {
        //private static string db_source = "sqldbpd.database.windows.net";
        //private static string db_user = "twenread";
        //private static string db_password = "Azure@123";
        //private static string db_database = "sqldatabase";


        //private SqlConnection GetConnection()
        //{
        //    var builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = db_source;
        //    builder.UserID = db_user;
        //    builder.Password = db_password;
        //    builder.InitialCatalog = db_database;
        //    return new SqlConnection(builder.ConnectionString);
        //}


        private SqlConnection GetConnection(string _connection_string)
        {
            // Here we are creating the SQL connection
            return new SqlConnection(_connection_string);
        }

        //public IEnumerable<Course> GetCourses()
        public IEnumerable<Course> GetCourses(string _connection_string)
        {
            List<Course> _lst = new List<Course>();
            string statement = "select * from course";
            //SqlConnection connection = GetConnection();
            SqlConnection connection = GetConnection(_connection_string);
            connection.Open();
            SqlCommand command = new SqlCommand(statement, connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseId = reader.GetInt32(0),
                        CourseName = reader.GetString(1),
                        Rating = reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            connection.Close();
            return _lst;
        }
    }
}
