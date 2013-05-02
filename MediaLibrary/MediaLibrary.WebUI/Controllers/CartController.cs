using PirateThis.Domain.Abstract;
using PirateThis.Domain.Entities;
using PirateThis.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PirateThis.WebUI.Controllers
{
    public class CartController : Controller
    {
        private ISongRepository repository;

        public CartController(ISongRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int songId, string returnUrl)
        {
            Song song = repository.Songs
                .FirstOrDefault(s => s.SongID == songId);

            if (song != null)
            {
                cart.AddSong(song);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int songId, string returnUrl)
        {
            Song song = repository.Songs
                .FirstOrDefault(s => s.SongID == songId);

            if (song != null)
            {
                cart.RemoveLine(song);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, CustomerDetails customerDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(customerDetails);
            }
        }
        
        public ViewResult Checkout()
        {
            return View(new CustomerDetails());
        }
        
    }
}
