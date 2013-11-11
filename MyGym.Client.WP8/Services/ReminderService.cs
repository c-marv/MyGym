using Microsoft.Phone.Scheduler;
using MyGym.Client.WP8.Models;
using MyGym.Client.WP8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Services
{
    public class ReminderService : IReminderService
    {
        public bool IsScheduled(string name)
        {
            var schedule = ScheduledActionService.Find(name);
            if (schedule == null)
            {
                return false;
            }
            else
            {
                return schedule.IsScheduled;
            }
        }

        public void SetReminder(RecipeDataItem item)
        {
            if (!IsScheduled(item.UniqueId))
            {
                var schedule = ScheduledActionService.Find(item.UniqueId);
                if (null != schedule)
                    ScheduledActionService.Remove(schedule.Name);

                Microsoft.Phone.Scheduler.Reminder reminder = new Microsoft.Phone.Scheduler.Reminder(item.UniqueId);
                reminder.Title = item.Title;
                reminder.Content = "Has terminado de cocinar?";

                if (System.Diagnostics.Debugger.IsAttached)
                    reminder.BeginTime = DateTime.Now.AddSeconds(30);
                else
                    reminder.BeginTime = DateTime.Now.Add(TimeSpan.FromMinutes(Convert.ToDouble(item.PrepTime)));

                reminder.ExpirationTime = reminder.BeginTime.AddSeconds(30);
                reminder.RecurrenceType = RecurrenceInterval.None;
                reminder.NavigationUri = new Uri("../View/RecipeDetailPage.xaml?ID=" + item.UniqueId + "&GID=" + item.Group.UniqueId, UriKind.Relative);

                ScheduledActionService.Add(reminder);
            }
            else
            {
                var schedule = ScheduledActionService.Find(item.UniqueId);
                ScheduledActionService.Remove(schedule.Name);
            }
        }
    }
}
