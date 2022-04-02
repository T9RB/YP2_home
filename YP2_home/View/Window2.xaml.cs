using System.Windows;

namespace YP2_home
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            DataContext = new WaiterVM();
        }
    }
}
