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
    /// Logique d'interaction pour Levels.xaml
    /// </summary>
    public partial class Levels : Window
    {
        public string[] difficulties { get; set; }
        private const int facile = 6, medium = 10, hard =16;
        static public int diff = 6;
        public Levels()
        {
            InitializeComponent();

            difficulties = new string[] { "Easy", "Medium", "Hard" };

            DataContext = this;
            GridDispositon(cbxChoice.SelectedIndex);
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {   if(cbxChoice.SelectedIndex==0)
                diff = 6;
            else if (cbxChoice.SelectedIndex == 1)
                diff = 10;
            else if (cbxChoice.SelectedIndex == 2)
                diff = 16;
            this.Close();
        }

        private void CbxChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbxChoice.SelectedIndex)
            {
                case 0:
                    GridDispositon(facile);
                    break;
                case 1:
                    GridDispositon(medium);
                    break;
                case 2:
                    GridDispositon(hard);
                    break;
            }
        }
        private void GridDispositon(int nb_COL_ROW)
        {
            grdLevel.RowDefinitions.Clear();
            grdLevel.ColumnDefinitions.Clear();
            for (int row = 0; row < nb_COL_ROW; row++)
            {
                ColumnDefinition COLUMN = new ColumnDefinition();
                grdLevel.ColumnDefinitions.Add(COLUMN);
                RowDefinition ROW = new RowDefinition();
                grdLevel.RowDefinitions.Add(ROW);
            }
        }
    }
}
