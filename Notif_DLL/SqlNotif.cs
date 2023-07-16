using Notif_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Notif_DLL
{
        public class SqlNotif
        {
            static string _connectionString = "Data Source=LAGADO17\\SQLEXPRESS;Initial Catalog=notifdatabase;Integrated Security=True";
            static SqlConnection sqlConnection;

            public SqlNotif()
            {

                sqlConnection = new SqlConnection(_connectionString);
            }

            public List<Notification> GetNotifications()
            {
                UserRepository userRepository = new UserRepository();
                var selectStatement = "SELECT StudentId, SenderId, ReceiverId, Content, DateTime FROM tblNotif";
                SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();

                List<Notification> notifications = new List<Notification>();

                while (reader.Read())
                {
                    notifications.Add(new Notification
                    {
                        StudentId = Convert.ToInt32(reader["StudentId"]),
                        senderName = userRepository.GetUserByName(reader.GetString(1)),
                        receiverName = userRepository.GetUserByName(reader.GetString(2)),
                        Content = reader.GetString(3),
                        DateTime = reader.GetDateTime(4),

                    });
                }

                sqlConnection.Close();

                return notifications;
            }

            public void Notifications(Notification notification)
            {
                var insertStatement = "INSERT INTO Notifications (StudentId, senderName, receiverName, Content, DateTime, IsRead) " +
                                      "VALUES (@StudentId, @senderName, @receiverName, @Content, @DateTime, )";
                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
                insertCommand.Parameters.AddWithValue("@StudentId", notification.StudentId);
                insertCommand.Parameters.AddWithValue("@senderName", notification.senderName);
                insertCommand.Parameters.AddWithValue("@receiverName", notification.receiverName);
                insertCommand.Parameters.AddWithValue("@Content", notification.Content);
                insertCommand.Parameters.AddWithValue("@DateTime", notification.DateTime);


                sqlConnection.Open();

                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    
}
