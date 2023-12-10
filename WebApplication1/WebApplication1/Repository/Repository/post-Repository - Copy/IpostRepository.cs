

using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebApplication1.models;

namespace WebApplication1.Repository.Repository
{
    public interface IpostRepository : IRepository<post>
    {
        /*************************************************************************************************/
       

        Task<post> updatat(post entity);
        /*************************************************************************************************/

        Task<List<POSTSLIKES>>   Getlike (Expression<Func<POSTSLIKES,bool  >> filter =null, bool tracked = true);
        Task<IActionResult> Addlike(int id ,string userid);
        Task<POSTSLIKES> GetSpecialLike(Expression<Func<POSTSLIKES, bool>> filter = null, bool tracked = true);
        Task Removelike(POSTSLIKES entity);


        /*************************************************************************************************/


        Task<List<POSTSDISLIKES>> Getdislike(Expression<Func<POSTSDISLIKES, bool>> filter = null, bool tracked = true);
        Task<IActionResult> Adddislike(int id, string userid);
 
        Task<POSTSDISLIKES> GetSpeciaDISlLike(Expression<Func<POSTSDISLIKES, bool>> filter = null, bool tracked = true);
        Task RemoveDISlike(POSTSDISLIKES entity);

        /*************************************************************************************************/

        Task<List<Comment>> GetComment(Expression<Func<Comment, bool>> filter = null, bool tracked = true);
        Task<IActionResult> AddComment(int id, string userid,string taxt);

        Task<Comment> GetSpecialComment(Expression<Func<Comment, bool>> filter = null, bool tracked = true);
        Task RemoveComment(Comment entity); 

    }
}
