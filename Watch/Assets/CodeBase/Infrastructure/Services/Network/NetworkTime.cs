using System;
using System.Net;
using System.Net.Sockets;

namespace CodeBase.Infrastructure.Services.Network
{
    public class NetworkTime : INetworkTime
    {
        private readonly byte[] _ntpData = new byte[48];
        private EndPoint[] _endPoints;
        private Socket _socket;

        public void Initialize(string[] ntpServers)
        {
            _endPoints = new EndPoint[ntpServers.Length];

            for (var i = 0; i < ntpServers.Length; i++)
                _endPoints[i] = new IPEndPoint(Dns.GetHostEntry(ntpServers[i]).AddressList[0], 123);
        }

        public bool TryGetNetworkLocalTime(out TimeSpan time)
        {
            var milliseconds = 0ul;
            time = default;

            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                foreach (var endPoint in _endPoints)
                    milliseconds += GetNetworkTimeMilliseconds(endPoint, _socket);
            }
            catch
            {
                return false;
            }
            finally
            {
                _socket.Dispose();
            }

            milliseconds /= (ulong)_endPoints.Length;

            var networkDateTime = new DateTime(1900, 1, 1).AddMilliseconds(milliseconds);
            time = networkDateTime.ToLocalTime().TimeOfDay;

            return true;
        }

        private ulong GetNetworkTimeMilliseconds(EndPoint ipEndPoint, Socket socket)
        {
            _ntpData[0] = 0x1B;

            socket.Connect(ipEndPoint);
            socket.Send(_ntpData);
            socket.Receive(_ntpData);

            var intPart = (ulong)_ntpData[40] << 24 | (ulong)_ntpData[41] << 16 | (ulong)_ntpData[42] << 8 |
                          _ntpData[43];
            var fractPart = (ulong)_ntpData[44] << 24 | (ulong)_ntpData[45] << 16 | (ulong)_ntpData[46] << 8 |
                            _ntpData[47];

            return intPart * 1000 + fractPart * 1000 / 0x100000000L;
        }
    }
}