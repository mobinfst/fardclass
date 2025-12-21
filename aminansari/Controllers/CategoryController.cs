using aminansari.Dto;
using aminansari.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace aminansari.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AminDbContext Db;
        private readonly IMapper mapper;

        public CategoryController(AminDbContext db, IMapper mapper)
        {
            Db = db;
            this.mapper = mapper;
        }

        public IActionResult Add()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryDto dto)
        {
            //var mobin = new Category();
            //mobin.Name = dto.Name;
            //mobin.Description = dto.Description;
            //var mobin = new Category()
            //{
            //    Name = dto.Name,
            //    Description = dto.Description,


            //};
            var mobin = mapper.Map<Category>(dto);


            Db.Categories.Add(mobin);
            Db.SaveChanges();
            return RedirectToAction("List");


        }
        public IActionResult List()
        {
            var ansarilist = Db.Categories.ToList();
            var model = new List<CategoryDto>();
            foreach (var item in ansarilist)
            {
                //var Dto = new CategoryDto()
                //{
                //    Id = item.Id,
                //    Name = item.Name,
                //    Description = item.Description,

                //};
                var dto = mapper.Map<CategoryDto>(item);

                model.Add(dto);

            }


            return View(model);



        }
        public IActionResult Update(int Id)
        {
            var category = Db.Categories.FirstOrDefault(x => x.Id == Id);
            //var model = new CategoryDto();
            //model.Id = category.Id;
            //model.Description = category.Description;
            //model.Name = category.Name;
            var model = mapper.Map<CategoryDto>(category);

            return View(model);


        }
        [HttpPost]
        public IActionResult Update(CategoryDto dto)
        {
            var category = Db.Categories.FirstOrDefault(x => x.Id == dto.Id);

            category.Name = dto.Name;
            category.Description = dto.Description;





            Db.Categories.Update(category);
            Db.SaveChanges();

            return RedirectToAction("List");



        }
        public IActionResult Delete(int Id)
        {
            var category = Db.Categories.FirstOrDefault(x => x.Id == Id);
            Db.Categories.Remove(category);
            Db.SaveChanges();
            return RedirectToAction("List");

        }
    }
}

