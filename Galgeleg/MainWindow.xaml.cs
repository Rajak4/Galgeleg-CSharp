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

namespace Galgeleg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Test test = new Test();
        Logic logic = new Logic();
        string myWord;
        string imgPath = "Img/man/hangman";
        string imgType = ".png";

        public MainWindow()
        {
            InitializeComponent();

            GameStart();

            //MakeLetterBox();
            AddLetters();
            test.Win_test();

            playAgain.Visibility = Visibility.Hidden;
        }

        public void GameStart()
        {
            logic.ResetGame("badekar");
            myWord = logic.VisibleWord;
        }

        public void GameLoop()
        {
            if (logic.GameIsLost)
            {
                playAgain.Visibility = Visibility.Visible;
                Console.WriteLine("SPILLET ER TABT!");
            } else if (logic.GameIsWon)
            {
                playAgain.Visibility = Visibility.Visible;
                Console.WriteLine("SPILLET ER VUNDET!");
            } else
            {
                // gets the full image name
                string imageName = imgPath + logic.NumWrongLetters + imgType;

                // change the image
                BitmapImage image = new BitmapImage(new Uri(imageName, UriKind.RelativeOrAbsolute));
                hangmanImg.Source = image;
            }
            
        }

        public void MakeLetterBox()
        {
            TextBlock tb = new TextBlock
            {
                FontSize = 24,
                Text = "H"
            };

            Border border = new Border
            {
                BorderThickness = new Thickness(0, 0, 0, 4),
                BorderBrush = Brushes.Black,
                MinWidth = 15,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Child = tb
            };
        }

        // Adding textBlocks to the stackpanel - each holding 1 letter of the word
        public void AddLetters()
        {
            for(int i = 0; i < myWord.Length; i++)
            {
                myStackPanel.Children.Add(new TextBlock
                {
                    Name = "letter" + i,
                    FontSize = 24,
                    Padding = new Thickness(5),
                    Text = myWord[i].ToString().ToUpper()
                });
            }
        }

        // Look through all children in stackpanel and update each textBlock
        public void UpdateLetters(string updatedWord)
        {
            for (int i = 0; i < myStackPanel.Children.Count; i++)
            {
                object child = myStackPanel.Children[i];
                if (child is FrameworkElement)
                {
                    (child as TextBlock).Text = updatedWord[i].ToString();
                }
            }
        }

        // returns the letter from keyboard input
        private string GetLetter(KeyEventArgs key)
        {
            // get a to z
            if (key.Key >= Key.A && key.Key <= Key.Z)
            {
                return key.Key.ToString();
            }

            // get æ, ø and å
            switch (key.Key)
            {
                case Key.Oem3:
                    return "Æ";
                case Key.OemQuotes:
                    return "Ø";
                case Key.Oem6:
                    return "Å";
            }

            // return empty string if not a letter
            return "";
        }

        // gets keyboard inputs
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string letter = GetLetter(e);
            if (letter.Length > 0) {
                Console.WriteLine("letter " + letter);
                logic.SubmitLetter(letter);
                UpdateLetters(logic.VisibleWord);
                GameLoop();

            } else
            {
                Console.WriteLine("ikke letter");
            }
        }

        private void playAgain_Click(object sender, RoutedEventArgs e)
        {
            
            logic.ResetGame();
           // UI skal også resettes
        }
    }
}
