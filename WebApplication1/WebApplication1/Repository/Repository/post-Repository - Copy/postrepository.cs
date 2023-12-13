
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
        { var user = await _db.Users.FirstOrDefaultAsync(e => e.Id == userid);

            if (user == null)
            {
                  return null;
            }
            var evnet = new evnet
            {
                PostId = postid,
                userid = userid,
                eventDate = DateTime.UtcNow,
                taxt=null,
                 typeEvent = "like"
            };

            await _db.evnets.AddAsync(evnet);
            await save();
            return new NoContentResult();
        }

        public async Task<List<evnet>> Getlike(Expression<Func<evnet, bool>> filter =null    ,bool tracked =true ) {
        IQueryable<evnet> query = _db.evnets;
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

        public async Task<evnet> GetSpecialLike(Expression<Func<evnet, bool>> filter = null, bool tracked = true)
        {
            IQueryable<evnet> query = _db.evnets;
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
        public async Task Removelike (evnet entity)
        {
             _db.evnets.Remove(entity);

            await save();
        }
        
        /*************************************************************************************************/

        public async Task<List<evnet>> Getdislike(Expression<Func<evnet, bool>> filter = null, bool tracked = true)
        {
            IQueryable<evnet> query = _db.evnets;
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
            var user = await _db.Users.FirstOrDefaultAsync(e => e.Id == userid);

            if (user == null)
            {
                return null;
            }

            var evnet = new evnet
            {
                PostId = postid,
                userid = userid,
                eventDate = DateTime.UtcNow,
                taxt = null,
                typeEvent = "dislike"
            };

            await _db.evnets.AddAsync(evnet);
            await save();
            return new NoContentResult();
        }


        public async Task<evnet> GetSpeciaDISlLike(Expression<Func<evnet, bool>> filter = null, bool tracked = true)
        {
            IQueryable<evnet> query = _db.evnets;
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

        public async Task RemoveDISlike(evnet entity)
        {
            _db.evnets.Remove(entity);

            await save();
        }



        /*************************************************************************************************/


        public async Task<List<evnet>> GetComment(Expression<Func<evnet, bool>> filter = null, bool tracked = true)
        {
            IQueryable<evnet> query = _db.evnets;
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
            var user = await _db.Users.FirstOrDefaultAsync(e => e.Id == userid);

            if (user == null)
            {
                return null;
            }

            var evnet = new evnet
            {  
                taxt = text,
                PostId = postid,
                userid = userid,
                eventDate = DateTime.UtcNow,
               
                typeEvent = "comment"
            };

            await _db.evnets.AddAsync(evnet);
            await save();
            return new NoContentResult();
        }


        public async Task<evnet> GetSpecialComment(Expression<Func<evnet, bool>> filter = null, bool tracked = true)
        {
            IQueryable<evnet> query = _db.evnets;
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

        public async Task RemoveComment(evnet entity)
        {
            _db.evnets.Remove(entity);

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