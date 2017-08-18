using System.Collections.Generic;
using System.Web.Mvc;
using ViewFactoryExample.Entities;
using ViewFactoryExample.Factory;
using ViewFactoryExample.Others;
using ViewFactoryExample.ViewModels;

namespace ViewFactoryExample.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ViewModelFactory<IEnumerable<StudentViewModel>> _indexViewModelFactory;
        private readonly ViewModelFactory<StudentViewModel, Student> _detailViewModelFactory;

        public StudentsController(
            ViewModelFactory<IEnumerable<StudentViewModel>> indexViewModelFactory,
            ViewModelFactory<StudentViewModel, Student> detailViewModelFactory)
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
            var client = new StudentClient();
            var student = client.GetStudent(id);

            return View(_detailViewModelFactory.CreateView(student));
        }
    }
}