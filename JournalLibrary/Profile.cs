using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace JournalLibrary
{
    public class Profile
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=JournalWebsite;Integrated Security=True";
        static SqlConnection JournalWebsite = new SqlConnection(connection);
        public static User editProfile(User edit, int ID)
        {
            string SELECT = $"SELECT [LogInID], [UserName], [Password] FROM [User info] WHERE [LogInID] = @ID";

       
            SqlDataAdapter profile = new SqlDataAdapter(SELECT, JournalWebsite);

            profile.SelectCommand.Parameters.AddWithValue("@ID", ID);

            DataSet data = new DataSet();

            profile.Fill(data);

           
            string username = data.Tables[0].Rows[0]["UserName"].ToString();

            if (username == edit.UserName)
            {
                return null;
            }
            else if (edit.Password == "" || edit.Password.Length < 1)
            {
                return edit;
            }
            else
            {
                string UPDATE = $"UPDATE [User info] SET [UserName] = @UserName, [Password] = @Password WHERE [LogInID] = @logID";

                SqlCommand command = new SqlCommand(UPDATE, JournalWebsite);

                command.Parameters.AddWithValue("@UserName", edit.UserName);
                command.Parameters.AddWithValue("@Password", edit.Password);
                command.Parameters.AddWithValue("@logID", ID);

                JournalWebsite.Open();

                command.ExecuteNonQuery();

                JournalWebsite.Close();

                SqlDataAdapter newProfile = new SqlDataAdapter(SELECT, JournalWebsite);
                newProfile.SelectCommand.Parameters.AddWithValue("@ID", ID);

                DataSet updatedData = new DataSet();

                newProfile.Fill(updatedData);

                User updatedUser = new User();


                updatedUser.LoginId = (int)updatedData.Tables[0].Rows[0]["LogInID"];
                updatedUser.UserName = updatedData.Tables[0].Rows[0]["Username"].ToString();
                updatedUser.Password = updatedData.Tables[0].Rows[0]["Password"].ToString();
                
                return updatedUser;
            }
        }
    }
}