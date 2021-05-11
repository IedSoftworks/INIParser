using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace INIPass
{
    /// <summary>
    /// Contains the sections of a ini-file.
    /// </summary>
    public class INIFile : Dictionary<string, INISection>
    {
        /// <summary>
        /// This compiles the file into a string.
        /// </summary>
        /// <returns>The compiled string.</returns>
        public string Compile()
        {
            string text = "";

            foreach (KeyValuePair<string, INISection> keyValuePair in this)
            {
                text += $"[{keyValuePair.Key}]{Environment.NewLine}";
                foreach (KeyValuePair<string, INIKey> pair in keyValuePair.Value)
                {
                    foreach (INIValue iniValue in pair.Value)
                    {
                        text += $"{pair.Key}={iniValue.Data}{Environment.NewLine}";
                    }
                }

                text += Environment.NewLine;
            }

            return text;
        }

        /// <summary>
        /// Loads the file by using a file path.
        /// </summary>
        /// <param name="path">A path, where the file is located.</param>
        /// <returns>The decompiled file.</returns>
        public static INIFile Load(string path) => LoadData(File.ReadAllText(path));

        /// <summary>
        /// Loads the file by using a stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns>The decompiled file.</returns>
        public static INIFile Load(Stream stream) => LoadData(new StreamReader(stream).ReadToEnd());

        /// <summary>
        /// Loads the file by inserting the data directly.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The decompiled file.</returns>
        public static INIFile LoadData(string data)
        {
            string[] lines = data.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            INIFile file = new INIFile();
            INISection curSection = new INISection();

            foreach (string line in lines)
            {
                if (line.StartsWith("["))
                {
                    string sectionName = line.Replace('[', ' ').Replace(']', ' ').Trim();

                    curSection = new INISection();
                    file.Add(sectionName, curSection);

                    continue;
                }

                string[] keyValue = line.Split('=');

                INIKey key = curSection[keyValue[0]];

                if (keyValue[1] != string.Empty)
                {
                    string value = keyValue[1];
                    int index = keyValue[1].IndexOfAny(new char[] {'#', ';'});
                    if (index != -1) value = keyValue[1].Remove(index, keyValue[1].Length - index);

                    key.Add(new INIValue(value));
                }
            }

            return file;
        }
    }
}