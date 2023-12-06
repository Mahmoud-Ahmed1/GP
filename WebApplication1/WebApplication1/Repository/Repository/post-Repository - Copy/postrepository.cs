
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Controllers;

using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public class postrepository : Repositoryg<post>, IpostRepository
    {
        private readonly appDbcontext1 _db;

        public postrepository(appDbcontext1 db) : base(db)
        {
            _db = db;

        }


        public async Task<post> updatat(post entity)
        {
            entity.CreatedDate = DateTime.Now;
            _db.posts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }



    }
}