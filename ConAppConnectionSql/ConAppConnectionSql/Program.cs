using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ConAppConnectionSql
{
    internal class Program
    {

        static SqlDataReader reader;
        static SqlCommand cmd;
        static SqlConnection con;
        static string conStr = "server=SUMA\\MSSQLSERVER01;database=EmpsDb;trusted_connection=true;";
       

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("select * from Emps", con);
                con.Open();
                reader = cmd.ExecuteReader();
                Console.WriteLine("Id\t FirstName \t LastName \t Designation \t Salary");
                while (reader.Read())
                {
                    Console.Write(reader["Id"] + "    \t");
                    Console.Write(reader["Fname"] + "               \t");
                    Console.Write(reader["Lname"] + "         \t");
                    Console.Write(reader["Salary"] + "    \t");
                    Console.WriteLine(reader["designation"] + "      \t");
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
