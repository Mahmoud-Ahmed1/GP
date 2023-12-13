using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class evnet 
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public string typeEvent { get; set; }
        public string userid { get; set; }
        public DateTime eventDate { get; set; }

        public string? taxt  { get; set; }

    }
}
