using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username;
    private Random rnd = new Random(); 
    public SayaTubeUser(string s) {
        Debug.Assert(s.Length <= 100, "Panjang Username Tidak Boleh lebih dari 100");
        Debug.Assert(s != null && s != "", "Username Tidak Boleh Kosong");
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
        Debug.Assert(video != null, "Video Tidak Boleh Kosong");
        Debug.Assert(video.getPlayCount()<= int.MaxValue, "PlayCount Video terlalu Besar");
        this.uploadedVideos.Add( video );
    } 
    public void PrintAllVideoPlaycount()
    {
        
        Console.WriteLine("User: " + this.Username);
        for(int i = 0;i < this.uploadedVideos.Count;i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + this.uploadedVideos[i].getTitle());
            Debug.Assert(i <= 7,"Video Yang ditampilkan lebih dari 8");
        }

    }


}

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    private const int MAX_PLAY_COUNT = int.MaxValue;
    private Random rnd = new Random();

    public SayaTubeVideo(string s)
    {
        Debug.Assert(s.Length <= 200, "Panjang Nama Video Tidak Boleh lebih dari 200");
        Debug.Assert(s != null && s != "", "Nama Video Tidak Boleh Kosong");
        this.id = rnd.Next(10000, 100000);
        this.title = s;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 25000000, "Penambahan View Tidak Boleh lebih dari 25000000");
        Debug.Assert(count >= 0, "Penambahan View tidak bisa negatif");
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
        /*Test Case Precondition 1
        SayaTubeVideo video11 = new SayaTubeVideo("TEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE" +
            "EEESSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS" +
            "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
        Test Case Precondition 2
        SayaTubeVideo video12 = new SayaTubeVideo("");
        Test Case Precondition 3
        video1.IncreasePlayCount(25000001);
        Test Case Precondition 4
        video1.IncreasePlayCount(-1); 
        Test Case Precondition 5 
        SayaTubeUser user2 = new SayaTubeUser("His Highest but also Lowest Low of life form that ever graced this cursed earth in an" +
            "ever lasting adventure sir graham donald joseph barrack biden obama trump");
        Test Case Precondition 6 
        SayaTubeUser user3 = new SayaTubeUser("");
        Test Case Precondition 7 
        SayaTubeVideo newVid = null;
        user1.AddVideo(newVid); 
        Test Case Precondition 8 & exception
        SayaTubeVideo muchWowNewVid = new SayaTubeVideo("Hello");
        for (int j = 0; j < 85; j++)
        {
            muchWowNewVid.IncreasePlayCount(25000000);
            Console.WriteLine(j);
            
        }
        
        Console.WriteLine(muchWowNewVid.getPlayCount());
        muchWowNewVid.IncreasePlayCount(24000000 );
        user1.AddVideo(muchWowNewVid);
        */
        user1.AddVideo(video1);
        user1.AddVideo(video2); 
        user1.AddVideo(video3); 
        user1.AddVideo(video4); 
        user1.AddVideo(video5); 
        user1.AddVideo(video6); 
        user1.AddVideo(video7); 
        user1.AddVideo(video8);
        //Test Case Post Condition
        user1.AddVideo(video9); 
        user1.AddVideo(video10);
        user1.PrintAllVideoPlaycount();

        
    }
}
