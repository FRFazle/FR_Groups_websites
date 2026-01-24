using FR_Groups_websites.Interface;
using FR_Groups_websites.Models;
using Microsoft.AspNetCore.Mvc;

namespace FR_Groups_websites.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogoImagesController : ControllerBase
    {
        private readonly ILogoImageService _service;
        private readonly IWebHostEnvironment _env;

        public LogoImagesController(ILogoImageService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // GET: api/LogoImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogoImage>>> GetAll()
        {
            var logos = await _service.GetAllAsync();
            return Ok(logos);
        }

        // GET: api/LogoImages/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LogoImage>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var logo = await _service.GetByIdAsync(id);

            if (logo == null)
                return NotFound("Logo not found");

            return Ok(logo);
        }

        // POST: api/LogoImages/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadLogo([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var logo = new LogoImage
            {
                ImagePath = "/uploads/" + fileName
            };

            await _service.AddAsync(logo);

            return Ok(logo);
        }

        // POST: api/LogoImages
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LogoImage logoImage)
        {
            if (logoImage == null)
                return BadRequest("Invalid data");

            await _service.AddAsync(logoImage);

            return CreatedAtAction(
                nameof(GetById),
                new { id = logoImage.ID },
                logoImage
            );
        }

        // PUT: api/LogoImages/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] LogoImage logoImage)
        {
            if (logoImage == null || id != logoImage.ID)
                return BadRequest("ID mismatch");

            await _service.UpdateAsync(logoImage);

            return NoContent();
        }

        // DELETE: api/LogoImages/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
