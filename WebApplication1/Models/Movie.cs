using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class Movie
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string genre { get; set; }
        public DateTime release { get; set; }
        //public string poster { get; set; }
        public string description { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Poster Image")]
        public byte[]? MovieImage { get; set; }


    }
}
