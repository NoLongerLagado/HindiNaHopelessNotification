using Notif_BLL;
using System;
using System.Configuration;
using System.Linq;

namespace NotificationInterface
{


    public class Program
    {
        private static NotificationManagement _notificationManagement;
        private static string senderName, receiverName, content;

        static void Main()
        {
            _notificationManagement = new NotificationManagement();

            Console.WriteLine("Notification System!");

            while (true)
            {

                if (NotificationManagement.NotificationMarketPlace(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}");
                    Console.WriteLine(receiverName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();

                }
                else if (NotificationManagement.ReactPost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}");
                    Console.WriteLine(senderName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiverName);
                }
                else if (NotificationManagement.NewPost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}");
                    Console.WriteLine(senderName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiverName);
                }
                else if (NotificationManagement.SharePost(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}");
                    Console.WriteLine(senderName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiverName);
                }
                else if (NotificationManagement.Attendance(GetUserByName))
                {
                    Console.WriteLine($"Date : {DateTime.Now}");
                    Console.WriteLine(senderName);
                    Console.WriteLine("Enter notification content:");
                    string content = Console.ReadLine();
                    Console.WriteLine(receiverName);
                }





                _notificationManagement.SendNotification(senderName, receiverName, content);

                Console.WriteLine("Notification sent successfully!");
                Console.WriteLine("Press Enter to send another notification or press any other key to exit.");

                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;

                Console.WriteLine();
            }
        }
    }

}