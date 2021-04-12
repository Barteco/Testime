using System.Net;
using System.Net.Sockets;

namespace Testime.Automation.Internal
{
    internal static class EndpointHelper
    {
        public static string GenerateLocalEndpoint()
        {
            IPEndPoint defaultLoopbackEndpoint = new IPEndPoint(IPAddress.Loopback, 0);
        
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(defaultLoopbackEndpoint);
                return $"http://{socket.LocalEndPoint}";
            }
        }
    }
}
