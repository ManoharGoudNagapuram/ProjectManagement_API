using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Core.Interfaces.Services
{
    public interface IQueueMessageService
    {
        Task SendAsync<T>(
       T message,
       CancellationToken cancellationToken = default);
    }
}

