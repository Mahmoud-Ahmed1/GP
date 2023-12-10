using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.models
{
    public class POSTSLIKES
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public post Post { get; set; }

        public string userid { get; set; }
        public DateTime LikedDate { get; set; }
    }
}
