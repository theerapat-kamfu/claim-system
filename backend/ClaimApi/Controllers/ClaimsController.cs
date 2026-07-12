using Microsoft.AspNetCore.Mvc;
using ClaimApi.Data;
using ClaimApi.Models;
using Microsoft.EntityFrameworkCore;


namespace ClaimApi.Controllers
{
    [Route("api/claims")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        
        private readonly AppDbContext _context;

        public ClaimController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims([FromQuery] int? statusId)
        {  
            var query = _context.Claims.AsQueryable();

            if (statusId.HasValue)
            {
                query = query.Where(c => c.StatusId == statusId.Value);
            }
            query = query.Where(c => c.IsActive);

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Claim>> CreateClaim(Claim claim)
        {
            _context.Claims.Add(claim);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClaim), new { id = claim.ClaimId }, claim);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            var claim = await _context.Claims.FindAsync(id);

            if (claim == null)
            {
                return NotFound();
            }
            return claim;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClaim(int id, Claim claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest("ID ใน URL กับ ID ในข้อมูลไม่ตรงกัน");
            }

            _context.Entry(claim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Claims.Any(c => c.ClaimId == id)) return NotFound();
                throw;
            }

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null) return NotFound();

            claim.IsActive = false; 
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
    
}