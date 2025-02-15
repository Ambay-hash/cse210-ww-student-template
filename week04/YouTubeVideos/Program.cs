using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
    }
}
using System;
using System.Collections.Generic;

public class Video
{
     public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;
    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
    // Creating a list of videos
        List<Video> videos = new List<Video>();

     // Create video instances and adding comments
       
        Video video1 = new Video(" Excel tutorial for beginners", "Kevin Stratvert", 400);
        video1.AddComment(new Comment("Menya Isaac", "Awesome thank you very much."));
        video1.AddComment(new Comment("Ugoma Gloria", "it has taught me what l didnt know."));
        video1.AddComment(new Comment("Ronald Bamutesiza", "Perfect, this is what l was looking for."));
        videos.Add(video1);

        Video video2 = new Video("Python for beginners", "Mosh Allans", 460);
        video2.AddComment(new Comment("Anigo agnes", "Very helpfull, thanks so much."));
        video2.AddComment(new Comment("Marvin Byansi", "I love programming."));
        video2.AddComment(new Comment("Majorie Nakato", " Super great explanation of polymorphism."));
        
        videos.Add(video2);

        Video video3 = new Video("Navigating Crypto", "Blum Ketra", 520);
        video3.AddComment(new Comment("Komaketch Ivan", "I Love this video it's very educative."));
        video3.AddComment(new Comment("James Balyomusi", "l really love trading."));
        video3.AddComment(new Comment("Opira Joseph", "This is what l was looking for."));
        video3.AddComment(new Comment("Alpha Ayemba", "This mazing video it's super nice."));
        videos.Add(video3);

        // Iterating through the videos and displaying inf
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: \"{comment.Text}\"");
            }

            Console.WriteLine(); 
        }
    }
}