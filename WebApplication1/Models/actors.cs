using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class actors
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public string link { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Actor Image")]
        public byte[]? ActorImage { get; set; }

    }
}
