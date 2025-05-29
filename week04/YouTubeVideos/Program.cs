using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Exploring Madagascar", "WildLifeVlogs", 600);
        video1.AddComment(new Comment("Alice", "Amazing lemur footage!"));
        video1.AddComment(new Comment("Bob", "Love the scenery!"));
        video1.AddComment(new Comment("Charlie", "Great video quality."));
        videos.Add(video1);

        Video video2 = new Video("Tech Review 2025", "TechBit", 450);
        video2.AddComment(new Comment("Dave", "Very informative."));
        video2.AddComment(new Comment("Eve", "Nice breakdown!"));
        video2.AddComment(new Comment("Frank", "Helped me choose a laptop."));
        videos.Add(video2);

        Video video3 = new Video("Cooking Malagasy Dishes", "FoodieFun", 720);
        video3.AddComment(new Comment("Grace", "Yummy recipes!"));
        video3.AddComment(new Comment("Hank", "Easy to follow."));
        video3.AddComment(new Comment("Ivy", "Loved the spices."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}