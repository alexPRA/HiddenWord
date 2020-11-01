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

namespace TP_FINAL
{
    /// <summary>
    /// Logique d'interaction pour Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mdeElement.Play();
            mdeElement.MediaEnded += mdeElement_MediaEnded;
        }

        private void mdeElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mdeElement.Position = TimeSpan.FromMilliseconds(1);
            mdeElement.Play();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow jeu = new MainWindow();
            jeu.Show();
            this.Close();
        }

        private void btnLevels_Click(object sender, RoutedEventArgs e)
        {
            Levels pageNiveau = new Levels();
            pageNiveau.ShowDialog();
        }

        private void btnThemes_Click(object sender, RoutedEventArgs e)
        {
            Themes pageThemes = new Themes();
            pageThemes.ShowDialog();
        }
    }
}
