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
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims()
        {
            return await _context.Claims.ToListAsync();
        }


    }
    
}