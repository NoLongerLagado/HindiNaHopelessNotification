using Notif_Models;
using System;

namespace Notif_BLL
{
    public class NotificationManagement
    {
        static UserRepository _userRepository = new UserRepository();
        static NotificationRepository _notificationRepository = new NotificationRepository();

        public NotificationManagement()
        {
            _userRepository = new UserRepository();
            _notificationRepository = new NotificationRepository();
        }


        public void SendNotification(string senderName, string receiverName, string content)
        {

            var sender = _userRepository.GetUserByName(senderName);
            var receiver = _userRepository.GetUserByName(receiverName);

            if (sender != null && receiver != null)
            {
                var notification = new Notification
                {
                    senderName = sender,
                    receiverName = receiver,
                    Content = content,
                    DateTime = DateTime.Now,
                    IsRead = false
                };


                _notificationRepository.SaveNotification(notification);


            }
            else
            {


            }
        }
    }


}