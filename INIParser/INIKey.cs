using System.Collections.Generic;

namespace INIPass
{
    /// <summary>
    /// Represents a key for a ini-file.
    /// <para>This can contains multiple values.</para>
    /// </summary>
    public class INIKey : List<INIValue>
    {
        /// <summary>
        /// Contains the first string of the key.
        /// </summary>
        public string FirstString => this[0].Data;

        /// <summary>
        /// Contains the first value of the key.
        /// </summary>
        public INIValue FirstValue => this[0];

        /// <summary>
        /// Adds a new value.
        /// </summary>
        public void Add(string value)
        {
            base.Add(new INIValue(value));
        }

        /// <summary>
        /// Adds multiple new values to the key.
        /// </summary>
        /// <param name="values"></param>
        public void Add(params string[] values)
        {
            foreach (string s in values)
            {
                Add(s);
            }
        }

        /// <summary>
        /// Converts a key into a string.
        /// </summary>
        /// <param name="key"></param>
        public static implicit operator string(INIKey key) => key.FirstString;
    }
}