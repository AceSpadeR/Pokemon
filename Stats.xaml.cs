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
using System.Windows.Shapes;

namespace PokemonGame
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        /// <summary>
        /// gets GamePlay to utilize user1 and 2
        /// </summary>
        public Stats(GamePlay Play)
        {
            InitializeComponent();
            Player1Stat.Content = Play.GetUser(1);
            Player2Stat.Content = Play.GetUser(2);
            TimerL.Content = "Timer: " + Play.getTime();
            
        }

        /// <summary>
        /// Cancels all windows
        /// </summary>
        private void CancelAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int w = App.Current.Windows.Count - 1; w >= 0; w--)
                {
                    App.Current.Windows[w].Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Cancels all but first window
        /// </summary>
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int w = App.Current.Windows.Count - 1; w >= 1; w--)
                {
                    App.Current.Windows[w].Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
