using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaLojaMVC.Models;
using SistemaLojaMVC.ViewModels;

namespace SistemaLojaMVC.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel
            {
                Pies = _pieRepository.AllPies,
                CurrentCategory = "Cheese cakes"
            };

            return View(piesListViewModel);

            /*
             antes: return View(_pieRepository.AllPies)
             */
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            
            if(pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
