using System.Collections.Generic;
using System.Web.Mvc;
using ViewFactoryExample.Factory;
using ViewFactoryExample.ViewModels;

namespace ViewFactoryExample.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ViewModelFactory<IEnumerable<StudentViewModel>> _indexViewModelFactory;
        private readonly ViewModelFactory<StudentViewModel, int> _detailViewModelFactory;

        public StudentsController(
            ViewModelFactory<IEnumerable<StudentViewModel>> indexViewModelFactory,
            ViewModelFactory<StudentViewModel, int> detailViewModelFactory)
        {
            _indexViewModelFactory = indexViewModelFactory;
            _detailViewModelFactory = detailViewModelFactory;
        }

        public ActionResult Index()
        {
            return View(_indexViewModelFactory.CreateView());
        }

        public ActionResult Detail(int id)
        {
            return View(_detailViewModelFactory.CreateView(id));
        }
    }
}