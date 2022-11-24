using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebApi.Services
{
    public class SongServices : ISongService
    {
        private List<Song> _songs = new List<Song>
        {
            new Song{ Id = 1, Title = "Tytul 1", Album = "Album 1", ReleaseYear = 2000},
            new Song{ Id = 2, Title = "Tytul 2", Album = "Album 2", ReleaseYear = 2001},
            new Song { Id = 3, Title = "Tytul 3", Album = "Album 3", ReleaseYear = 2002 },
            new Song { Id = 4, Title = "Tytul 4", Album = "Album 4", ReleaseYear = 2003 },
            new Song { Id = 5, Title = "Tytul 5", Album = "Album 5", ReleaseYear = 2004 },
        };

        public void AddNewSong(Song newSong)
        {
            //przeprowadzam sprawdzanie
            //udaje zapis do bazy danych 
            _songs.Add(newSong);
        }

        public bool DeleteSongById(int id)
        {
            var songToDeleted = GetSongById(id);
            if (songToDeleted is null)
                return false;
            _songs.Remove(songToDeleted);
            return true;
        }

        public IEnumerable<Song> GetAllSongs()
        {
            //Udaje pobieranie danych z bazt ...
            return _songs;
        }

        public Song GetSongById(int id)
        {
            return _songs.FirstOrDefault(song => song.Id == id);
        }

        public void UpdateSong(Song song)
        {
            var songToReplace = GetSongById(song.Id);
            if (songToReplace is null)
            {
                AddNewSong(song);
                return;
            }
            var index = _songs.IndexOf(songToReplace);
            _songs[index] = song;
        }
    }
}
