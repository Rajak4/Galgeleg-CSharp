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
        Game game = new Game();
        Logic logic = new Logic();
        string myWord;

        public MainWindow()
        {
            InitializeComponent();
            
            logic.ResetGame("badekar");
            myWord = logic.VisibleWord;

            //MakeLetterBox();
            AddLetters();
            game.Test();
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string letter = GetLetter(e);
            if (letter.Length > 0) {
                Console.WriteLine("letter " + letter);
                logic.SubmitLetter(letter);
                UpdateLetters(logic.VisibleWord);
            } else
            {
                Console.WriteLine("ikke letter");
            }
        }


        /*
        public void ShowLetterFields()
        {
            StackPanel sp = new StackPanel
            {
                Name = "myPanel",
                Orientation = Orientation.Horizontal
            };
            myStackPanel.Children.Add(sp);
            
            for (int i = 0; i < 5; i++)
            {


                TextBlock tb = new TextBlock
                {
                    Name = "myTb" + i,
                    FontSize = 24,
                    Text = "H"
                };

                sp.Children.Add(new Border
                {
                    BorderThickness = new Thickness(0, 0, 0, 4),
                    BorderBrush = Brushes.Black,
                    MinWidth = 15,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Child = tb
                });
            }
        }
        */
    }
}
