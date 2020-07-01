using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Asset.Repository.UserAdmin
{
   public static class Conversion
    {
        public static TEn ConvertToEntity<TEn, T>(T classAdmin) where T : class
        {
            object value = classAdmin;
            return (TEn)Convert.ChangeType(value, typeof(TEn));

        }
        public static char[] ConvertfromNumtoBinaryCharArray(int num)
        {
            string res = Convert.ToString(num, 2);
            res = new string('0', 4 - res.Length) + res;

            string value = res;

            // Use ToCharArray to convert string to array.
            char[] array = value.ToCharArray();
            return array;
        }
        public static int ConvertBinaryStringtoInt(bool canView, bool canAdd, bool canEdit, bool canDelete)
        {
            char[] Array = new char[4];

            Array[0] = (canView == true) ? '1' : '0';
            Array[1] = (canAdd == true) ? '1' : '0';
            Array[2] = (canEdit == true) ? '1' : '0';
            Array[3] = (canDelete == true) ? '1' : '0';
            string inputVal = new string(Array);

            int intVal = Convert.ToInt32(inputVal, 2);
            return intVal;
        }

      
}
}
