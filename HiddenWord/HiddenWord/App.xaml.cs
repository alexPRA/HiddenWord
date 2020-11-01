using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TP_FINAL
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        MediaElement musique = new MediaElement();
        public App()
        {
            musique.Source = new Uri(@"video/hans.mp3", UriKind.RelativeOrAbsolute);
            musique.LoadedBehavior = MediaState.Manual;
            musique.Position = TimeSpan.Zero;
            musique.Play();
            musique.MediaEnded += musique_MediaEnded;
        }
        private void musique_MediaEnded(object sender, RoutedEventArgs e)
        {
            musique.Position = TimeSpan.FromMilliseconds(1);
            musique.Play();
        }
    }
}
