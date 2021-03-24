using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace media_library
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStorage storage;

        public MainWindow()
        {
            InitializeComponent();

            storage = new RuntimeMockStorage();

            song_list_view.ItemsSource = storage.GetSongs();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            AddSongDialog dlg = new AddSongDialog(storage.GetAuthors());
            dlg.Owner = this;
            
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var song = new Song() { Title = dlg.SongTitle, SongAuthor = dlg.SongAuthor, Directory = dlg.Filename };
                storage.AddSong(song);
            }
        }
    }
}
