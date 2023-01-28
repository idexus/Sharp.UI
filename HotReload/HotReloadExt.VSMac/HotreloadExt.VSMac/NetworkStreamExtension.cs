using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CA1416

namespace HotReload
{
	public static class NetworkStreamExtension
	{
        public static async Task<string> ReadStringAsync(this NetworkStream stream, CancellationToken cancellationToken = default)
        {
            var buffer = new byte[1_024];
            int received = await stream.ReadAsync(buffer, cancellationToken);
            var message = Encoding.UTF8.GetString(buffer, 0, received);
            var zeroId = message.IndexOf('\0');
            return message.Substring(0, zeroId);
        }
    }
}

#pragma warning restore CA1416
