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
            return userManager.Users.Include(x => x.Links).Include(x => x.TypeUsers).FirstOrDefault(x => x.Id == id.ToString());
        }

        [HttpGet("orderProgress")]
        public IEnumerable<Order> GetOrderProgress() 
        {
            var id = User.FindFirst(x => x.Type == "id").Value;
            var orders = userManager.Users.Include(x => x.Orders).ThenInclude(x => x.shop).FirstOrDefault(x => x.Id == id).Orders.Where(x => x.Status == "Progress").ToList();
            return orders; //userManager.Users.Include(x => x.Links).Include(x => x.TypeUsers).Include(x => x.Orders).FirstOrDefault(x => x.Id == id.ToString()).Orders.Where(x => x.Status == "Progress").ToList();
        }

        [HttpGet("orderProducts/{id}")]
        public List<Product> GetOrderProducts(Guid id) //TODO: Куки
        {
            return dataManager.order.GetOrderById(id).Products;
        }
    }
}
