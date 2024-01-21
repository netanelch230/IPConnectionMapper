using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Nmap.NET;
using Nmap.NET.Container;
using Simple.DotNMap;

namespace IPConnectionManager
{
    internal class ConnectionMapper
    {
        public void Run()
        {
            SetNmapPathOnEnvironmentVariable();
            var ipAddressRange = GetIPRange();
            var target = new Target(ipAddressRange);
            Console.WriteLine("Initializing scan of {0}", target);
            
            var hosts = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).HostDiscovery();
            Console.WriteLine($"Found {hosts.Count()} machines");

            JsonArray machines = new JsonArray();
            foreach (Host host in hosts)
            {
                var machine = CreateMachine(host);
                
                if (machine != null) 
                    machines.Add(machine);
            }

            File.WriteAllText("Machines.json", machines.ToString());
        }
        private JsonObject CreateMachine(Host host)
        {
            try
            {
                var ports = host.Ports.Select(p => p.PortNumber).ToArray();
                var machine = new JsonObject
                {
                    ["ip"] = host.Address.ToString(),
                    ["os"] = !host.Hostnames.Any() ? "" : host.OsMatches.First().Name,
                    ["hostName"] = !host.Hostnames.Any() ? "" : host.Hostnames.First(),
                    ["ports"] = JsonSerializer.Serialize(ports),
                };
                return machine;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            
        }
        private string GetIPRange()
        {
            var ip = Dns.GetHostAddresses(Dns.GetHostName()).First(ip=>ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
            Console.WriteLine($"The ip address is: ${ip}");
            var index = ip.LastIndexOf('.');
            return ip.Substring(0, index)+".0/24";
        }

        private void SetNmapPathOnEnvironmentVariable()
        {
            var nMapPath = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%"), "nmap");

            // Get the current PATH variable
            string currentPath = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);

            // Append the new path if it doesn't already exist
            if (!currentPath.Contains(nMapPath))
            {
                string updatedPath = currentPath + Path.PathSeparator + nMapPath;

                // Set the updated PATH variable
                Environment.SetEnvironmentVariable("PATH", updatedPath, EnvironmentVariableTarget.Machine);

                Console.WriteLine($"Added {nMapPath} to PATH variable.");
            }
            else
            {
                Console.WriteLine($"{nMapPath} already exists in PATH variable.");
            }
        }
    }
}
