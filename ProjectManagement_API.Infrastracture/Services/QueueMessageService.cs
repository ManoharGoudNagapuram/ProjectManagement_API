using Azure.Messaging.ServiceBus;
using ProjectManagement_API.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectManagement_API.Infrastracture.Services
{
    public class QueueMessageService : IQueueMessageService
    {
        private readonly ServiceBusSender _sender;

        public QueueMessageService(ServiceBusSender sender)
        {
            _sender = sender;
        }

        public async Task SendAsync<T>(
            T message,
            CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(message);

            var serviceBusMessage = new ServiceBusMessage(json)
            {
                ContentType = "application/json",
                MessageId = Guid.NewGuid().ToString()
            };

            await _sender.SendMessageAsync(
                serviceBusMessage,
                cancellationToken);
        }
       
    }
}
