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

        public MainWindow()
        {
            InitializeComponent();
            StackPanel st = myStackPanel;
            Game game = new Game(st);
            game.GameLoop();
            //MakeLetterBox();
            
            test.WinTest();
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

        public event EventHandler SendOver;

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (SendOver != null)
            {
                SendOver(this, e);
            }
            string letter = GetLetter(e);
            if (letter.Length > 0)
            {
                Console.WriteLine("letter " + letter);
                //logic.SubmitLetter(letter);
                //game.UpdateLetters(logic.VisibleWord);
            }
            else
            {
                Console.WriteLine("ikke letter");
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
