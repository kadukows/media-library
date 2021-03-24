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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace media_library
{
    /// <summary>
    /// Interaction logic for AddSongDialog.xaml
    /// </summary>
    public partial class AddSongDialog : Window
    {
        public Author SongAuthor { get; set; }
        public String SongTitle { get; set; }
        public String Filename { get; set; }

        public AddSongDialog(ReadOnlyObservableCollection<Author> authors)
        {
            InitializeComponent();

            this.combox_authors.ItemsSource = authors;
        }

        private void choose_button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Song";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                this.Filename = dlg.FileName;
                textbox_song_directory.Text = dlg.FileName;
            }
        }

        private bool IsValid()
        {
            if (combox_authors.SelectedItem == null)
            {
                return false;
            }

            if (String.IsNullOrEmpty(textbox_song_name.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(this.Filename))
            {
                return false;
            }

            return true;
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsValid())
            {
                this.SongAuthor = (Author)combox_authors.SelectedItem;
                this.SongTitle = textbox_song_name.Text;

                this.DialogResult = true;
            }
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
