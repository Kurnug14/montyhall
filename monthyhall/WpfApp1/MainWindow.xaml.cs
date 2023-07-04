using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*initialize some variables and objects that are needed to invoke the methods*/
        int tracker = 0;
        DoorGenerator doors = new DoorGenerator();
        GameLogic game = new GameLogic();
        Statistics stats = new Statistics();
        Button eliminate = new Button();
        Image eleimage = new Image();
        string selector = "";
        string stringimage = "";
        string choice = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        /*class that initiates objects to manipulate XAML elements*/
        public void DoorChoice(object sender, RoutedEventArgs e)
        {
            tracker++;
            bool stayed = false;

            Button button = (Button)sender;
            if (tracker==1)
                {
                    choice = button.Name;
                    selector = game.Gaming(button.Name, doors);
                    stringimage = selector+"img";
                    eleimage = FindName(stringimage) as Image;
                    eliminate = (Button)FindName(selector);
                    eleimage.Source = new BitmapImage(new Uri("goat.jpg", UriKind.Relative));
                    eliminate.Visibility = Visibility.Collapsed;
            }
            else if (tracker==2)
                {
                 if (button.Name==choice)
                 {
                        stayed= true;
                 }
                bool win = game.FinalChoice(button.Name, doors);
                foreach (int rest in doors._numbers)
                {
                    if (doors._doors[doors._numbers.IndexOf(rest)]==true)
                    {
                        eleimage = FindName("door" + rest + "img") as Image;
                        eleimage.Source = new BitmapImage(new Uri("car.jpg", UriKind.Relative));
                    }
                    else
                    {
                        eleimage = FindName("door" + rest + "img") as Image;
                        eleimage.Source = new BitmapImage(new Uri("goat.jpg", UriKind.Relative));
                    }
                }
                stats.Accessor(stayed, win);
                changebar.Value = (stats._ratioChange*100);
                staybar.Value = (stats._ratioStay*100);
                changenumber.Content = (stats._ratioChange * 100+"%");
                staynumber.Content = (stats._ratioStay * 100 + "%");
            }
            else if(tracker==3)
            {
                door1img.Source = new BitmapImage(new Uri("door.png", UriKind.Relative));
                door1.Visibility = Visibility.Visible;
                door2img.Source = new BitmapImage(new Uri("door.png", UriKind.Relative));
                door2.Visibility = Visibility.Visible;
                door3img.Source = new BitmapImage(new Uri("door.png", UriKind.Relative));
                door3.Visibility = Visibility.Visible;
                doors = new DoorGenerator();
                game = new GameLogic();
                tracker= 0;
                selector = "";
            }
        }
    }
}

