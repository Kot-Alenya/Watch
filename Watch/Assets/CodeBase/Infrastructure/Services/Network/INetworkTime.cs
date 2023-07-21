using System;

namespace CodeBase.Infrastructure.Services.Network
{
    public interface INetworkTime
    {
        public bool TryGetNetworkLocalTime(out TimeSpan time);
    }
}