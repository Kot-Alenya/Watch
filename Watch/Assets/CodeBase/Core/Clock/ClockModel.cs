using CodeBase.Infrastructure.Services.Network;
using System;

namespace CodeBase.Core.Clock
{
    public class ClockModel
    {
        private readonly INetworkTime _networkTime;
        private readonly ClockStaticData _data;

        private TimeSpan _timeToSyncWithNetwork;
        private TimeSpan _currentTime;

        public ClockModel(ClockStaticData data, INetworkTime networkTime)
        {
            _networkTime = networkTime;
            _data = data;
        }

        public void Initialize()
        {
            SetTimeToSynchronization();
            SyncWithNetwork();
        }

        public void Update(TimeSpan deltaTime)
        {
            if (_timeToSyncWithNetwork.TotalMilliseconds < 0)
            {
                SetTimeToSynchronization();
                SyncWithNetwork();
            }
            else
            {
                _timeToSyncWithNetwork -= deltaTime;
                _currentTime += deltaTime;
            }
        }

        public TimeSpan GetCurrentTime() => _currentTime;

        private void SetTimeToSynchronization() =>
            _timeToSyncWithNetwork = TimeSpan.FromMinutes(_data.TimeToSyncWithNetworkInMinutes);

        private void SyncWithNetwork()
        {
            if (_networkTime.TryGetNetworkLocalTime(out var time))
                _currentTime = time;
        }
    }
}