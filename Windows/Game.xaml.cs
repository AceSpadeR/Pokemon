using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using System.Xml.Linq;
using Color = System.Drawing.Color;

namespace PokemonGame.Images
{



    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private char MathType;
        private string sPlayer1;
        private string sPlayer2;
        private GamePlay Play;
        DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// initialize componets.
        /// </summary>
        public Game(bool Add, bool Sub, bool Mul, bool Div, string sPlayerName1, string sPlayerName2)
        {
            try
            {
                InitializeComponent();
                

                p1Name.Content = sPlayerName1;
                p2Name.Content = sPlayerName2;
                sPlayer1 = sPlayerName1;
                sPlayer2 = sPlayerName2;
                SetUp();
                SubmitButton.Content = "Start";
                if (Add) { MathType = '+'; }
                if (Sub) { MathType = '-'; }
                if (Mul) { MathType = '*'; }
                if (Div) { MathType = '/'; }
                Play = new GamePlay(MathType, sPlayer1, sPlayer2);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
    }
}

        void timer_Tick(object sender, EventArgs e)
        {
            TimerL.Content = DateTime.Now.ToString("ss");
        }

        /// <summary>
        /// Start, submit, Next button
        /// </summary>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try { 
            if (SubmitButton.Content == "Start")
            {
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
                SubmitButton.Content = "Submit";
                QuestionBox.Content = Play.GetQuestion();

            }
            else if (SubmitButton.Content == "Submit")
            {
                    SubmitButton.Content = "Next";
                    QuestionBox.Content += Play.GetAnswer();
                    RoundOutCome.Content = Play.GetWinner(Player1.Text, Player2.Text);
                //Sound of winner
                SoundPlayer simpleSound;
                switch (RoundOutCome.Content)
                {
                    case "Tie":
                        break;
                    case "Player1 Wins":
                        simpleSound = new SoundPlayer((PokName1.Content + "S.wav"));
                        simpleSound.Play();
                        PB1.Value += 10;
                        break;
                    case "Player2 Wins":
                        simpleSound = new SoundPlayer((PokName2.Content + "S.wav"));
                        simpleSound.Play();
                        PB2.Value += 10;
                        break;
                    default:
                        PB1.Value += 10;
                        PB2.Value += 10;
                        break;

                }
                
                
            }
            else
            {
                if (Play.iCount == 10)
                {
                        string time = (string)TimerL.Content;
                    Play.SetTime(time);
                    timer.Stop();
                    //diplay stats
                    Stats stats = new Stats(Play);
                    stats.ShowDialog();
                }
                SubmitButton.Content = "Submit";
                QuestionBox.Content = "VS";
                QuestionBox.Content = Play.GetQuestion();
                
            }


            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Gets color based on pokemon
        /// </summary>
        ///</return> hex
        private string GetColor(string sColor)
        {
            try
            {
                switch (sColor)
                {
                    case "Charmander":
                        return "#FFE8AF4B";
                    case "Squirtle":
                        return "#FFAECCDC";
                    case "Pikachu":
                        return "#FFECDB68";
                    case "Bulbasaur":
                        return "#FF93DAC8";
                    default:
                        return "#FF93DAC8";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets pathway for pics
        /// </summary>
        ///</return> Pathway
        private string GetPic(string sColor)
        {
            try
            {
                switch (sColor)
                {
                    case "Charmander":
                        return "C:\\Users\\aceof\\source\\repos\\PokemonGame\\Images\\Charmander.png";
                    case "Squirtle":
                        return "C:\\Users\\aceof\\source\\repos\\PokemonGame\\Images\\Squirtle.png";
                    case "Pikachu":
                        return "C:\\Users\\aceof\\source\\repos\\PokemonGame\\Images\\Pikachu.png";
                    case "Bulbasaur":
                        return "C:\\Users\\aceof\\source\\repos\\PokemonGame\\Images\\Bulb.png";
                    default:
                        return "C:\\Users\\aceof\\source\\repos\\PokemonGame\\Images\\Bulb.png";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
}
        /// <summary>
        /// changes images based on pokemon
        /// </summary>
        private void SetImages(string Pokemon1, string Pokemon2)
        {
            try
            {
                BitmapImage newImage1 = new BitmapImage();
                newImage1.BeginInit();
                newImage1.UriSource = new Uri(GetPic(Pokemon1));
                newImage1.EndInit();
                Image1.Source = newImage1;
                BitmapImage newImage2 = new BitmapImage();
                newImage2.BeginInit();
                newImage2.UriSource = new Uri(GetPic(Pokemon2));
                newImage2.EndInit();
                Image2.Source = newImage2;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }   
}
        /// <summary>
        /// gets infomation and colors for display
        /// </summary>
        private void SetUp()
        {
            try { 
            string[] Pokemons = new string[4] { "Pikachu", "Charmander", "Bulbasaur", "Squirtle" };

            var random = new Random();
            int index1, index2;
            string P1, P2;
            //get random for pokemon indexs
            index1 = random.Next() % 4;
            P1 = Pokemons[index1];
            do
            {
                index2 = random.Next() % 4;
            } while (index1 == index2);
            P2 = Pokemons[index2];
            PokName1.Content = P1;
            PokName2.Content = P2;
             //get colors
            string Hex1 = GetColor(P1);
            string Hex2 = GetColor(P2);
            // Change hex to colors
            BrushConverter brushConverter = new BrushConverter();
            Brush color1 = (Brush)brushConverter.ConvertFrom(Hex1);
            Brush color2 = (Brush)brushConverter.ConvertFrom(Hex2);
            BackGround1.Background = color1;
            BackGround2.Background = color2;
            SetImages(P1, P2);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// Cancels all windows
        /// </summary>
        private void Cancel1_Click(object sender, RoutedEventArgs e)
        {
            for (int window = App.Current.Windows.Count - 1; window >= 0; window--)
            {
                App.Current.Windows[window].Close();
            }
        }


    }
}
