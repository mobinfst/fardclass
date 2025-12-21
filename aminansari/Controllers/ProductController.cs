using aminansari.Dto;
using aminansari.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace aminansari.Controllers
{
    public class ProductController : Controller
    {
        private readonly AminDbContext Db;
        private readonly IMapper mapper;

        public ProductController(AminDbContext db, IMapper mapper)
        {
            Db = db;
            this.mapper = mapper;
        }
        public IActionResult Add()
        {
            var model = new ProductDto();
            var lst = Db.Categories.ToList();
            //model.Categories = new List<CategoryDto>();
            //  foreach (var item in lst)
            //  {
            //      var Dto = new CategoryDto()
            //      {
            //          Id = item.Id,
            //          Name = item.Name,
            //          Description = item.Description,

            //      };

            //      model.Categories.Add(Dto);

            //  }
            model.Categories = mapper.Map<List<CategoryDto>>(lst);

            return View(model);

        }
        [HttpPost]
        public IActionResult add(ProductDto Dto)
        {
            //var model = new Product()
            //{
            //    Name = Dto.Name,
            //    Description = Dto.Description,
            //    Price = Dto.Price,
            //    count=Dto.count,
            //    CategoryId = Dto.CategoryId,




            //};
            var model = mapper.Map<Product>(Dto);

            Db.Products.Add(model);
            Db.SaveChanges();
            return RedirectToAction("List");

        }

        public IActionResult List()
        {
            var lst = Db.Products.ToList();
            var model = new List<ProductDto>();
            foreach (var item in lst)
            {
                var dto = mapper.Map<ProductDto>(item);

                var category = Db.Categories.FirstOrDefault(x => x.Id == item.CategoryId);
                dto.CategoriesName = category.Name;
                dto.CategoriesDescription = category.Description;



                model.Add(dto);




            }


            return View(model);
        }

        public IActionResult Update(int Id)
        {
            var Product = Db.Products.FirstOrDefault(x => x.Id == Id);
            var model = mapper.Map<ProductDto>(Product);
            var lst = Db.Categories.ToList();
            model.Categories = mapper.Map<List<CategoryDto>>(lst);
            return View(model);


        }

        [HttpPost]
        public IActionResult update(ProductDto Dto)
        {
            var model = Db.Products.FirstOrDefault(x => x.Id == Dto.Id);
            model.Name= Dto.Name;
            model.Description= Dto.Description;
            model.CategoryId = Dto.CategoryId;
            model.count=Dto.count;
            model.Price = Dto.Price;
            Db.Products.Update(model);
            Db.SaveChanges();

            return RedirectToAction("List");




        }
        public IActionResult Delete(int Id  )
        {
            var model = Db.Products.FirstOrDefault(x=>x.Id == Id);
            Db.Products.Remove(model);
            Db.SaveChanges();
            return RedirectToAction("List");




        }


    }
}
