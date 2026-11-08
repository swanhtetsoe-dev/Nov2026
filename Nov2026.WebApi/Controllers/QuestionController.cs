using Microsoft.AspNetCore.Mvc;
using Nov2026.Database.Models;
using Nov2026.WebApi.Models;

namespace Nov2026.WebApi.Controllers
{
    // api/question
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _db;

        public QuestionController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            var lst = _db.Project1Questions.ToList();
            return Ok(lst);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult GetQuestion(int id)
        {
            var item = _db.Project1Questions.FirstOrDefault(x => x.QuestionId == id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateQuestion(QuestionCreateRequestModel requestModel)
        {
            int nextId = _db.Project1Questions.Any()
                ? _db.Project1Questions.Max(x => x.QuestionId) + 1
                : 1;

            _db.Project1Questions.Add(new Project1Question
            {
                QuestionId   = nextId,
                QuestionNo   = requestModel.QuestionNo,
                QuestionName = requestModel.QuestionName.Trim(),
            });
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateQuestion(int id, QuestionUpdateRequestModel requestModel)
        {
            var item = _db.Project1Questions.FirstOrDefault(x => x.QuestionId == id);
            if (item is null)
            {
                return NotFound();
            }

            if (requestModel.QuestionNo.HasValue)
            {
                item.QuestionNo = requestModel.QuestionNo.Value;
            }

            if (!string.IsNullOrWhiteSpace(requestModel.QuestionName))
            {
                item.QuestionName = requestModel.QuestionName.Trim();
            }

            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var item = _db.Project1Questions.FirstOrDefault(x => x.QuestionId == id);
            if (item is null)
            {
                return NotFound();
            }

            _db.Project1Questions.Remove(item);

            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }
    }
}
