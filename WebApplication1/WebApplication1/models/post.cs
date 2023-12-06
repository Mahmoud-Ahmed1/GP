
using System.ComponentModel.DataAnnotations.Schema;

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
        public long totalshare { get; set; }
        
       
       


    }
}
