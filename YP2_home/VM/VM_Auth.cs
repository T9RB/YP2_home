using System.Linq;
using System.Windows;
namespace YP2_home;

public class VM_Auth : ViewModelCafe
{
    private string login;
    private string password;
    private string ac_auth = "Войти";
    private RelayCommand auth;

    public RelayCommand Auth => auth ??
                   (auth = new RelayCommand((x) =>
                   {
                       string command = "Вы вошли";
                       User? selUs = Helper.db.Users.FirstOrDefault(x => x.LoginUs == Login && x.PasswordUs == Password);

                       if (selUs == null)
                       {
                           MessageBox.Show("Неверный логин или пароль");
                           return;
                       }

                       if (selUs.IdRole == 1)
                       {
                           new Window1().Show();
                           Helper.id_user = 1;
                           Ac_auth = command;
                           OnPropertyChanged();
                       }

                       if (selUs.IdRole == 2)
                       {
                           new Window2().Show();
                           Helper.id_user = 2;
                           Ac_auth = command;
                           OnPropertyChanged();
                       }

                   }));
    public string Login
    {
        get => login;
        set => login = value;
    }
    public string Password
    {
        get => password;
        set => password = value;
    }
    public string Ac_auth
    {
        get => ac_auth;
        set
        {
            ac_auth = value;
            OnPropertyChanged();
        }
    }
}