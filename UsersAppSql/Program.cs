using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace UsersAppSql
{
    class Program
    {
        SqlConnection conn = null;

        public Program()
        {

            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=usersdb; Integrated Security=SSPI;");
        }
        static void Main(string[] args)
        {
            Program pr = new Program();

            //pr.InsertQutry("insert into Users (Name, Age) values ('Lubov','18')");
            pr.ReadData("select * from Users where Users.Age>18");
        }
        public void InsertQutry(string s)
        {
           
            try
            {
                conn.Open();

                string insertString1 = @""+s;
                SqlCommand cmd = new SqlCommand(insertString1, conn);
                cmd.ExecuteNonQuery();
               

            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        public void ReadData(string s)
        {
            SqlDataReader rdr = null;
            try
            {
                conn.Open();

                string insertString1 = @""+s;
                SqlCommand cmd = new SqlCommand(insertString1, conn);
                rdr = cmd.ExecuteReader();
                int line = 0;

                while (rdr.Read())
                {

                    if (line == 0)
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            Console.WriteLine(rdr.GetName(i).ToString() + " ");
                        }
                    Console.WriteLine();
                    line++;
                    Console.WriteLine(rdr[1] + " " + rdr[2]);
                }
                Console.WriteLine("Обработано записей: " + line.ToString());
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();

            }
        }
    }
}
