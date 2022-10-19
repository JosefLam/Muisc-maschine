using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Muisc_maschine
{
    class Music
    {
        List<Note> Notes = new List<Note>();
        public void Play()
        {
            Console.WriteLine($"playing...");
            foreach(Note n in Notes)
            {
                n.Play();
            }
        }

        public int NoteToNumber(char noteName, bool flat, bool sharp,int octave)
        {
            int noteNumber = 0;
            switch (noteName)
            {
                case 'C':
                    noteNumber = 0;
                    break;
                case 'D':
                    noteNumber = 2;
                    break;
                case 'E':
                    noteNumber = 4;
                    break;
                case 'F':
                    noteNumber = 5;
                    break;
                case 'G':
                    noteNumber = 7;
                    break;
                case 'A':
                    noteNumber = 9;
                    break;
                case 'B':
                    noteNumber = 11;
                    break;




            }
            //decrease if flat
            if (flat)
            {
                noteNumber--;
            }
            if (sharp)
            {
                noteNumber++;
            }
            return noteNumber + (octave * 12);
        }


        public Music(string filename)
        {

            Console.WriteLine($"loading file from {filename}");
            //load from file
            string fileContents = File.ReadAllText(filename);

            // remove comments
            fileContents = Regex.Replace(fileContents, @"\/\/.*", "");

            int octave = 4;
            //xtract notes
            foreach (Match m in Regex.Matches(fileContents, @"([A-G])([b#])*(\d)*(:(\d))*"))
            {
                string note = m.Groups[1].Value;
                if (m.Groups[3].Value.Length >0)
                {
                    octave = int.Parse(m.Groups[3].Value);
                }

                //get flat or sharp
                bool flat = m.Groups[2].Value == "b";
                bool sharp = m.Groups[2].Value == "#";

                int number = NoteToNumber(note[0], flat, sharp, octave);


                Console.WriteLine($"Notes: {note} Octave: {octave}: Number: {number}");



            }

            



            Console.WriteLine(fileContents);
            

        }
    }
}
