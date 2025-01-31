using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRUMPet.Data;
using TRUMPet.Domain;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace TRUMPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAuthController : ControllerBase
    {
        private readonly TRUMPetContext _context;

        public StaffAuthController(TRUMPetContext context)
        {
            _context = context;
        }

        // ✅ Register Staff
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] StaffRegisterDto request)
        {
            if (await _context.Staffs.AnyAsync(s => s.Email == request.Email))
                return BadRequest("Email already in use!");

            var staff = new Staff
            {
                Name = request.Name,
                Email = request.Email,
                Role = request.Role ?? "Staff",
                PasswordHash = HashPassword(request.Password),
                DateCreated = DateTime.UtcNow
            };

            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Staff registered successfully!" });
        }

        // ✅ Login Staff
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] StaffLoginDto request)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.Email == request.Email);
            if (staff == null || !VerifyPassword(request.Password, staff.PasswordHash))
                return Unauthorized("Invalid email or password!");

            return Ok(new { Message = "Login successful!", StaffID = staff.StaffID, Role = staff.Role });
        }

        // ✅ Hash Passwords
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        // ✅ Verify Password
        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            return HashPassword(inputPassword) == storedHash;
        }
    }
}
