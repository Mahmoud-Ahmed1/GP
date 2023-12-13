

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

        Task<List<evnet>> Getlike(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task<IActionResult> Addlike(int id, string userid);
        Task<evnet> GetSpecialLike(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task Removelike(evnet entity);


        /*************************************************************************************************/


        Task<List<evnet>> Getdislike(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task<IActionResult> Adddislike(int id, string userid);

        Task<evnet> GetSpeciaDISlLike(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task RemoveDISlike(evnet entity);

        /*************************************************************************************************/

        Task<List<evnet>> GetComment(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task<IActionResult> AddComment(int id, string userid, string taxt);

        Task<evnet> GetSpecialComment(Expression<Func<evnet, bool>> filter = null, bool tracked = true);
        Task RemoveComment(evnet entity);

    }
}
