using System.Collections.Generic;

namespace INIParser
{
    public class INIKey : List<INIValue>
    {
        public void Add(string value)
        {
            base.Add(new INIValue(value));
        }
    }
}