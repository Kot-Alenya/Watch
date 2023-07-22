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
            _networkTime.Initialize(_data.NtpServers);

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

        public void SetCurrentTime(TimeSpan time) => _currentTime = time;

        private void SetTimeToSynchronization() =>
            _timeToSyncWithNetwork = TimeSpan.FromMinutes(_data.TimeToSyncWithNetworkInMinutes);

        private void SyncWithNetwork()
        {
            if (_networkTime.TryGetNetworkTime(out var time))
                _currentTime = time.ToLocalTime().TimeOfDay;
        }
    }
}