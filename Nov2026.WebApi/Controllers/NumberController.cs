using Microsoft.AspNetCore.Mvc;
using Nov2026.Database.Models;
using Nov2026.WebApi.Models;

namespace Nov2026.WebApi.Controllers
{
    // api/number
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        private readonly AppDbContext _db;

        public NumberController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetNumbers()
        {
            var lst = _db.Project1Numbers.ToList();
            return Ok(lst);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult GetNumber(int id)
        {
            var item = _db.Project1Numbers.FirstOrDefault(x => x.NumberId == id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateNumber(NumberCreateRequestModel requestModel)
        {

            _db.Project1Numbers.Add(new Project1Number
            {
                Column1  = requestModel.Column1,
                Column2  = requestModel.Column2,
                Column3  = requestModel.Column3,
                Column4  = requestModel.Column4,
                Column5  = requestModel.Column5,
                Column6  = requestModel.Column6,
                Column7  = requestModel.Column7,
                Column8  = requestModel.Column8,
                Column9  = requestModel.Column9,
            });
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateNumber(int id, NumberUpdateRequestModel requestModel)
        {
            var item = _db.Project1Numbers.FirstOrDefault(x => x.NumberId == id);
            if (item is null)
            {
                return NotFound();
            }

            if (requestModel.Column1.HasValue) item.Column1 = requestModel.Column1.Value;
            if (requestModel.Column2.HasValue) item.Column2 = requestModel.Column2.Value;
            if (requestModel.Column3.HasValue) item.Column3 = requestModel.Column3.Value;
            if (requestModel.Column4.HasValue) item.Column4 = requestModel.Column4.Value;
            if (requestModel.Column5.HasValue) item.Column5 = requestModel.Column5.Value;
            if (requestModel.Column6.HasValue) item.Column6 = requestModel.Column6.Value;
            if (requestModel.Column7.HasValue) item.Column7 = requestModel.Column7.Value;
            if (requestModel.Column8.HasValue) item.Column8 = requestModel.Column8.Value;
            if (requestModel.Column9.HasValue) item.Column9 = requestModel.Column9.Value;

            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNumber(int id)
        {
            var item = _db.Project1Numbers.FirstOrDefault(x => x.NumberId == id);
            if (item is null)
            {
                return NotFound();
            }

            _db.Project1Numbers.Remove(item);

            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }
    }
}
