using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAoiClient.VirwModel
{
    public class MainWindowVirwModel : ViewModelBase
    {
        public CommandBase GetAllSongCommand => new CommandBase(GetAllSongs);

        public List<SongViewModel> Songs { get; set; }
        

        private void GetAllSongs(object? obj)
        {
            var client = new MyNamespace.Client("https://localhost:5001", new System.Net.Http.HttpClient());
            var songs = client.SongAllAsync().Result;
            Songs = songs.Select(s=> new SongViewModel(s)).ToList();
            foreach (var item in Songs)
            {
                item.OnSongDeleted += Item_OnSongDeleted;
            }
            OnPropertyChanged("Songs");
        }

        private void Item_OnSongDeleted(object? sender, EventArgs e)
        {
            foreach (var item in Songs)
            {
                item.OnSongDeleted -= Item_OnSongDeleted;
            }
            GetAllSongs(null);
        }
    }
}