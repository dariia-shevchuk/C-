using Microsoft.AspNetCore.Http;
using MyFirstWebApi.Exceptions;
using MyFirstWebApi.Interfaces;
using MyFirstWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebApi.Services
{
    public class SongServices : ISongService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private List<SongInDb> _songs = new List<SongInDb>
        {
            new SongInDb{ Id = 1, Title = "Tytul 1", Album = "Album 1", ReleaseYear = 2000, OwnerId = 0},
            new SongInDb{ Id = 2, Title = "Tytul 2", Album = "Album 2", ReleaseYear = 2001, OwnerId = 0},
            new SongInDb { Id = 3, Title = "Tytul 3", Album = "Album 3", ReleaseYear = 2002, OwnerId = 0 },
            new SongInDb { Id = 4, Title = "Tytul 4", Album = "Album 4", ReleaseYear = 2003, OwnerId = 0 },
            new SongInDb { Id = 5, Title = "Tytul 5", Album = "Album 5", ReleaseYear = 2004, OwnerId = 0 },
        };
        public SongServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void AddNewSong(Song newSong)
        {
            if (string.IsNullOrEmpty(newSong.Title))
                throw new SongNameNullOrEmptyException();

            var value = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;

            _songs.Add(newSong.AsSongInDb(int.Parse(value)));
        }

        public bool DeleteSongById(int id)
        {
            var songToDeleted = GetSongById(id);
            if (songToDeleted is null)
                return false;
            var value = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;

            _songs.Remove(songToDeleted.AsSongInDb(int.Parse(value)));
            return true;
        }

        public IEnumerable<Song> GetAllSongs()
        {
            //Udaje pobieranie danych z bazt ...
            var value = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;

            return _songs.Where(s => s.OwnerId == int.Parse(value)).Select(s=> s.AsSong());
        }

        public Song GetSongById(int id)
        {
            var value = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;

            return _songs
                .Where(s => s.OwnerId == int.Parse(value))
                .FirstOrDefault(song => song.Id == id)?.AsSong();
        }

        public void UpdateSong(Song song)
        {
            var songToReplace = GetSongById(song.Id);
            if (songToReplace is null)
            {
                AddNewSong(song);
                return;
            }
            
            var value = _httpContextAccessor.HttpContext.User.FindFirst("userId").Value;
            var index = _songs.IndexOf(songToReplace.AsSongInDb(int.Parse(value)));
            _songs[index] = song.AsSongInDb(int.Parse(value));
        }
    }

    public static class SongExtension
    {
        public static SongInDb AsSongInDb(this Song song, int ownerId)
        {
            return new SongInDb
            {
                OwnerId = ownerId,
                Id = song.Id,
                Album = song.Album,
                ReleaseYear = song.ReleaseYear,
                Title = song.Title,
            };
        }

        public static Song AsSong(this SongInDb songInDb)
            => new Song
            {
                Id = songInDb.Id,
                Album = songInDb.Album,
                ReleaseYear = songInDb.ReleaseYear,
                Title = songInDb.Title,
            };
    }
}
