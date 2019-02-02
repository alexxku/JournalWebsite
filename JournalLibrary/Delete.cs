using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace JournalLibrary
{
    public class Erase
    {

        static string connect = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
        public static SqlConnection JournalWebsite = new SqlConnection(connect);

        static public void delete(int ID)
        {
            string DELETE = "DELETE FROM [Journal entry] WHERE JournalID = @ID";

            SqlCommand command = new SqlCommand(DELETE, JournalWebsite);
            command.Parameters.AddWithValue("@ID", ID);

            JournalWebsite.Open();
            command.ExecuteNonQuery();
            JournalWebsite.Close();
        }
    }
}
