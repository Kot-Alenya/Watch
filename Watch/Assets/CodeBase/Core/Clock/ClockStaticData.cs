using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Core.Clock
{
    [CreateAssetMenu(menuName = "Configuration/Clock", fileName = "ClockConfiguration")]
    public class ClockStaticData : ScriptableObject
    {
        [SerializeField] private string[] _ntpServers;
        [SerializeField] private float _timeToSyncWithNetworkInMinutes;

        public string[] NtpServers => _ntpServers;

        public float TimeToSyncWithNetworkInMinutes => _timeToSyncWithNetworkInMinutes;
    }
}