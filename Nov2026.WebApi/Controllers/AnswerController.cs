using Microsoft.AspNetCore.Mvc;
using Nov2026.Database.Models;
using Nov2026.WebApi.Models;

namespace Nov2026.WebApi.Controllers
{
    // api/answer
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AnswerController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetAnswers()
        {
            var lst = _db.Project1Answers.ToList();
            return Ok(lst);
        }

        [HttpGet("Edit/{id}")]
        public IActionResult GetAnswer(int id)
        {
            var item = _db.Project1Answers.FirstOrDefault(x => x.AnswerId == id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateAnswer(AnswerCreateRequestModel requestModel)
        {
            _db.Project1Answers.Add(new Project1Answer
            {
                QuestionId   = requestModel.QuestionId,
                AnswerNo     = requestModel.AnswerNo,
                AnswerResult = requestModel.AnswerResult.Trim(),
            });
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateAnswer(int id, AnswerUpdateRequestModel requestModel)
        {
            var item = _db.Project1Answers.FirstOrDefault(x => x.AnswerId == id);
            if (item is null)
            {
                return NotFound();
            }

            if (requestModel.QuestionId.HasValue)
            {
                item.QuestionId = requestModel.QuestionId.Value;
            }

            if (requestModel.AnswerNo.HasValue)
            {
                item.AnswerNo = requestModel.AnswerNo.Value;
            }

            if (!string.IsNullOrWhiteSpace(requestModel.AnswerResult))
            {
                item.AnswerResult = requestModel.AnswerResult.Trim();
            }

            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnswer(int id)
        {
            var item = _db.Project1Answers.FirstOrDefault(x => x.AnswerId == id);
            if (item is null)
            {
                return NotFound();
            }

            _db.Project1Answers.Remove(item);

            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }
    }
}
