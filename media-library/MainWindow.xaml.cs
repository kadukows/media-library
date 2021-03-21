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
        private ObservableCollection<Song> items;

        private readonly Author author = new Author() { Name = "Arthur Dent", Age = 44, Mail = "arthur@dent.com" };
        private readonly String dir = "/path/to/song";

        private Song MakeSong(String title)
        {
            return new Song() { Title = title, Directory = dir, SongAuthor = author };
        }
        public MainWindow()
        {
            InitializeComponent();
        
            items = new ObservableCollection<Song>();
            var titles = new List<String>() { "test & recognize", "generic pop song title", "общее название популярной песни # 2＃2" };
            
            foreach (var title in titles)
            {
                items.Add(MakeSong(title));
            }

            lvDataBinding.ItemsSource = items;
        }

        private void button_remove_Click(object sender, RoutedEventArgs e)
        {
            var item = (Song)lvDataBinding.SelectedItem;

            if (item != null)
            {   
                items.Remove(item);
            }
            else
            {
                Console.Out.WriteLine("No item selected");
            }
        }
    }
}
