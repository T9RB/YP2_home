using System.Windows;

namespace YP2_home
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            DataContext = new Waiter2VM();
        }
    }
}
