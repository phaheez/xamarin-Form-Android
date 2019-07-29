using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld.Helpers
{
    public static class Connectivity
    {
        public static bool CheckConnectivity()
        {
            var isConnected = CrossConnectivity.Current .IsConnected;
            return isConnected == true ? true : false;
        }
    }
}
