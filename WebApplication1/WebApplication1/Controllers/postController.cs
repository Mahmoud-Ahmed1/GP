using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;
using WebApplication1.models;
using WebApplication1.Repository.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class postController : ControllerBase
    {
        private readonly IpostRepository _repoemp;
        private readonly appDbcontext1 _db;

        public postController(appDbcontext1 db, IpostRepository repoemp)
        {
            _repoemp = repoemp;
            _db = db;
           
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> Get()
        {
            var X = await _repoemp.GetAll();
            // _logger.log("gte all employee   ", "error");
            return Ok(X);

        }




        [HttpGet("id:int ")]
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
                totaldislike=0,
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

        [HttpPut("like/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> like(int id)
        {
            var a = await _repoemp.Get(e => e.Id == id);

           
            a.totallike++;
            
            await _repoemp.save();
            return NoContent();

        }

        [HttpPut("unlike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> unlike(int id)
        {
            var a = await _repoemp.Get(e => e.Id == id);


            a.totallike--;

            await _repoemp.save();
            return NoContent();

        }


        [HttpPut("dislike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> dislike(int id)
        {
            var a = await _repoemp.Get(e => e.Id == id);


            a.totaldislike++;

            await _repoemp.save();
            return NoContent();

        }




        [HttpPut("undislike/id:int ")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<post>> undislike(int id)
        {
            var a = await _repoemp.Get(e => e.Id == id);


            a.totaldislike--;

            await _repoemp.save();
            return NoContent();

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
        /**/

       


        
        

    }
}
