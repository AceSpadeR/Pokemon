using PokemonGame.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace PokemonGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initailize
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Checks info opens new window
        /// </summary>
        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool NameE = true;
                bool SelectE = true;
                ErrorSelect.Visibility = Visibility.Hidden;
                ErrorName.Visibility = Visibility.Hidden;
                if (Player1Name.Text == "" || Player2Name.Text == "")
                {
                    ErrorName.Visibility = Visibility.Visible;
                    NameE = false;
                }
                if (Add.IsChecked == false && Sub.IsChecked == false && Mul.IsChecked == false && Div.IsChecked == false)
                {
                    ErrorSelect.Visibility = Visibility.Visible;
                    SelectE = false;
                }
                if (NameE == true && SelectE == true)
                {
                    Game Play = new Game((bool)Add.IsChecked, (bool)Sub.IsChecked, (bool)Mul.IsChecked, (bool)Div.IsChecked, Player1Name.Text, Player2Name.Text);
                    Play.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
}
}
