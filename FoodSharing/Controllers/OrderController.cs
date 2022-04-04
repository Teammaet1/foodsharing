
using FoodSharing.Domain;
using FoodSharing.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSharing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataManager dataManager;

        public OrderController(DataManager dataManager, UserManager<ApplicationUser> userMgr)
        {
            this.dataManager = dataManager;
            userManager = userMgr;
        }

        [HttpGet("{id}")]
        public Order GetOrder(Guid Id)
        {
            // var idUser = User.FindFirst(x => x.Type == "id").Value;
            // var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).FirstOrDefault(x => x.Id == idUser);

           // var order = dataManager.order.GetOrders().ToList();
            // if(user.Orders.FirstOrDefault(x => x.Id == order.Id) != null)
           // return order;
            //  return new List<Product>();

            var id = User.FindFirst(x => x.Type == "id").Value;
            var order = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).Include(x => x.Orders).ThenInclude(x => x.Products)
                .FirstOrDefault(x => x.Id == id).Orders.FirstOrDefault(x => x.Id == Id);
            order.Products.ForEach(x => x.Orders = null);
            return order;
        }

        [HttpGet("done/{id}")]
        public IActionResult Done(Guid Id)
        {
            // var idUser = User.FindFirst(x => x.Type == "id").Value;
            // var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).FirstOrDefault(x => x.Id == idUser);

            // var order = dataManager.order.GetOrders().ToList();
            // if(user.Orders.FirstOrDefault(x => x.Id == order.Id) != null)
            // return order;
            //  return new List<Product>();

            var id = User.FindFirst(x => x.Type == "id").Value;
            var order = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).Include(x => x.Orders).ThenInclude(x => x.Products)
                .FirstOrDefault(x => x.Id == id).Orders.FirstOrDefault(x => x.Id == Id);
            if (order != null)
            {
                order.Status = "Done";
                dataManager.order.UpdateOrder(order);
                return Ok();
            }
            return NotFound();
        }
    }
}
