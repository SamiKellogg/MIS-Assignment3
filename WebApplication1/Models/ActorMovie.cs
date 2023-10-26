using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ActorMovie
    {
        public Guid id { get; set; }
        [ForeignKey("actors")]
        public Guid? ActorID { get; set; }
        public actors? Actor { get; set; }
        [ForeignKey("Movie")]
        public Guid? MovieID { get; set; }
        public Movie? Movie { get; set; }

    }
}
