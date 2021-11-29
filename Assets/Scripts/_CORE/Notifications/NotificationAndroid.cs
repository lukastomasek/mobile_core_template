using System;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

namespace Mobile_Core
{
    public class NotificationAndroid : MonoBehaviour
    {
        [SerializeField] int minutes;
        [SerializeField] int hours;
        [SerializeField] string smallIconId;
        [SerializeField] string largeIconId;

        const string _channel_id = "default_channel";

        int _identifier;

#if UNITY_ANDROID

        private void Start()
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = _channel_id,
                Name = "Default Channel",
                Description = "Generic Notifications",
                Importance = Importance.Default,
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);


            var notification = CreateNotification("Game Title", "Game Text", 12, 5);

            _identifier = AndroidNotificationCenter.SendNotification(notification, _channel_id);

            AndroidNotificationCenter.NotificationReceivedCallback receivedCallback =
                delegate (AndroidNotificationIntentData data)
                {
                    var msg = "Notification received : " + data.Id + "\n";
                    msg += "\n Notification received: ";
                    msg += "\n .Title: " + data.Notification.Title;
                    msg += "\n .Body: " + data.Notification.Text;
                    msg += "\n .Channel: " + data.Channel;
                    Debug.Log(msg);

                };

            AndroidNotificationCenter.OnNotificationReceived += receivedCallback;

            var notificationData = AndroidNotificationCenter.GetLastNotificationIntent();

            if (notificationData != null)
            {
                var id = notificationData.Id;
                var channelId = notificationData.Channel;
                var message = notificationData.Notification;

                Debug.Log($"id: {id} | channel: {channelId} | notification: {message}");
            }
        }


        private void OnApplicationPause(bool pause)
        {
            if (AndroidNotificationCenter.CheckScheduledNotificationStatus(_identifier)
                == NotificationStatus.Delivered)
            {
                AndroidNotificationCenter.CancelNotification(_identifier);
            }
            else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(_identifier)
                == NotificationStatus.Scheduled)
            {
                var notification = CreateNotification("Game Title", "Game Text", 12, 5);

                AndroidNotificationCenter.UpdateScheduledNotification(_identifier, notification, _channel_id);
            }
            else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(_identifier)
               == NotificationStatus.Unavailable)
            {
                Debug.LogWarning("notification unavialable!");
                return;
            }
            else
            {
                var notification = CreateNotification("Game Title", "Game Text", 12, 5);

                AndroidNotificationCenter.UpdateScheduledNotification(_identifier, notification, _channel_id);
            }
        }



        public AndroidNotification CreateNotification(string title, string text, int hours, int minutes)
        {
            var notification = new AndroidNotification()
            {
                Title = title,
                Text = text,
                FireTime = DateTime.Now.AddHours(hours).AddMinutes(minutes),
                SmallIcon = smallIconId,
                LargeIcon = largeIconId,

            };

            return notification;
        }
#endif
    }

}