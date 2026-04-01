    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOC;

public class EnumHelper
{

    public static T ParseEnum<T>(string input) where T : struct, Enum
    {
        if (int.TryParse(input, out int intValue) && Enum.IsDefined(typeof(T), intValue)) 
        {

            return (T)(object)intValue;

        } 

        if (Enum.TryParse(input, true, out T result))
        {
            return result;
        }

        throw new Exception($"Invalid {typeof(T).Name}");

    }

    public static T ReadEnum<T>(string message) where T : struct, Enum
    {
        Console.WriteLine(message);
        return EnumHelper.ParseEnum<T>(Console.ReadLine());
    }
}
