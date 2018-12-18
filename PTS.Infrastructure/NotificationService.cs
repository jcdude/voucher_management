using PTS.Application.Interfaces;
using PTS.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace PTS.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
        {
            return Task.CompletedTask;
        }
    }
}
