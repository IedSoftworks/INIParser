using System;
using System.Globalization;

namespace INIPass
{
    /// <summary>
    /// This contains the actual value.
    /// </summary>
    public class INIValue
    {
        private string _data = "";

        /// <summary>
        /// The data itself in string format.
        /// </summary>
        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                CheckCastables();
            }
        }

        /// <summary>
        /// If the data can be parsed to a bool, it can be found here.
        /// </summary>
        public bool? BoolData { get; private set; }
        /// <summary>
        /// If the data can be parsed to a number, it can be found here.
        /// </summary>
        public float? FloatData { get; private set; }

        /// <summary>
        /// Creates the value with the data.
        /// </summary>
        /// <param name="data"></param>
        public INIValue(string data = default)
        {
            Data = data;
        }

        private void CheckCastables()
        {
            if (Boolean.TryParse(_data, out bool result))
            {
                BoolData = result;
                return;
            }
            BoolData = null;

            if (float.TryParse(_data, NumberStyles.Any, CultureInfo.GetCultureInfo("en-GB"), out float floatResult))
            {
                FloatData = floatResult;
                return;
            }

            FloatData = null;
        }

        /// <summary>
        /// Converts a ini-value into a string.
        /// </summary>
        public static implicit operator string(INIValue value) => value;
    }
}