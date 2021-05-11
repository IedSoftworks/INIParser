using System.Collections.Generic;

namespace INIPass
{
    /// <summary>
    /// Represents a section in a ini file.
    /// </summary>
    public class INISection : Dictionary<string, INIKey>
    {
        /// <summary>
        /// Gets a section.
        /// <para>If the selected section does not exist, it get created.</para>
        /// </summary>
        /// <param name="key"></param>
        public new INIKey this[string key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    INIKey iniKey = new INIKey();
                    base.Add(key, iniKey);
                    return iniKey;
                }

                return base[key];
            }
        }

        /// <summary>
        /// Adds a new key-value pair.
        /// <para>This can only add one value</para>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(string key, string value)
        {
            Add(key, new INIKey { new INIValue(value) });
        }

        /// <summary>
        /// Adds a new key with multiple values.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public void Add(string key, params string[] values)
        {
            Add(key, new INIKey { values });
        }
    }
}