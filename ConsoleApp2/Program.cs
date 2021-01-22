using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] fileEntries = Directory.GetDirectories(@"C:\10X\DCHUDrivers");

            using StreamWriter w = File.AppendText("output.txt");
            {
                foreach (string directory in fileEntries)
                {
                    string[] files = Directory.GetFiles(directory).Where(x => Path.GetExtension(x) == ".inf").ToArray();
                    foreach (string file in files)
                    {
                        w.WriteLine("<DriverPackageFile Path=\"" + directory + "\"" + $" Name=\"{Path.GetFileName(file)}\"/>");
                    }
                }
            }
        }
    }
}
