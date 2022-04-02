using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace YP2_home;

public class CooksVM : ViewModelCafe
{
    private ObservableCollection<Order> selOrder = new(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 3 || x.IdStatus == 2));
    private RelayCommand sort;
    private ObservableCollection<Order> orders = new(Helper.db.Orders.Include(x => x.IdStatusNavigation).Where(x => x.IdStatus == 4));
    private Order selorder;
    private RelayCommand updatebutton;
    public RelayCommand Sort => sort ??
                   (sort = new RelayCommand((x) =>
                   {
                       Order? order_st = SelectedOrder;
                       if (order_st == null)
                       {
                           MessageBox.Show("Выберите заказ!");
                           return;
                       }

                       if (order_st != null)
                       {
                           order_st.IdStatus = 4;
                           Helper.db.SaveChanges();
                           ColOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 3));
                           NewOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                               .Where(x => x.IdStatus == 4));
                           OnPropertyChanged();
                       }

                   }));
    public RelayCommand UpdateButton => updatebutton ??
                (updatebutton = new RelayCommand((x) =>
                {
                    Order? order_st = SelectedOrder;
                    if (order_st == null)
                    {
                        MessageBox.Show("Выберите заказ!");
                        return;
                    }

                    if (order_st != null)
                    {
                        order_st.IdStatus = 3;
                        Helper.db.SaveChanges();
                        ColOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                            .Where(x => x.IdStatus == 3));
                        NewOrders = new ObservableCollection<Order>(Helper.db.Orders.Include(x => x.IdStatusNavigation)
                            .Where(x => x.IdStatus == 4));
                        OnPropertyChanged();
                    }

                }));

    public Order SelectedOrder
    {
        get => selorder;
        set
        {
            selorder = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Order> ColOrders
    {
        get => selOrder;
        set
        {
            selOrder = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Order> NewOrders
    {
        get => orders;
        set
        {
            orders = value;
            OnPropertyChanged();
        }
    }

}