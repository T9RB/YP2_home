using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
namespace YP2_home;

public class WaiterVM : ViewModelCafe
{
    private ObservableCollection<Order> collection_ord =
        new(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 1));

    private ObservableCollection<Order> payOrd = new(Helper.db.Orders
        .Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 2));
    private Order sOrder;
    private ObservableCollection<Dish> dish = new(Helper.db.Dishes);
    private RelayCommand upd_st;
    private RelayCommand norder;
    private RelayCommand upd_col;


    public RelayCommand Upd_St => upd_st ??
                   (upd_st = new RelayCommand((x) =>
                   {
                       Order? order_st = SOrder;
                       if (order_st == null)
                       {
                           MessageBox.Show("Выберите заказ, чтобы изменить статус.");
                           return;
                       }

                       if (order_st != null)
                       {
                           order_st.IdStatus = 2;
                           Helper.db.SaveChanges();
                           Collection_ord = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 1));
                           PayOrd = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 2));
                           OnPropertyChanged();
                       }

                   }));

    public RelayCommand NOrder => norder ??
                   (norder = new RelayCommand((x) =>
                   {
                       new Window3().Show();
                       Helper.db.SaveChanges();
                       Collection_ord = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                           .Where(x => x.IdStatus == 1));
                       PayOrd = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                           .Where(x => x.IdStatus == 2));
                       OnPropertyChanged();
                   }));
    public RelayCommand Update_Col => upd_col ??
                (upd_col = new RelayCommand((x) =>
                {
                    Collection_ord = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 1));
                    OnPropertyChanged();
                }));

    public ObservableCollection<Dish> Dish_l
    {
        get => dish;
        set
        {
            dish = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Order> PayOrd
    {
        get => payOrd;
        set
        {
            payOrd = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<Order> Collection_ord
    {
        get => collection_ord;
        set
        {
            collection_ord = value;
            OnPropertyChanged();
        }
    }
    public Order SOrder
    {
        get => sOrder;
        set
        {
            sOrder = value;
            OnPropertyChanged();
        }
    }
}
