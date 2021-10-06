using System;
using System.Data.SqlClient;
using System.Text;

namespace prjLibaryTest
{
    public class Customer_Details
    {

        public Boolean CheckEmail(String strInput)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(strInput);
                return addr.Address == strInput;
            }
            catch
            {
                return false;
            }
        }
        public Boolean AddUserToDatabase(UserDetail user)
        {
            Connection c = new Connection();
            bool bcheck = false;
            SqlConnection conn = new SqlConnection(@"" + c.connection);
                       
            string sql = "INSERT INTO User (name, surname, password, email) values (@name, @surname, @password, @email)";
            conn.Open(); 
            SqlCommand command = new SqlCommand(sql, conn); 
            command.Parameters.AddWithValue("@name", user.getName());
            command.Parameters.AddWithValue("@surname", user.getSurname());
            command.Parameters.AddWithValue("@password", user.getPassword());
            command.Parameters.AddWithValue("@email", user.getEmail());
            conn.Open();
            int i = command.ExecuteNonQuery();
            conn.Close();

            if (i == -1)
            {
                bcheck = true;
            }
            return bcheck;
        }
        public UserDetail HashPassword(UserDetail user)
        {
            String strPassword = user.getPassword();
            user.setPassword(CreateMD5(strPassword));
            return user;
            
        }
        public String GetWelcomeMessage(UserDetail user)
        {
            string strName = user.getName();
            string strSurname = user.getSurname();
            string strWelcome = "Welcome " + strName + " " + strSurname;
            return strWelcome;
        }
        public Boolean CheckIfUserInDatabase(UserDetail user)
        {
            bool bcheck = false;
            SqlConnection conn = new SqlConnection();

            string sql = "Select * FROM User where email = @email";
            conn.Open();
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@email", user.getEmail());
            conn.Open();
            int i = command.ExecuteNonQuery();
            conn.Close();

            if (i >= 0)
            {
                bcheck = true;
            }
            return bcheck;
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
