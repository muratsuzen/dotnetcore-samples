using JSDatatables.DataAccess.Context;
using JSDatatables.DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace JSDatatables.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            LoadTestData();
            return View();
        }
        void LoadTestData()
        {
            var number = new Random();
            for (int i = 1; i <= 200; i++)
            {
                context.Products.Add(new Product()
                {
                    Description = $"Product {Guid.NewGuid().ToString("N")}",
                    Price = number.NextDouble(),
                });
            }

            context.SaveChanges();
        }

        [HttpPost]
        public JsonResult GetProducts()
        {
            var data = context.Set<Product>().AsQueryable();

            var draw = Request.Form["draw"].FirstOrDefault();
            var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault());
            var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault());
            var orderColumnIndex = Request.Form["order[0][column]"].FirstOrDefault();
            var orderDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var orderColumnName = Request.Form[$"columns[{orderColumnIndex}][name]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int recordTotal = data.Count();
            int recordsFiltered = data.Count();

            if (!string.IsNullOrEmpty(searchValue))
            {
                data = data.Where(x => x.Description.ToLower().Contains(searchValue.ToLower()));
            }

            if (!string.IsNullOrEmpty(orderColumnName) && !string.IsNullOrEmpty(orderDir))
            {
                data = OrderByField(data, orderColumnName, orderDir == "asc");
            }

            var products = data.Skip(start).Take(length).ToList();

            var result = new
            {
                draw = draw,
                recordsTotal = recordTotal,
                recordsFiltered = recordsFiltered,
                data = products
            };

            return Json(result);
        }

        public IQueryable<T> OrderByField<T>(IQueryable<T> q, string SortField, bool Ascending)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, SortField);
            var exp = Expression.Lambda(prop, param);
            string method = Ascending ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { q.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
            return q.Provider.CreateQuery<T>(mce);
        }
    }
}