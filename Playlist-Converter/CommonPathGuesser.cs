using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Playlist
{
    public static class CommonPathGuesser
    {
        public static string Path(string filepath, float confidence)
        {
            return Path(File.ReadAllLines(filepath), confidence);
        }

        public static string Path(string[] text, float confidence)
        {
            StringBuilder result = new StringBuilder();
            int index = 0;
            char leadChar = '/';

            while (true)
            {
                Dictionary<char, int> LetterCount = new Dictionary<char, int>();
                LetterCount[leadChar] = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i][index] == leadChar)
                    {
                        LetterCount[leadChar] += 1;
                    }
                    else
                    {
                        char altChar = text[i][index];
                        if (LetterCount.TryGetValue(altChar, out int counter))
                        {
                            LetterCount[altChar] = counter + 1;
                        }
                        else
                        {
                            LetterCount.Add(altChar, 0);
                        }
                        if (LetterCount[altChar] > LetterCount[leadChar])
                        {
                            leadChar = altChar;
                        }
                    }
                }

                if ((float)LetterCount[leadChar] / text.Length >= confidence)
                {
                    result.Append(leadChar);
                }
                else { break; }
                index++;
            }
            return result.ToString();
        }
    }
}
