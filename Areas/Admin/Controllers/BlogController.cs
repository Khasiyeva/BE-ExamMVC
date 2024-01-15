using BE_ExamMVC.DAL;
using BE_ExamMVC.Helpers;
using BE_ExamMVC.Models;
using BE_ExamMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BE_ExamMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BlogController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Blog> blog= _context.Blogs.ToList();
            return View(blog);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVM createVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            if (!createVM.ImageFile.CheckContent("image/"))
            {
                ModelState.AddModelError("ImageFile", "Please enter the correct variant");
                return View();
            }

            if (!createVM.ImageFile.CheckLength(2000000))
            {
                ModelState.AddModelError("ImageFile", "Maximum 2mb");
                return View();
            }

            Blog blog = new Blog()
            {
                Title=createVM.Title,
                Description=createVM.Description,
                ImgUrl= createVM.ImageFile.Upload(_env.WebRootPath, @"\Upload\Blogs\")
            };

           
            

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Blog blog = _context.Blogs.Find(id);

            UpdateVM updateVM = new() 
            {
                Title = blog.Title,
                Description=blog.Description,
                ImgUrl = blog.ImgUrl,
                
            };

            return View(updateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateVM updateVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            updateVM.ImgUrl = updateVM.ImageFile.Upload(_env.WebRootPath, @"\Upload\Blogs\");

            Blog oldBlog = _context.Blogs.Find(id);
            oldBlog.Title=updateVM.Title;
            oldBlog.Description=updateVM.Description;
            oldBlog.ImageFile = updateVM.ImageFile;


            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Blog blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
