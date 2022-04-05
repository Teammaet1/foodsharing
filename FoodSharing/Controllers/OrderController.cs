
using FoodSharing.Domain;
using FoodSharing.Domain.Entities;
using FoodSharing.Models;
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

            var id = User.FindFirst(x => x.Type == "id").Value;
            var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).ThenInclude(x => x.Chain).Include(x => x.Orders).ThenInclude(x => x.Products)
                .FirstOrDefault(x => x.Id == id);
            var order = user.Orders.FirstOrDefault(x => x.Id == Id);
            order.Products.ForEach(x => x.Orders = null);
            order.shop.Chain.Shops = null;
            order.User.Orders = null;
            return order;
        }

        [HttpGet("OrderTutor/{id}")]
        public Order GetOrderTutor(Guid Id)
        {

            var id = User.FindFirst(x => x.Type == "id").Value;
            var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).ThenInclude(x => x.Chain).Include(x => x.Orders).ThenInclude(x => x.Products)
                .FirstOrDefault(x => x.Id == id);
            if(!userManager.GetRolesAsync(user).Result.Contains("tutor"))
                return null;
            var order = dataManager.order.GetOrderById(Id);
            order.Products.ForEach(x => x.Orders = null);
            order.shop.Chain.Shops = null; 
            return order;
        }

        [HttpGet("done/{id}")]
        public IActionResult Done(Guid Id)
        {

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

        [HttpGet("searchOrder")]
        public IEnumerable<Order> GetSearchOrder()
        {

            var id = User.FindFirst(x => x.Type == "id").Value;
            var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).ThenInclude(x => x.Chain)
                .FirstOrDefault(x => x.Id == id);
            if(userManager.GetRolesAsync(user).Result.Contains("tutor"))
            {
                user.Orders.ForEach(x => x.shop.Chain.Shops = null);
                var orders = dataManager.order.GetOrders().Where(x => x.Status == "Search").ToList();
                orders.ForEach(x => x.shop.Chain.Shops = null);
                orders.ForEach(x => x.Products.ForEach(x => x.Orders = null));
                return orders;
            }


            return null;
        }

        [HttpPost("sendVolonter")]
        public async Task<IActionResult> SendVolonter(IdModel idModel)
        {

            var id = User.FindFirst(x => x.Type == "id").Value;
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            if (!userManager.GetRolesAsync(user).Result.Contains("tutor"))
                return NotFound();
            var volonter = userManager.Users.Include(x => x.Orders).FirstOrDefault(x => x.Id == idModel.idVolonter);
            var order = dataManager.order.GetOrderById(Guid.Parse(idModel.idOrder));
            order.Status = "Progress";
            volonter.Orders.Add(order);
            await userManager.UpdateAsync(volonter);
            return Ok();
        }
    }
}
