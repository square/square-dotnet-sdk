using System.Collections.Generic;
using System;
using System.Linq;

namespace Square
{
    /// <summary>
    /// Available environments
    /// </summary>
    public enum Environment
    {
        Production,
        Sandbox,
    }
    /// <summary>
    /// Helper for the enum type Environment
    /// </summary>
    public static class EnvironmentHelper
    {
        //string values corresponding the enum elements
        private static readonly List<string> stringValues = new List<string> { "production", "sandbox" };

        /// <summary>
        /// Converts an Environment value to a corresponding string value
        /// </summary>
        /// <param name="enumValue">The Environment value to convert</param>
        /// <returns>The representative string value</returns>
        public static string ToValue(Environment enumValue)
        {
            switch(enumValue)
            {
                //only valid enum elements can be used
                //this is necessary to avoid errors
                case Environment.Production:
                case Environment.Sandbox:
                    return stringValues[(int)enumValue];

                //an invalid enum value was requested
                default:
                    return null;
            }
        }

        /// <summary>
        /// Convert a list of Environment values to a list of strings
        /// </summary>
        /// <param name="enumValues">The list of Environment values to convert</param>
        /// <returns>The list of representative string values</returns>
        public static List<string> ToValue(List<Environment> enumValues)
        {
            if (null == enumValues)
                return null;

            return enumValues.Select(eVal => ToValue(eVal)).ToList();
        }

        /// <summary>
        /// Converts a string value into Environment value
        /// </summary>
        /// <param name="value">The string value to parse</param>
        /// <returns>The parsed Environment value</returns>
        public static Environment ParseString(string value)
        {
            int index = stringValues.IndexOf(value);
            if(index < 0)
                throw new InvalidCastException(string.Format("Unable to cast value: {0} to type Environment", value));

            return (Environment) index;
        }
    }
}
