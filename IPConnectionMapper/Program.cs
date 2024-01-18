using System;
using System.Linq;
using Nmap.NET;
using Nmap.NET.Container;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Formats.Asn1;

namespace IPConnectionManager
{
    internal class Program
    {
        public static void Main()
        {
            var target = new Target("127.0.0.1");
            Console.WriteLine("Initializing scan of {0}", target);
            ScanResult result = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan();
            Console.WriteLine("Detected {0} host(s), {1} up and {2} down.", result.Total, result.Up, result.Down);
            JsonArray machines = new JsonArray();
            foreach (Host i in result.Hosts)
            {
                var ports = i.Ports.Select(p=>p.PortNumber).ToArray();   
                var machine = new JsonObject
                {
                    ["ip"] = i.Address.ToString(),
                    ["os"] = i.OsMatches.First().Name,
                    ["ports"] = JsonSerializer.Serialize(ports),
                };
                machines.Add(machine);
            }
            File.WriteAllText("Machines.json",machines.ToString());
        }
        
    }
}