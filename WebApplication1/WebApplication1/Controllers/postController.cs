using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using System.Runtime.InteropServices;
using WebApplication1.models;
using WebApplication1.models.dto;
using WebApplication1.Repository.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {
        private readonly IpostRepository _repoemp;
        private readonly appDbcontext1 _db;
       private readonly UserManager<ApplicationUser> _userManager;
        public postController(UserManager<ApplicationUser> userManager, appDbcontext1 db, IpostRepository repoemp)
        {
            _userManager = userManager;
            _repoemp = repoemp;
            _db = db;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /* [Authorize (Roles = "Admin")]  */
        public async Task<ActionResult<post>> Get()
        {
            var X = await _repoemp.GetAll();
           
            return Ok(X);

        }




        [HttpGet("id:string ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Get(string id)

        {
            if (id == null)
                return BadRequest();
            var X = await _repoemp.Get(e => e.userid == id);



            {
                if (X == null) return NotFound();

                else
                {
                    // _logger.log("gte all employee id  " + id, "ok");
                    return Ok(X);
                }
            }

        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Creatpost([FromBody] post post1)
        {
            if (post1 == null)
            {
                return BadRequest();
            }
            post model = new()
            {
                contant = post1.contant,
                CreatedDate = post1.CreatedDate,
                userid = post1.userid,
                totalshare = 0,
                totaldislike = 0,
                totallike = 0,


            };


            await _db.posts.AddAsync(model);
            await _db.SaveChangesAsync();

            return Ok(model);
        }



        [HttpDelete("id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Delete(int id)

        {
            var X = await _repoemp.Get(e => e.Id == id);

            if (id == 0)
                return BadRequest();
            else
            {
                if (X == null) return NotFound();
                else await _repoemp.Remove(X);
            }
            await _repoemp.save();
            return NoContent();

        }


        [HttpPut("id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> update(int id, [FromBody] post post1)
        {
            var a = await _repoemp.Get(e => e.Id == id);

            if (post1 == null || id != post1.Id) return BadRequest();

            a.contant = post1.contant;
            await _repoemp.save();
            return NoContent();

        }

        [HttpPut("like/id:int/id:string ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> like(int id ,string userid)
        {
           var post = await _repoemp.Get(e => e.Id == id);

            if (post == null)
            {
                return NotFound(); // Post with the given id not found
            }
            post.totallike++;
            await _repoemp.Addlike(id, userid);
            await _repoemp.save();
            return NoContent();

        }


     

        [HttpPut("unlike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> unlike(int postid, string usid)
        {
            var existingLike = await _repoemp.GetSpecialLike(e => e.PostId == postid && e.userid == usid);

            if (postid == 0 || usid == null)
                return BadRequest();
            else
            {
                if (existingLike == null) return NotFound();
                else
                    await _repoemp.Removelike(existingLike);
            }
            await _repoemp.save();
            return NoContent();

        }

       
        [HttpGet("Getlikes/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Getliskss(int id)

        {
            if (id == null)
                return BadRequest();
            var X = await _repoemp.Getlike(e => e.PostId == id);



            {
                if (X == null) return NotFound();

                else
                {
                    // _logger.log("gte all employee id  " + id, "ok");
                    return Ok(X);
                }
            }

        }

        [HttpPut("dislike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> dislike(int id, string userid)
        {
            var post = await _repoemp.Get(e => e.Id == id);

            if (post == null)
            {
                return NotFound(); // Post with the given id not found
            }
            post.totaldislike++;
            await _repoemp.Adddislike(id, userid);
            await _repoemp.save();
            return NoContent();

        }




        [HttpPut("undislike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> undislike(int postid, string usid)
        {
            var existingLike = await _repoemp.GetSpeciaDISlLike(e => e.PostId == postid && e.userid == usid);

            if (postid == 0 || usid == null)
                return BadRequest();
            else
            {
                if (existingLike == null) return NotFound();
                else
                    await _repoemp.RemoveDISlike(existingLike);
            }
            await _repoemp.save();
            return NoContent();

        }

      


        [HttpGet("Getdislikes/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Getdisliskss(int id)

        {
            if (id == null)
                return BadRequest();
            var X = await _repoemp.Getdislike(e => e.PostId == id);



            {
                if (X == null) return NotFound();

                else
                {
                    // _logger.log("gte all employee id  " + id, "ok");
                    return Ok(X);
                }
            }

        }




        [HttpPut("comment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> comment([FromBody] CommentDto CommentDto)
        {
            var post = await _repoemp.Get(e => e.Id == CommentDto.postid);

            if (post == null)
            {
                return NotFound(); // Post with the given id not found
            }
            post.totalcomment++;
            await _repoemp.AddComment(CommentDto.postid, CommentDto.userid, CommentDto.taxt);
            await _repoemp.save();
            return NoContent();

        }




        [HttpDelete("comment/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Deletecomment(int postid, string usid)
        {
            var existingcomment = await _repoemp.GetSpecialComment(e => e.PostId == postid && e.userid == usid);

            if (postid == 0 || usid == null)
                return BadRequest();
            else
            {
                if (existingcomment == null) return NotFound();
                else
                    await _repoemp.RemoveComment(existingcomment);
            }
            await _repoemp.save();
            return NoContent();

        }




        [HttpGet("Getcomment/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Getcomment(int id)

        {
            if (id == null)
                return BadRequest();
            var X = await _repoemp.GetComment(e => e.PostId == id);



            {
                if (X == null) return NotFound();

                else
                {
                   
                    return Ok(X);
                }
            }

        }



        [HttpPut("shere/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public async Task<ActionResult<post>> shere(int id)
        {
            var a = await _repoemp.Get(e => e.Id == id);


            a.totalshare++;

            await _repoemp.save();
            return NoContent(); 

        }








    }
}
