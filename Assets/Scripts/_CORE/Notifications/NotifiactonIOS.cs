using System;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif



namespace Mobile_Core
{
    public class NotifiactonIOS : MonoBehaviour
    {
#if UNITY_IOS

        [SerializeField] string notificationId = "ios_notification";

        [Header("TIMERS")]
        [SerializeField] int notificationTimerPerHour = 12;
        [SerializeField] int notificationTimerPerMinutes = 5;


        private void Start()
        {
            var timeTrigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new TimeSpan(0, 0, 10),
                Repeats = false,
            };

            var calendar = new iOSNotificationCalendarTrigger()
            {
                Hour = notificationTimerPerHour,
                Minute = notificationTimerPerMinutes,
                Repeats = true,
            };

            var notification = new iOSNotification()
            {
                Identifier = notificationId,
                Title = "some title",
                Subtitle = "some sub heading",
                Body = "description",
                ShowInForeground = true,
                ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Sound | PresentationOption.Badge,
                CategoryIdentifier = "category_a",
                ThreadIdentifier = "thread1",
                Trigger = calendar,
            };

            iOSNotificationCenter.ScheduleNotification(notification);

            iOSNotificationCenter.OnNotificationReceived += recieved =>
            {
                var timeTriggger = new iOSNotificationTimeIntervalTrigger()
                {
                    TimeInterval = new TimeSpan(0, 2, 0)
                };

                //CreateNotification(notificationId, "some title", "sub", "descr",);
            };
        }


        public iOSNotification CreateNotification(string id, string title, string subTitle, string body
         ,iOSNotificationCalendarTrigger calendarTrigger,
          string categoryId = "category_a", string thread = "thread1", bool isForeground = true)
        {
            var notification = new iOSNotification()
            {
                Identifier = id,
                Title = title,
                Subtitle = subTitle,
                Body = body,
                ShowInForeground = isForeground,
                ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Sound | PresentationOption.Badge,
                CategoryIdentifier = categoryId,
                ThreadIdentifier = thread,
                Trigger = calendarTrigger,
            };


            return notification;
        }
    }

#endif
}

