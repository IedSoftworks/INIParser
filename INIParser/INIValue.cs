using System;
using System.Globalization;

namespace INIParser
{
    public class INIValue
    {
        private string _data = "";

        public string Data
        {
            get => _data;
            set
            {
                _data = value;
                CheckCastables();
            }
        }

        public bool? BoolData { get; private set; }
        public float? FloatData { get; private set; }

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
    }
}