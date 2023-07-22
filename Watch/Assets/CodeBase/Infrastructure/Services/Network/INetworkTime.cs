using System;

namespace CodeBase.Infrastructure.Services.Network
{
    public interface INetworkTime
    {
        public void Initialize(string[] ntpServers);

        public bool TryGetNetworkTime(out DateTime time);
    }
}