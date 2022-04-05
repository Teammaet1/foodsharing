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
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly DataManager dataManager;

        public UserController(DataManager dataManager, UserManager<ApplicationUser> userMgr)
        {
            this.dataManager = dataManager;
            userManager = userMgr;
        }

        [HttpGet("user")]
        public ApplicationUser GetUser(Guid id)
        {
            return userManager.Users.Include(x => x.Links).FirstOrDefault(x => x.Id == id.ToString());
        }

        [HttpGet("orderProgress")]
        public IEnumerable<Order> GetOrderProgress() 
        {
            var id = User.FindFirst(x => x.Type == "id").Value;
            var orders = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).FirstOrDefault(x => x.Id == id).Orders.Where(x => x.Status == "Progress").ToList();
            orders.ForEach(x => x.User.Orders = null);
            return orders; 
        }

        [HttpGet("orderProducts/{id}")]
        public Order GetOrder(Guid id) 
        {
           // var idUser = User.FindFirst(x => x.Type == "id").Value;
           // var user = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).FirstOrDefault(x => x.Id == idUser);

            var order = dataManager.order.GetOrderById(id);
           // if(user.Orders.FirstOrDefault(x => x.Id == order.Id) != null)
                return order;
          //  return new List<Product>();
        }


        [HttpGet("volonters")]
        public IEnumerable<ApplicationUser> GetVolonters()
        {
            var id = User.FindFirst(x => x.Type == "id").Value;
            var user = userManager.Users.Include(x => x.Volunteers).FirstOrDefault(x => x.Id == id);
            List<ApplicationUser> users = new List<ApplicationUser>();
            user.Volunteers.ForEach(x => users.Add(userManager.FindByIdAsync(x.UserId).Result));


            return users;
        }


    }
}
