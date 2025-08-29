using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [ApiController]
    [Route("summary")]
    public class SummaryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SummaryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Summary>> GetAll()
        {
            return Ok(_context.Summaries.ToList());
        }

        [HttpGet("latest")]
        public ActionResult<Summary> GetLatest()
        {
            var latest = _context.Summaries.OrderByDescending(s => s.Id).FirstOrDefault();
            if (latest == null) return NotFound();
            return Ok(latest);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Summary> Get(int id)
        {
            var summary = _context.Summaries.Find(id);
            if (summary == null) return NotFound();
            return Ok(summary);
        }

        [HttpPost]
        public ActionResult<Summary> Create(Summary summary)
        {
            _context.Summaries.Add(summary);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = summary.Id }, summary);
        }
    }
}
