using System.Diagnostics;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;
    private Random rnd = new Random(); 
    public SayaTubeUser(string s) {
        this.id = rnd.Next(10000, 100000);
        this.Username = s;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }
    public int GetTotalVideoPlayCount() { 
        int total = 0;
        for (int i = 0; i < this.uploadedVideos.Count; i++)
        {
            total = total + this.uploadedVideos[i].getPlayCount();
        }
        return total;
    }
    public void AddVideo(SayaTubeVideo video ) {
        this.uploadedVideos.Add( video );
    } 
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.Username);
        for(int i = 0;i < this.uploadedVideos.Count;i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + this.uploadedVideos[i].getTitle());
        }

    }


}

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    private const int MAX_PLAY_COUNT = 10000000;
    private Random rnd = new Random();

    public SayaTubeVideo(string s)
    {

        this.id = rnd.Next(10000, 100000);
        this.title = s;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            checked
            {
                if (count <= 0)
                {
                    throw new ArgumentException("Count harus lebih besar dari nol.");
                }
                if (this.playCount + count > MAX_PLAY_COUNT)
                {
                    throw new OverflowException("Jumlah penambahan play count melebihi batas maksimal.");
                }
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Overflow exception: " + ex.Message);
            this.playCount = MAX_PLAY_COUNT;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Argument exception: " + ex.Message);
        }
    }
    public int getPlayCount()
    {
        return this.playCount;
    }
    public string getTitle()
    {
        return this.title;
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("Judul video: " + this.title);
        Console.WriteLine("ID Video: " + this.id);
        Console.WriteLine("PlayCount video: " + this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeUser user1 = new SayaTubeUser("Gabrielle");
        SayaTubeVideo video1 = new SayaTubeVideo("Review film Your Name oleh Gabrielle");
        SayaTubeVideo video2 = new SayaTubeVideo("Review film Train To Busan oleh Gabrielle");
        SayaTubeVideo video3 = new SayaTubeVideo("Review film Dunkirk oleh Gabrielle");
        SayaTubeVideo video4 = new SayaTubeVideo("Review film Avengers: Infinity War To Busan oleh Gabrielle");
        SayaTubeVideo video5 = new SayaTubeVideo("Review film Johny English oleh Gabrielle");
        SayaTubeVideo video6 = new SayaTubeVideo("Review film A Silent Voice oleh Gabrielle");
        SayaTubeVideo video7 = new SayaTubeVideo("Review film Now You See Me 2 oleh Gabrielle");
        SayaTubeVideo video8 = new SayaTubeVideo("Review film Captain America: Civil War oleh Gabrielle");
        SayaTubeVideo video9 = new SayaTubeVideo("Review film Downfall oleh Gabrielle");
        SayaTubeVideo video10 = new SayaTubeVideo("Review film Shrek 2 oleh Gabrielle");
        user1.AddVideo(video1);
        user1.AddVideo(video2); 
        user1.AddVideo(video3); 
        user1.AddVideo(video4); 
        user1.AddVideo(video5); 
        user1.AddVideo(video6); 
        user1.AddVideo(video7); 
        user1.AddVideo(video8);
        user1.AddVideo(video9); 
        user1.AddVideo(video10);
        user1.PrintAllVideoPlaycount();
    }
}
