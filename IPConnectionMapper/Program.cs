using System;
using System.Linq;
using Nmap.NET;
using Nmap.NET.Container;

namespace IPConnectionManager
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var target = new Target("127.0.0.1");
            Console.WriteLine("Initializing scan of {0}", target);
            ScanResult result = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan();
            Console.WriteLine("Detected {0} host(s), {1} up and {2} down.", result.Total, result.Up, result.Down);
        }
    }
}