using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;

namespace EmailService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> ids = new List<string>();
                List<string> emails = new List<string>();

                var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MMMTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //string parameter = "";

                    string query = @"SELECT * FROM [MMMTestDB].[dbo].[AspNetUsers]";
                    //string where = " WHERE parameter = @ParameterName"
                    SqlCommand command = new SqlCommand(query, connection);
                    //command.Parameters.AddWithValue("@ParameterName", parameter);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(reader["Id"].ToString());
                            emails.Add(reader["NormalizedEmail"].ToString());
                            
                        }

                        connection.Close();
                    }
                };


                for (int i = 0; i < ids.Count; i++)
                {
                    string id = ids[i];
                    string email = emails[i];
                    SendEmail(id, email);
                }

            }

            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SendEmail(string id, string email)
        {

            SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");

            // set smtp-client with basicAuthentication
            mySmtpClient.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new
               System.Net.NetworkCredential("bainter92x@gmail.com", "X29Retniab!@#$");
            mySmtpClient.Credentials = basicAuthenticationInfo;
            mySmtpClient.EnableSsl = true;
            // add from,to mailaddresses
            MailAddress from = new MailAddress("bainter92x@gmail.com");
            MailAddress to = new MailAddress(email);
            MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

            // add ReplyTo
            MailAddress replyto = new MailAddress("reply@example.com");
            myMail.ReplyToList.Add(replyto);

            // set subject and encoding
            myMail.Subject = "MyMedsManager";
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;

            // set body-message and encoding
            List<string> userIds = new List<string>();
            List<string> medicines = new List<string>();
            List<String> medQuantity = new List<String>();
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MMMTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //string parameter = "";

                string query = @"SELECT * FROM [MMMTestDB].[dbo].[Medication]";
                //string where = " WHERE parameter = @ParameterName"
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@ParameterName", parameter);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userIds.Add(reader["UserId"].ToString());
                        medicines.Add(reader["Medicine"].ToString());
                        medQuantity.Add(reader["MedQuantity"].ToString());
                    }

                    connection.Close();
                }
            };

            for (int i = 0; i < userIds.Count; i++)
            {
                if (userIds[i] == id)
                {
                    string medicine = medicines[i];
                    string medQty = medQuantity[i];
                    myMail.Body += $"You have {medQty} {medicine} left. ";
                }
            }

            //myMail.Body = "<b>Test Mail</b><br>using <b>HTML</b>.";
            myMail.BodyEncoding = System.Text.Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = false;

            mySmtpClient.Send(myMail);
        }

    }
}
