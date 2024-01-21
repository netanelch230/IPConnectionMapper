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
            catch (ApplicationException ex)
            {
                if(ex.Message== "Path to nmap is invalid")
                {
                    //The console didn't update with the new value of PATH variable we added above,
                    //so we need to run the program again to get the new value. 
                    Console.WriteLine("The running of nmap failed, " +
                        "probably its because the path of exe file didn't exist on environment variables, " +
                        "run the program again can help ");
                }
                
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            
        }


        
    }
}