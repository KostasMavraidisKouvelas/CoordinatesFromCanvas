using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoordinatesFromCanvas.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Web.Http.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace CoordinatesFromCanvas.Api.Controllers
{
   
    [Route("api/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private AppDbContext db = null;

        public ItemController(AppDbContext db)
        {
            this.db = db;
        }
        [HttpPost]
        [AllowCrossSiteJson]
        public void Insert(Item item)
        {
            item.Time= DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
            }

        }
        [HttpGet]
        public List<Item> List(String Id)
        {
            List<Item> Items = db.Items.FromSqlRaw("Select * from Items where UniqueId = {0}", Id).ToList();
            return Items;
        }
    }
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
