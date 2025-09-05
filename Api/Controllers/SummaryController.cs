using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;
using Api.Dtos;

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

        // 新增：用日期更新特定欄位
        [HttpPatch("date/{dateString}")]
        public IActionResult UpdateByDate(string dateString, [FromBody] UpdateSummaryDto dto)
        {
            if (!DateTime.TryParse(dateString, out DateTime date))
            {
                return BadRequest("Invalid date format. Please use yyyy-MM-dd format.");
            }

            var summary = _context.Summaries.FirstOrDefault(s => s.Date.Date == date.Date);
            if (summary == null)
            {
                return NotFound($"No summary found for date: {dateString}");
            }

            if (dto.ForeignInvestor.HasValue) summary.ForeignInvestor = dto.ForeignInvestor.Value;
            if (dto.InvestmentTrust.HasValue) summary.InvestmentTrust = dto.InvestmentTrust.Value;
            if (dto.DealerSelf.HasValue) summary.DealerSelf = dto.DealerSelf.Value;
            if (dto.MarginBalance.HasValue) summary.MarginBalance = dto.MarginBalance.Value;
            if (dto.GoldPrice.HasValue) summary.GoldPrice = dto.GoldPrice.Value;
            if (dto.UsdExchange.HasValue) summary.UsdExchange = dto.UsdExchange.Value;
            if (dto.Sp500.HasValue) summary.Sp500 = dto.Sp500.Value;
            if (dto.Nasdaq.HasValue) summary.Nasdaq = dto.Nasdaq.Value;
            if (dto.Dji.HasValue) summary.Dji = dto.Dji.Value;
            if (dto.Sox.HasValue) summary.Sox = dto.Sox.Value;
            if (dto.Vix.HasValue) summary.Vix = dto.Vix.Value;
            if (dto.UsGovernmentBound.HasValue) summary.UsGovernmentBound = dto.UsGovernmentBound.Value;
            if (dto.Taiex.HasValue) summary.Taiex = dto.Taiex.Value;

            _context.SaveChanges();
            return Ok(summary);
        }
    }
}
