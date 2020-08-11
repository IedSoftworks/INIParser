using System.Collections.Generic;

namespace INIParser
{
    public class INISection : Dictionary<string, INIKey>
    {
        public new INIKey this[string key]
        {
            get
            {
                if (!ContainsKey(key))
                {
                    INIKey iniKey = new INIKey();
                    Add(key, iniKey);
                    return iniKey;
                }

                return base[key];
            }
        }

        public void Add(string key, string value)
        {
            Add(key, new INIKey { new INIValue(value) });
        }
    }
}