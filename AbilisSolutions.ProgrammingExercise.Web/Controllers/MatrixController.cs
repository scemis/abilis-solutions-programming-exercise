using AbilisSolutions.ProgrammingExercise.BLL;
using AbilisSolutions.ProgrammingExercise.Domain;
using AbilisSolutions.ProgrammingExercise.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AbilisSolutions.ProgrammingExercise.Web;

namespace AbilisSolutions.ProgrammingExercise.Web.Controllers
{
    public class MatrixController : Controller
    {
        // GET: Matrix
        public ActionResult Index()
        {
            var model = new MatrixViewModel
            {
                MatrixSize = Global.MatrixSize,
                MatrixBase = Global.MatrixBase,
                ShowPrimeNumbers = Global.ShowPrimeNumbers
            };

            return View(model);
        }

        public async Task<ActionResult> GetMatrixAsync(GetMatrixArgs args)
        {
            var model = new MatrixViewModel
            {
                MatrixSize = args.MatrixSize,
                MatrixBase = args.MatrixBase,
                ShowPrimeNumbers = args.ShowPrimeNumbers
            };

            model.Matrix = await Builder.BuildMatrixAsync(model.MatrixSize, model.MatrixBase);
            var view = PartialView("partial/multiplication-table", model);

            return view;

        }
    }

    public class GetMatrixArgs
    {
        public int MatrixSize { get; set; }
        public Enums.MatrixBase MatrixBase { get; set; }
        public bool ShowPrimeNumbers { get; set; }
    }
}