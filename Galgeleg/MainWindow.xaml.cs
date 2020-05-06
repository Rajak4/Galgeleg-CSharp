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
        public MainWindow()
        {
            InitializeComponent();
            Game game = new Game();
            ShowLetterFields();
            //MakeLetterBox();
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
    }
}
