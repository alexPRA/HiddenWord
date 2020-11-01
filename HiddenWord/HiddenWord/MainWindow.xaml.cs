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
using System.Windows.Controls.Primitives;

namespace TP_FINAL
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Generer_Lettres_Grid();
            Generer_Liste_des_Mots();
            if (difficulty == 6)
                lblKey.Content ="KEY: "+ easyKey;
            else if (difficulty == 10)
                lblKey.Content = "KEY: " + mediumKey;
            else if (difficulty == 16)
                lblKey.Content = "KEY: " + hardKey;
        }
        private bool mouseDown = false;
        private CustomRepeatButton btnDepart,btnArrive;
        private int difficulty = Levels.diff, TheTheme= Themes.theme;
        #region All Grids difficulty
        string EasyGrid = "SAISONAVEUPOLEASRTERCAAITSGLMUEEGAUN", MediumGrid = "SSSAUBAGNEEPAAMVENCELULMIRAMASRAOGEXACOEALNEGNARORTOULONGLRENDSTNUEIEYINPEENILDHCASSUJERFLEBELSISSAC", HardGrid = "LSPISTEEDALACSEEEOAEXMEEAMARONAPGMPUGOGETRANSATSEMLQLNANETTOEREEDEOIATPNMEAITCRDATMRCALOSLMSTATNCABEIGADIAANEMRASLAHENRNRHSEUPEHAPLPREMAUCSCQIKICIIEORORODISANKMANSLFORETIFARGIARIAECANYONINGNNLRSGTEDUTITLAEAGAEMEIRREMONTEEIEYIESEPLAEVERESTGASNASIOROCHEUSESE";
        //6x6, 10x10, 16x16 => Grids
        string[] wordList = new string[] { };
        string[] WordListEasy = new string[] { "AMI", "AVEU", "AVERSE", "NUAGE", "ORAGE", "SALETE", "SAISON" ,"NUIT"};

        string[] WordListMedium = new string[] { "AIX","APT","ARLES","AUBAGNE","AUPS","AVIGNON","BANDOL","CANNES","CASSIS",
                                                 "DIGNE","FREJUS","HYERES","LUNEL","MIRAMAS","NICE","ORANGE","SALON",
                                                 "SORGUES","TOULON", "VENCE"};

        string[] WordListHard = new string[] {"ALPAGE","ALPES","ALPINISME","ALTITUDE","ANDES","APLOMB","ARMOR","ASCENSION",
                                              "BALISAGE","CAMPING","CANYONING","CASCADE","CHALET","DEGEL","ESCALADE","EVEREST",
                                              "FORET","HIMALAYA","GLACIER","MASSIF","MONTAGNE","NEIGE","OISANS","PANORAMA","PISTE",
                                              "RANDONNEE","RAQUETTES","REMONTEE","ROCHEUSES","SIERRA","SOMMET","TELEPHERIQUE",
                                              "TERTRE","TOURISME","TRANSAT","TREKKING" };

        string easyKey = "PASCAL", mediumKey = "MARSEILLE", hardKey = "EXTRAORDINAIRE";
        //6x6, 10x10, 16x16 => Grids 
        #endregion

        #region Initialisation du jeu

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

        private void Generer_Liste_des_Mots()
        {
            wordList = WordListEasy;
            if (difficulty == 6)
                wordList = WordListEasy;
            else if (difficulty == 10)
                wordList = WordListMedium;
            else if (difficulty == 16)
                wordList = WordListHard;
            int counterRow = 0;
            int counterCol = 0;
            int numberColumns = (int)Math.Ceiling(((decimal)wordList.Length / 9));
            for (int i = 0; i < numberColumns; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                grdListe.ColumnDefinitions.Add(column);
            }
            for (int x = 0; x <= 9; x++)
            {
                RowDefinition row = new RowDefinition();
                grdListe.RowDefinitions.Add(row);
            }
            foreach (string item in wordList)
            {
                Label word = new Label();
                Style ListeMot = FindResource("ListeMot") as Style;
                word.Style = ListeMot;
                word.Content = item;
                if (difficulty == 16)
                    word.FontSize = 12;
                Grid.SetRow(word, counterRow);
                Grid.SetColumn(word, counterCol);
                grdListe.Children.Add(word);
                counterRow++;
                if (counterRow == 9)
                {
                    counterCol++;
                    counterRow = 0;
                }
            }
        }
        public void Generer_Lettres_Grid()
        {
            string gridword = "";
            switch (difficulty)
            {
                case 6:
                    gridword = EasyGrid;
                    break;
                case 10:
                    gridword = MediumGrid;
                    break;
                case 16:
                    gridword = HardGrid;
                    break;
            }
            for (int row = 0; row < difficulty; row++)
            {
                RowDefinition ROW = new RowDefinition();
                grdJeu.RowDefinitions.Add(ROW);
                ColumnDefinition COL = new ColumnDefinition();
                grdJeu.ColumnDefinitions.Add(COL);
            }
            for (int row = 0; row < grdJeu.RowDefinitions.Count; row++)
            {
                for (int col = 0; col < grdJeu.ColumnDefinitions.Count; col++)
                {
                    CustomRepeatButton word = new CustomRepeatButton();
                    word_MethodsAndProprety(ref word);
                    word.Content = gridword[(row * difficulty) + col].ToString();
                    if (difficulty == 6)
                        word.FontSize = 42;
                    else if (difficulty == 16)
                        word.FontSize = 12;
                    Grid.SetRow(word, row);
                    Grid.SetColumn(word, col);
                    word.btnCOL = col;
                    word.btnROW = row;
                    grdJeu.Children.Add(word);
                    if (row == grdJeu.RowDefinitions.Count - 1 && col == grdJeu.ColumnDefinitions.Count - 1)
                    {
                        btnDepart = word;
                        btnArrive = word;
                    }
                }
            }
        }
        private void word_MethodsAndProprety(ref CustomRepeatButton word)
        {
            word.PreviewMouseDown += RepeatButton_PreviewMouseDown;
            word.PreviewMouseUp += RepeatButton_PreviewMouseUp;
            word.PreviewMouseMove += RepeatButton_PreviewMouseMove;
        }

        private void BtnHint_Click(object sender, RoutedEventArgs e)
        {
            if (lblKey.Visibility == Visibility.Visible)
                lblKey.Visibility = Visibility.Hidden;
            else if (lblKey.Visibility == Visibility.Hidden)
                lblKey.Visibility = Visibility.Visible;
        }

        private void Initialiser_liste()// A utiliser si on genere une grille aleatoire 
        {
            ListeMots mots = new ListeMots();
            mots.Lire_Fichier();
            WordListEasy = mots.GetLISTE;
            //for (int i = 0; i < liste_mots.Length; i++)
            //{
            //    Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(liste_mots[i]));
            //}
        }
        #endregion

        #region Fonctionnement du choix des lettres pour faire un mot

        private void RepeatButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            btnDepart = (CustomRepeatButton)sender;
            btnDepart.buttonState = 0;
            mouseDown = true;

        }

        private void RepeatButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            bool check = false;
            CheckIF_wordRight(ref check);
            if (check)
            {
                if (btnArrive.btnROW == btnDepart.btnROW || btnDepart.btnCOL == btnArrive.btnCOL)
                {
                    SolidColorBrush Color = new SolidColorBrush(Colors.LightPink);
                    for (int row_mot = btnDepart.btnROW; row_mot <= btnArrive.btnROW; row_mot++)
                    {
                        for (int col_mot = btnDepart.btnCOL; col_mot <= btnArrive.btnCOL; col_mot++)
                        {
                            CustomRepeatButton btn = (CustomRepeatButton)GetGridElement(grdJeu, row_mot, col_mot);
                            SolidColorBrush colorBrush = (SolidColorBrush)btn.BorderBrush;
                            if (colorBrush.Color == Color.Color)
                            {
                                btn.BorderBrush = new SolidColorBrush(Colors.Wheat);
                            }
                        }
                    }
                    for (int row_mot = btnDepart.btnROW; row_mot >= btnArrive.btnROW; row_mot--)
                    {
                        for (int col_mot = btnDepart.btnCOL; col_mot >= btnArrive.btnCOL; col_mot--)
                        {
                            CustomRepeatButton btn = (CustomRepeatButton)GetGridElement(grdJeu, row_mot, col_mot);
                            SolidColorBrush colorBrush = (SolidColorBrush)btn.BorderBrush;
                            if (colorBrush.Color == Color.Color)
                            {
                                btn.BorderBrush = new SolidColorBrush(Colors.Wheat);
                            }
                        }
                    }
                }
                if (!(btnArrive.btnROW == btnDepart.btnROW) && !(btnArrive.btnCOL == btnDepart.btnCOL))
                {
                    #region Diagonal  Conditions
                    if (!(btnDepart.btnROW == btnArrive.btnROW) && !(btnArrive.btnCOL == btnDepart.btnCOL))
                    {
                        //Sud-Ouest
                        if (btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW < btnArrive.btnROW)
                        {
                            int x = btnDepart.btnCOL + btnDepart.btnROW;
                            for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                                for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                                {
                                    if (col + row == x)
                                    {
                                        CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                        lettre.BorderBrush = new SolidColorBrush(Colors.Wheat);
                                    }
                                }
                        }
                        //Sud-Est
                        else if (btnDepart.btnROW < btnArrive.btnROW && btnDepart.btnCOL < btnArrive.btnCOL)
                        {
                            int x = btnDepart.btnROW + btnDepart.btnCOL;
                            for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                            {
                                for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                                {
                                    CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                    if (lettre.btnROW + lettre.btnCOL == x)
                                    {
                                        lettre.BorderBrush = new SolidColorBrush(Colors.Wheat);
                                    }
                                }
                            }
                        }

                        //Nord-Ouest
                        else if (btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW > btnArrive.btnROW)
                        {
                            int x = btnDepart.btnCOL + btnDepart.btnROW;
                            for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                            {
                                for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                                {
                                    CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                    if (lettre.btnROW + lettre.btnCOL == x)
                                    {
                                        lettre.BorderBrush = new SolidColorBrush(Colors.Wheat);
                                    }
                                }
                            }
                        }

                        //Nord-Est
                        else if ((btnDepart.btnROW > btnArrive.btnROW) && (btnDepart.btnCOL < btnArrive.btnCOL))
                        {
                            int x = btnDepart.btnCOL + btnDepart.btnROW;
                            for (int row = btnDepart.btnROW; row >= btnArrive.btnROW; row--)
                                for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                                {
                                    if (col + row == x)
                                    {
                                        CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                        lettre.BorderBrush = new SolidColorBrush(Colors.Wheat);
                                    }
                                }
                        }
                    }

                    #endregion
                }
            }
            else
            {
                for (int row_mot = btnDepart.btnROW; row_mot <= btnArrive.btnROW; row_mot++)
                {
                    for (int col_mot = btnDepart.btnCOL; col_mot <= btnArrive.btnCOL; col_mot++)
                    {
                        CustomRepeatButton btn = (CustomRepeatButton)GetGridElement(grdJeu, row_mot, col_mot);
                        btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    }
                }
            }

            //Reset all buttons with a border of a pink color
            foreach (UIElement item in grdJeu.Children)
            {
                CustomRepeatButton btn = (CustomRepeatButton)item;
                SolidColorBrush colorBrush = (SolidColorBrush)btn.BorderBrush;
                SolidColorBrush color = new SolidColorBrush(Colors.LightPink);
                if (colorBrush.Color == color.Color)
                {
                    btn.BorderBrush = new SolidColorBrush(Colors.Transparent);
                }
            }
        }

        private UIElement GetGridElement(Grid grille, int row, int col)
        {
            for (int i = 0; i < grille.Children.Count; i++)
            {
                UIElement e = grille.Children[i];
                if (Grid.GetRow(e) == row && Grid.GetColumn(e) == col)
                    return e;
            }
            return null;
            //Get the UIElement of a specific grid depanding on the row and the colum
        }

        private void RepeatButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var grid = grdJeu;
            if (grid == null) { return;}
            var gridPosition = grid.GetColumnRow(e.GetPosition(grid));
            btnArrive = (CustomRepeatButton)GetGridElement(grdJeu, (int)gridPosition.Y, (int)gridPosition.X);

            if(mouseDown == true)
            {
                try
                {
                    //Check all buttons if mouse goes horizontally or vertically
                    if (btnArrive.btnROW == btnDepart.btnROW || btnDepart.btnCOL == btnArrive.btnCOL)
                    {
                        btnArrive.BorderBrush = new SolidColorBrush(Colors.LightPink);
                        btnArrive.buttonState = 0;
                    }
                    else
                    {
                        btnArrive.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    }

                    //Check all buttons if mouse goes in diagonal
                    if(!(btnArrive.btnROW==btnDepart.btnROW) &&!(btnArrive.btnCOL == btnDepart.btnCOL))
                    {
                        #region Diagonal  Conditions

                        if (!(btnDepart.btnROW == btnArrive.btnROW) && !(btnArrive.btnCOL == btnDepart.btnCOL))
                        {
                            //Sud-Ouest
                            if (btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW < btnArrive.btnROW)
                            {
                                int x = btnDepart.btnCOL + btnDepart.btnROW;
                                for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                                    for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                                    {
                                        if (col + row == x)
                                        {
                                            CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.LightPink);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row + 1, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row , col - 1);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                        }
                                    }
                            }

                            //Sud-Est
                            else if (btnDepart.btnROW < btnArrive.btnROW && btnDepart.btnCOL < btnArrive.btnCOL)
                            {
                                int counter = 0;
                                for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                                {
                                    for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                                    {
                                        CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                        if (lettre.btnROW % lettre.btnCOL == 0)
                                        {
                                            counter += 2;
                                            lettre.BorderBrush = new SolidColorBrush(Colors.LightPink);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row + 1, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col + 1);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                        }
                                    }
                                }
                            }

                            //Nord-Ouest
                            else if (btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW > btnArrive.btnROW)
                            {
                                int x = btnDepart.btnCOL + btnDepart.btnROW;
                                for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                                {
                                    for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                                    {
                                        CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                        if (lettre.btnROW + lettre.btnCOL == x)
                                        {
                                            lettre.BorderBrush = new SolidColorBrush(Colors.LightPink);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row - 1, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col - 1);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                        }
                                    }
                                }
                            }

                            //Nord-Est
                            else if ((btnDepart.btnROW > btnArrive.btnROW) && (btnDepart.btnCOL < btnArrive.btnCOL))
                            {
                                int x = btnDepart.btnCOL + btnDepart.btnROW;
                                for (int row = btnDepart.btnROW; row >= btnArrive.btnROW; row--)
                                    for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                                    {
                                        if (col + row == x)
                                        {
                                            CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.LightPink);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row - 1, col);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                            lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col + 1);
                                            lettre.BorderBrush = new SolidColorBrush(Colors.Transparent);
                                        }
                                    }
                            }
                        }

                        #endregion
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        private void CheckIF_wordRight(ref bool check)
        {
            StringBuilder mot = new StringBuilder();
            SolidColorBrush Color = new SolidColorBrush(Colors.LightPink);

            #region Horizontal and Vertical Conditions

            if ((btnDepart.btnROW == btnArrive.btnROW && btnDepart.btnCOL < btnArrive.btnCOL) || (btnDepart.btnROW < btnArrive.btnROW && btnDepart.btnCOL == btnArrive.btnCOL))//Plus petit vers plus grand
            {
                for (int row_mot = btnDepart.btnROW; row_mot <= btnArrive.btnROW; row_mot++)
                {
                    for (int col_mot = btnDepart.btnCOL; col_mot <= btnArrive.btnCOL; col_mot++)
                    {
                        CustomRepeatButton btn = (CustomRepeatButton)GetGridElement(grdJeu, row_mot, col_mot);
                        SolidColorBrush colorBrush = (SolidColorBrush)btn.BorderBrush;
                        if (colorBrush.Color == Color.Color)
                        {
                            mot.Append(btn.Content.ToString());
                        }
                    }
                }
            }

            else if ((btnDepart.btnROW == btnArrive.btnROW && btnDepart.btnCOL > btnArrive.btnCOL) || (btnDepart.btnROW > btnArrive.btnROW && btnDepart.btnCOL == btnArrive.btnCOL))// Plus grand vers plus petit
            {
                for (int row_mot = btnDepart.btnROW; row_mot >= btnArrive.btnROW; row_mot--)
                {
                    for (int col_mot = btnDepart.btnCOL; col_mot >= btnArrive.btnCOL; col_mot--)
                    {
                        CustomRepeatButton btn = (CustomRepeatButton)GetGridElement(grdJeu, row_mot, col_mot);
                        SolidColorBrush colorBrush = (SolidColorBrush)btn.BorderBrush;
                        if (colorBrush.Color == Color.Color)
                        {
                            mot.Append(btn.Content.ToString());
                        }
                    }
                }
            }
            #endregion

            #region Diagonal  Conditions

            else if (!(btnDepart.btnROW == btnArrive.btnROW) && !(btnArrive.btnCOL == btnDepart.btnCOL))
            {
                //Sud-Ouest
                if(btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW < btnArrive.btnROW)
                {
                    int x = btnDepart.btnCOL + btnDepart.btnROW;
                    for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                        for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                        {
                            if (col + row == x)
                            {
                                CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                mot.Append(lettre.Content.ToString());
                            }
                        }
                }

                //Sud-Est
                else if (btnDepart.btnROW < btnArrive.btnROW && btnDepart.btnCOL < btnArrive.btnCOL)
                {
                    int x = btnDepart.btnROW + btnDepart.btnCOL;
                    for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                    {
                        for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                        {
                            if (col - row == x)
                            {
                                CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                mot.Append(lettre.Content.ToString());
                            }
                        }
                    }
                }

                //Nord-Ouest
                else if (btnDepart.btnCOL > btnArrive.btnCOL && btnDepart.btnROW > btnArrive.btnROW)
                {
                    int x = btnDepart.btnCOL + btnDepart.btnROW;
                    for (int row = btnDepart.btnROW; row <= btnArrive.btnROW; row++)
                    {
                        for (int col = btnDepart.btnCOL; col >= btnArrive.btnCOL; col--)
                        {
                            CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                            if (lettre.btnROW + lettre.btnCOL == x)
                            {
                                mot.Append(lettre.Content.ToString());
                            }
                        }
                    }
                }

                //Nord-Est
                else if((btnDepart.btnROW > btnArrive.btnROW) && (btnDepart.btnCOL < btnArrive.btnCOL))
                {
                    int x = btnDepart.btnCOL + btnDepart.btnROW;
                    for (int row = btnDepart.btnROW; row >= btnArrive.btnROW; row--)
                        for (int col = btnDepart.btnCOL; col <= btnArrive.btnCOL; col++)
                        {
                            if (col + row == x)
                            {
                                CustomRepeatButton lettre = (CustomRepeatButton)GetGridElement(grdJeu, row, col);
                                mot.Append(lettre.Content.ToString());
                            }
                        }
                }
            }

            #endregion

            //Word existance Verification
            foreach (string word in wordList)
            {
                if (word == mot.ToString().ToUpper())
                {
                    foreach (UIElement var in grdListe.Children)
                    {
                        Label x = (Label)var;
                        if ((string)x.Content == mot.ToString().ToUpper())
                        {
                            x.Visibility = Visibility.Hidden;
                            check = true;
                        }
                    }
                }
            }
            //End Verification
        }

        #endregion

    }

}
