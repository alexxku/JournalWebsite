using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace JournalLibrary
{
    public class ViewJournals
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        static SqlConnection JournalWebsite = new SqlConnection(connection);



         public static List<JournalList> view (int LogID)
        {
            string SELECT = "SELECT J.JournalID, J.LogInID, J.Title, J.[Entry] FROM [User info] AS U INNER JOIN [Journal entry] AS J ON U.LogInID = J.LogInID WHERE J.LogInID = @logID";

            SqlCommand command = new SqlCommand(SELECT, JournalWebsite);
            command.Parameters.AddWithValue("@logID", LogID);
            JournalWebsite.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<JournalList> full = new List<JournalList>();

            while (reader.Read())
            {
                JournalList journal = new JournalList();
                journal.JournalID = (int)reader["JournalId"];
                journal.LogID = (int)reader["LogInID"];
                journal.Title = reader["Title"].ToString();
                journal.Entry = reader["Entry"].ToString();

                full.Add(journal);
            }
            JournalWebsite.Close();
            return full;
        }
    }
}
