using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose
{
    /// <summary>
    /// http://blog.spontaneouspublicity.com/associating-strings-with-enums-in-c
    /// </summary>
    public static class Tools
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static int GetEnumDescriptionEnh(Enum value)
        {
            string result = GetEnumDescription(value);


            if (int.TryParse(result, out int newresult))
                return newresult;

            return 50;
        }

    }
}
