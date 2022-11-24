using MyFirstWebApi.Models;
using System.Collections.Generic;


namespace MyFirstWebApi.Interfaces
{
    public interface ISongService
    {
        IEnumerable<Song> GetAllSongs();

        void AddNewSong(Song newSong);

        Song GetSongById(int id);
        bool DeleteSongById(int id);
        void UpdateSong(Song song);
    }
}
