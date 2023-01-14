using MyNamespace;
using System;

namespace WebAoiClient.VirwModel
{
    public class SongViewModel : ViewModelBase
    {
        private readonly Song _model;
        public event EventHandler<EventArgs> OnSongDeleted;

        public CommandBase DeleteSongCommand => new CommandBase(DeleteSong);
        private async void DeleteSong(object? obj)
        {
            var client = new Client("https://localhost:5001", new System.Net.Http.HttpClient());

            var awaiter = client.SongDELETEAsync(Id).GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                OnSongDeleted?.Invoke(this, EventArgs.Empty);
            });
        }

        public int Id => _model.Id;

        public string Title => _model.Title;

        public string Album => _model.Album;

        public int ReleaseYear => _model.ReleaseYear;

        public SongViewModel(Song song)
        {
            _model = song;
        }
    }
}
