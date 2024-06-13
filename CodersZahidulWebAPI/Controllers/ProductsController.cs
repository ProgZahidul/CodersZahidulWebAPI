using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodersZahidul.DataAccess.Data;
using CodersZahidul.Models;
using CodersZahidul.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodersZahidulWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            if (imageFile == null)
                throw new ArgumentNullException(nameof(imageFile));

            string imagePath = "\\Images\\" + Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            string filePath = Path.Combine(_hostEnvironment.WebRootPath, imagePath.TrimStart('\\'));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imagePath;
        }

        private void DeleteImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return;

            string filePath = Path.Combine(_hostEnvironment.WebRootPath, imagePath.TrimStart('\\'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return await _context.products.Include(p => p.Category).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromForm] ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Title = productVM.Title,
                    Brand = productVM.Brand,
                    Type = productVM.Type,
                    Description = productVM.Description,
                    Price = productVM.Price,
                    CategoryId = productVM.CategoryId
                };

                if (productVM.ImageFile != null)
                {
                    try
                    {
                        product.ImgPath = await SaveImage(productVM.ImageFile);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                _context.products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromForm] ProductVM productVM)
        {
            var existingProduct = await _context.products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingProduct.Title = productVM.Title;
                existingProduct.Brand = productVM.Brand;
                existingProduct.Type = productVM.Type;
                existingProduct.Description = productVM.Description;
                existingProduct.Price = productVM.Price;
                existingProduct.CategoryId = productVM.CategoryId;

                if (productVM.ImageFile != null)
                {
                    try
                    {
                        string newImagePath = await SaveImage(productVM.ImageFile);
                        if (!string.IsNullOrEmpty(existingProduct.ImgPath))
                        {
                            DeleteImage(existingProduct.ImgPath);
                        }
                        existingProduct.ImgPath = newImagePath;
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }

                _context.Entry(existingProduct).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(existingProduct);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(product.ImgPath))
            {
                DeleteImage(product.ImgPath);
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product deleted successfully" });
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(p => p.Id == id);
        }
    }
}
