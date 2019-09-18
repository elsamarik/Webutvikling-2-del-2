using Microsoft.AspNetCore.Mvc;
using NordiskLuksusMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NordiskLuksusMVC.Controllers{
    public class AdminProductController:Controller{

//setup og konstruktører
        private readonly NordiskLuksusContext _context;

        public AdminProductController(NordiskLuksusContext context){
            _context = context;
        }

        public async Task<IActionResult> AdminPage(int? id){
            List<Product> productList = await _context.Product.ToListAsync();
            return View(productList);
        } 


        public async Task<IActionResult> AllCustomerOrders(int? id){
            List<CustomerOrder> customerOrderList = await _context.CustomerOrder.ToListAsync();
            return View(customerOrderList);
        } 
    
        [HttpGet]
        public async Task<IActionResult> EditCustomerOrders(int id){
            CustomerOrder customerOrder = await _context.CustomerOrder.SingleOrDefaultAsync(_customerOrder => _customerOrder.ID == id);
            return View(customerOrder);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomerOrders(int id, [Bind("ID, AuthorName, Title, CustomerOrderText, Product, ProductID")] CustomerOrder customerOrder){

            _context.Update(customerOrder);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCustomerOrders));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCustomerOrders(int? id){
            CustomerOrder customerOrder = await _context.CustomerOrder.SingleOrDefaultAsync(_customerOrder => _customerOrder.ID == id);
            return View(customerOrder);
        }

        [HttpPost, ActionName("DeleteCustomerOrders")]
        public async Task<IActionResult> DeleteCustomerOrdersConfirm(int? id){
            CustomerOrder customerOrder = await _context.CustomerOrder.SingleOrDefaultAsync(_customerOrder => _customerOrder.ID == id);
            _context.CustomerOrder.Remove(customerOrder);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AllCustomerOrders));
        }
        
        [HttpGet]
        public async Task<IActionResult> EditProducts(int id){
            Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProducts(int id, [Bind("ID, ProductName")] Product product){
            
            _context.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminPage));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProducts(int? id){
            Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProducts")]
        public async Task<IActionResult> DeleteProductsConfirm(int? id){
            Product product = await _context.Product.SingleOrDefaultAsync(_product => _product.ID == id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminPage));
        }

         public IActionResult AddProducts(){
            return View();
        }   

         [HttpPost]
        public async Task<IActionResult> AddProducts([Bind("ID, ProductName")]Product product){
            if(ModelState.IsValid){
                _context.Product.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminPage));
            }else{
                return View(product);
            }
        }


    }
}