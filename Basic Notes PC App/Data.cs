using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Basic_Notes_PC_App
{
    public class Data
    {
        public static List<string> notes = new List<string> ();
        public static string notesFile;

        public static void readFile(string s) 
        {
            string [] noteArray = File.ReadAllLines(s);
            foreach (string line in noteArray)
            {
                notes.Add(line);
            }
        }

        public static void writeFile(string s)
        {
                File.WriteAllLines(s, notes.ToArray());
        }
    }
}
