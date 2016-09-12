using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilisSolutions.ProgrammingExercise.Domain.Models
{
    public class MatrixCellModel
    {
        #region Public Properties
        public int BaseValue { get; set; }
        public string DisplayValue { get; set; }
        public string DisplayX { get; set; }
        public string DisplayY { get; set; }
        public string Tooltip { get; set; }
        public bool IsPrime { get; set; }
        #endregion
    }
}
