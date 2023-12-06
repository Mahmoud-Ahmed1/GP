using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.models;
using WebApplication1.models.auth_model;
using WebApplication1.Repository.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class profileController : ControllerBase
    {
        public class ChangePasswordModel
        {
            public string CurrentPassword { get; set; }
            public string NewPassword { get; set; }
        }

        private readonly ImangeprofileRepository _repoemp;
        private readonly appDbcontext1 _db;
        private readonly UserManager<WebApplication1.models.ApplicationUser> _userManager;
        public profileController(appDbcontext1 db, UserManager<ApplicationUser> userManager, ImangeprofileRepository repoemp)
        {
            _userManager = userManager;
            _repoemp = repoemp;
            _db = db;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> Get()
        {
            var X = await _repoemp.GetAll();
            // _logger.log("gte all employee   ", "error");
            return Ok(X);

        }


        [HttpGet("id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> Get(string id)

        {
            if (id == null)
                return BadRequest();
            var X = await _repoemp.Get(e => e.Id == id);



            {
                if (X == null) return NotFound();

                else
                {
                    // _logger.log("gte all employee id  " + id, "ok");
                    return Ok(X);
                }
            }

        }

        [HttpDelete("id:string ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Delete(string id)

        {
            var X = await _repoemp.Get(e => e.Id == id);

            if (id == null)
                return BadRequest();
            else
            {
                if (X == null) return NotFound();
                else await _repoemp.Remove(X);
            }
            await _repoemp.save();
            return NoContent();






        }
        [HttpPut("id:string ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> update(string id, [FromBody] ApplicationUser applecationuser1)
        {
            var a = await _repoemp.Get(e => e.Id == id);

            if (applecationuser1 == null ) return BadRequest();
           


            a.fname = applecationuser1.fname;
            a.lname = applecationuser1.lname;
            a.UserName = applecationuser1.UserName;
            
            a.NormalizedUserName = applecationuser1.UserName.ToUpper();
            a.NormalizedEmail=applecationuser1.Email.ToUpper();

         
            a.Email = applecationuser1.Email;
            if (await _userManager.FindByEmailAsync(a.Email) is not null)
                return BadRequest("Email is already registered!");

            if (await _userManager.FindByNameAsync(a.UserName) is not null)
                return BadRequest("Username is already registered!");
            await _repoemp.save();
            return NoContent();

        }

        [HttpPut("profile/id:string ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApplicationUser>> updateprofile(string id, [FromBody] ApplicationUser applecationuser1)
        {
            var a = await _repoemp.Get(e => e.Id == id);

            if (applecationuser1 == null) return BadRequest();
            a.BIO = applecationuser1.BIO;
            a.barthday = applecationuser1.barthday;
            a.ginder = applecationuser1.ginder;
            a.barthday=applecationuser1.barthday;
            await _repoemp.save();
            return NoContent();

        }
        

        [HttpPut("profile/{id}/changepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ChangePassword(string id, [FromBody] ChangePasswordModel changePasswordModel)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }

            return NoContent();
        }






    }
}
