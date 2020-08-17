using Microsoft.AspNetCore.Mvc;
using SistemaLojaMVC.Models;
using SistemaLojaMVC.ViewModels;

namespace SistemaLojaMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
           Pie pie = _pieRepository.GetPieById(pieId);

           if(pie != null)
           {
               _shoppingCart.AddToCart(pie);
           }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            Pie pie = _pieRepository.GetPieById(pieId);

            if (pie != null)
            {
                _shoppingCart.RemoveFromCart(pie);
            }

            return RedirectToAction("Index");
        }
    }
}
