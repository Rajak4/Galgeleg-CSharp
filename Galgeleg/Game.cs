using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Galgeleg
{
    class Game : Window
    {
        Logic logic = new Logic();
        MainWindow MainWin = new MainWindow();
        private string myWord;
        StackPanel MyStackPanel;

        public Game(StackPanel st)
        {
            //MainWin.SendOver += hej;
            this.MyStackPanel = st;
            
        }
        
        public void GameLoop()
        {
            Console.WriteLine("start");
            logic.ResetGame("badekar");
            myWord = logic.VisibleWord;
            AddLetters();
        }
       

        public void hej(object sender, EventArgs e)
        {
            Console.WriteLine($"fra game {e.ToString()}");
        }

        // Adding textBlocks to the stackpanel - each holding 1 letter of the word
        public void AddLetters()
        {
            for (int i = 0; i < myWord.Length; i++)
            {
                MyStackPanel.Children.Add(new TextBlock
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
            for (int i = 0; i < MyStackPanel.Children.Count; i++)
            {
                object child = MyStackPanel.Children[i];
                if (child is FrameworkElement)
                {
                    (child as TextBlock).Text = updatedWord[i].ToString();
                }
            }
        }

        

    }
}
