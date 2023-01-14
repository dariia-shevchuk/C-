namespace MyFirstWebApi.Models
{
    public class Song
    {

        public int Id { get; set; }


        public string Title { get; set; }

        public string Album { get; set; }

        public int ReleaseYear { get; set; }
    }

    public class SongInDb : Song
    {
        public int OwnerId { get; set; }
    }

}
