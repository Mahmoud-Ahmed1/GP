
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WebApplication1.Controllers;

using WebApplication1.models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Repository.Repository
     

{ 
    public class postrepository : Repositoryg<post>, IpostRepository
    {
        private readonly appDbcontext1 _db;
        private readonly UserManager<ApplicationUser> _userManager;
    public postrepository(appDbcontext1 db, UserManager<ApplicationUser> userManager) : base(db)
        {
            _db = db;
         _userManager = userManager;
        }



        /*************************************************************************************************/
        public async Task<IActionResult> Addlike(int postid, string userid)
        { var user = await _db.PostLikes.FirstOrDefaultAsync(e => e.userid == userid);

            if (user == null)
            {
                return new BadRequestObjectResult("User not found");
            }
            var postLike = new POSTSLIKES
            {
                PostId = postid,
                userid = userid,
                LikedDate = DateTime.UtcNow
            };

            await _db.PostLikes.AddAsync(postLike);
            await save();
            return new NoContentResult();
        }

        public async Task<List<POSTSLIKES>> Getlike(Expression<Func<POSTSLIKES, bool>> filter =null    ,bool tracked =true ) {
        IQueryable<POSTSLIKES> query = _db.PostLikes;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();

        }

        public async Task<POSTSLIKES> GetSpecialLike(Expression<Func<POSTSLIKES, bool>> filter = null, bool tracked = true)
        {
            IQueryable<POSTSLIKES> query = _db.PostLikes;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();

        }
        public async Task Removelike (POSTSLIKES entity)
        {
             _db.PostLikes.Remove(entity);

            await save();
        }
        
        /*************************************************************************************************/

        public async Task<List<POSTSDISLIKES>> Getdislike(Expression<Func<POSTSDISLIKES, bool>> filter = null, bool tracked = true)
        {
            IQueryable<POSTSDISLIKES> query = _db.PostdisLikes;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }



        public async Task<IActionResult> Adddislike(int postid, string userid)
        {
            var user = await _db.PostdisLikes.FirstOrDefaultAsync(e => e.userid == userid);

           
            var postdislike = new POSTSDISLIKES
            {
                PostId = postid,
                userid = userid,
                DISLikedDate = DateTime.UtcNow
            };

            await _db.PostdisLikes.AddAsync(postdislike);
            await save();
            return new NoContentResult();
        }


        public async Task<POSTSDISLIKES> GetSpeciaDISlLike(Expression<Func<POSTSDISLIKES, bool>> filter = null, bool tracked = true)
        {
            IQueryable<POSTSDISLIKES> query = _db.PostdisLikes;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task RemoveDISlike(POSTSDISLIKES entity)
        {
            _db.PostdisLikes.Remove(entity);

            await save();
        }



        /*************************************************************************************************/


        public async Task<List<Comment>> GetComment(Expression<Func<Comment, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Comment> query = _db.Comments;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

      

        public async Task<IActionResult> AddComment(int postid, string userid ,string text)
        {
           
            var Comment = new Comment
            {  
                text = text,
                PostId = postid,
                userid = userid,
                commentDate = DateTime.UtcNow 
            };

            await _db.Comments.AddAsync(Comment);
            await save();
            return new NoContentResult();
        }


        public async Task<Comment> GetSpecialComment(Expression<Func<Comment, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Comment> query = _db.Comments;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();

        }

        public async Task RemoveComment(Comment entity)
        {
            _db.Comments.Remove(entity);

            await save();
        }



        /*************************************************************************************************/




        public async Task<post> updatat(post entity)
        {
            entity.CreatedDate = DateTime.Now;
            _db.posts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

      

      

      
    }
}