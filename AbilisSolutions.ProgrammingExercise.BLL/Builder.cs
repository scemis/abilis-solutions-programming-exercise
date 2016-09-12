using AbilisSolutions.ProgrammingExercise.Domain;
using AbilisSolutions.ProgrammingExercise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilisSolutions.ProgrammingExercise.BLL
{
    public class Builder
    {
        #region Public Methods
        /// <summary>
        /// Matrix Model Builder
        /// </summary>
        /// <param name="size">Matrix Size</param>
        /// <param name="format">Matrix Base</param>
        /// <returns>MatrixModel</returns>
        public static MatrixModel BuildMatrix(int size, Enums.MatrixBase format) {
            var result = new MatrixModel();

            // initialize matrix
            result.Data = new MatrixCellModel[size][];
            for(int i = 0; i < size; i++)
                result.Data[i] = new MatrixCellModel[size];

            // initialize cells
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    var x = i + 1;
                    var y = j + 1;
                    var baseValue = GetBaseValue(x, y);

                    result.Data[i][j] = new MatrixCellModel
                    {
                        BaseValue = baseValue,
                        DisplayValue = GetDisplayValue(baseValue, format),
                        DisplayX = GetDisplayValue(x, format),
                        DisplayY = GetDisplayValue(y, format),
                        Tooltip = GetTooltip(x, y),
                        IsPrime = IsPrime(baseValue)
                    };
                }

            return result;
        }

        public static async Task<MatrixModel> BuildMatrixAsync(int size, Enums.MatrixBase format)
        {
            var result = new MatrixModel();

            // initialize matrix
            result.Data = new MatrixCellModel[size][];
            for (int i = 0; i < size; i++)
                result.Data[i] = new MatrixCellModel[size];

            // initialize cells
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    var x = i + 1;
                    var y = j + 1;

                    var baseValue = await Task.Run(() => {
                        return GetBaseValue(x, y);
                    });

                    var displayValue = await Task.Run(() => {
                        return GetDisplayValue(baseValue, format);
                    });

                    var displayX = await Task.Run(() => {
                        return GetDisplayValue(x, format);
                    });

                    var displayY = await Task.Run(() => {
                        return GetDisplayValue(y, format);
                    });

                    var tooltip = await Task.Run(() => {
                        return GetTooltip(x, y);
                    });

                    var isPrime = await Task.Run(() => {
                        return IsPrime(baseValue);
                    });

                    result.Data[i][j] = new MatrixCellModel
                    {
                        BaseValue = baseValue,
                        DisplayValue = displayValue,
                        DisplayX = displayX,
                        DisplayY = displayY,
                        Tooltip = tooltip,
                        IsPrime = isPrime
                    };
                }

            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns multiplication base (decimal) value
        /// </summary>
        /// <param name="x">Left operand decimal format</param>
        /// <param name="y">Right operand decimal format</param>
        /// <returns>Int</returns>
        private static int GetBaseValue(int x, int y)
        {
            var result = x * y;
            return result;
        }
        /// <summary>
        /// Returns multiplication display value (decimal/hex/binary)
        /// </summary>
        /// <param name="baseValue">Base value decimal format</param>
        /// <param name="format">decimal/hex/binary</param>
        /// <returns>String</returns>
        private static string GetDisplayValue(int baseValue, Enums.MatrixBase format)
        {
            var result = String.Format("{0}", baseValue);

            switch (format)
            {
                case Enums.MatrixBase.Binary:
                    result = baseValue.ConvertToBinary();
                    break;
                case Enums.MatrixBase.Hex:
                    result = baseValue.ConvertToHex();
                    break;
                case Enums.MatrixBase.Decimal:
                default:
                    break;
            }

            return result;
        }
        /// <summary>
        /// Returns multiplication expression
        /// </summary>
        /// <param name="x">Left operand decimal format</param>
        /// <param name="y">Right operand decimal format</param>
        /// <returns>String</returns>
        private static string GetTooltip(int x, int y)
        {
            var result = String.Format("{0} x {1} = {2}", x, y, x*y);
            return result;
        }

        /// <summary>
        /// Checks if nimber is prime
        /// </summary>
        /// <param name="x">number</param>
        /// <returns>Boolean</returns>
        private static bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        #endregion

    }
}
