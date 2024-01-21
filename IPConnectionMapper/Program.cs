using System;
using System.Linq;
using Nmap.NET;
using Nmap.NET.Container;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Formats.Asn1;
using System.Net;

namespace IPConnectionManager
{
    internal class Program
    {
        public static void Main()
        {
            try
            {
                ConnectionMapper mapper = new ConnectionMapper();
                mapper.Run();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
            
        }


        
    }
}