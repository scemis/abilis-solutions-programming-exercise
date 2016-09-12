using AbilisSolutions.ProgrammingExercise.Domain;
using AbilisSolutions.ProgrammingExercise.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbilisSolutions.ProgrammingExercise.Web.Models
{
    public class MatrixViewModel
    {
        #region Public Properties
        public int MatrixSize { get; set; }
        public Enums.MatrixBase MatrixBase { get; set; }
        public MatrixModel Matrix { get; set; }
        public bool ShowPrimeNumbers { get; set; }
        #endregion
    }
}