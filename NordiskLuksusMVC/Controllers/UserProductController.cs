using Microsoft.AspNetCore.Mvc;
using NordiskLuksusMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NordiskLuksusMVC.Controllers{
    public class UserProductController:Controller{

        private readonly NordiskLuksusContext _context;

        public UserProductController(NordiskLuksusContext context){
            _context = context;
        }
        public IActionResult WriteCustomerOrders(){
            return View();
        }   

         [HttpPost]
        public async Task<IActionResult> WriteCustomerOrders([Bind("ID, AuthorName, Title, CustomerOrderText, Product, ProductID")]CustomerOrder customerOrder){
            if(ModelState.IsValid){
                _context.CustomerOrder.Add(customerOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowProducts));
            }else{
                return View(customerOrder);
            }
        }

        public async Task<IActionResult> ShowProducts(){
            List<Product> productList = await _context.Product.ToListAsync();
            return View(productList);
        }

    [HttpGet]
        public async Task<IActionResult> ShowCustomerOrders(int? id){
            Product list = await _context.Product.Include("CustomerOrder").SingleOrDefaultAsync(_product => _product.ID == id);
            return View(list);
        }

    }
}