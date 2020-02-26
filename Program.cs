using System;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace SprinxApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = GetConfiguration("appSettings.json");
            
            var serverNames = appSettings["files"].Split(';')           //ziskame jednotive soubory s connection stringy
                        .SelectMany(x => GetConnectionStrings(x))       //vsechny connection stringy v jednom poli
                        .SelectMany(x => x.Split(';'))                  //jednotlive polozky vsech connection stringu v jednom poli
                        .Where(y => y.Contains("Server="))              //vyfiltrovane pouze polozky obsahujici nazev serveru
                        .Select(z => z.Split('=')[1])                   //ponechan pouze nazev serveru
                        .ToArray();

            Console.WriteLine(string.Join('\n', serverNames));
            Console.Read();
        }

        private static string [] GetConnectionStrings(string file) {
            return GetConfiguration(file)["connections"].Split('|');        
        }

        private static IConfiguration GetConfiguration(string file) {
            return new ConfigurationBuilder()
            .AddJsonFile(file, true, true)
            .Build();
        }

    }

}
