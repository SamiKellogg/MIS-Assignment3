namespace WebApplication1.Models
{
    public class RedditPost
    {
        public string PostText { get; set; } // Text of the Reddit post
        public double SentimentAnalysis { get; set; } // Sentiment analysis score
    }
    public class MovieDetailsVM
    {
        public Movie movie { get; set; }    
        public List<actors> actors { get; set; }

        public List<RedditPost> RedditPosts { get; set; }
    }
}
