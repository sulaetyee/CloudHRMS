using System.Net;
using System.Net.Sockets;

namespace CloudHRMS.Utility
{
    public static class NetworkHelper
    {
        public static string GetIpAddress()
        {
            string ip = "127.0.0.1";
            try
            {
                ip = new WebClient().DownloadString("https://api.ipify.org/");
            }
            catch (Exception ex)
            {
                ip = GetLocalIp();
            }
            return ip;
        }

        private static string GetLocalIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
                
            }
            return "We can't find Local IP Address.";

        }
    }
}
