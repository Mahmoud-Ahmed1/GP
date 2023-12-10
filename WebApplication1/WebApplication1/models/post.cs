
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Migrations;

namespace WebApplication1.models
{
    public class post
    {
        public int Id { get; set; }
        public string contant { get; set; }
        public DateTime CreatedDate { get; set; }
        public string userid { get; set; }

        public long totallike { get; set; }
        public long totaldislike { get; set; }
        public long totalcomment { get; set; }
        public long totalshare { get; set; }
        
       
       


    }

   
}
