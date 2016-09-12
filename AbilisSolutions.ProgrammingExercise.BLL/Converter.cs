using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilisSolutions.ProgrammingExercise.BLL
{
    public static class Converter
    {
        #region Public Methods
        /// <summary>
        /// Returns value in hex format
        /// </summary>
        /// <param name="x">decimal</param>
        /// <returns></returns>
        public static string ConvertToHex(this int x)
        {
            var result = x.ToString("X");
            return result;
        }

        /// <summary>
        /// Returns value in binary format
        /// </summary>
        /// <param name="x">decimal</param>
        /// <returns></returns>
        public static string ConvertToBinary(this int x)
        {
            var result = Convert.ToString(x, 2);
            return result;
        }
        #endregion
    }
}
