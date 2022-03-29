using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace YP2_home;

public class Waiter2VM : ViewModelCafe
{
    private ObservableCollection<Order> ordesCollection = new(Helper.db.Orders.Include(x => x.IdStatusNavigation));
    private ObservableCollection<Dish> dishcCollection = new(Helper.db.Dishes);
    private RelayCommand neworder;


    public RelayCommand NewOrder
    {
        get
        {
            return neworder ??
                   (neworder = new RelayCommand((x) =>
                   {

                   }));
        }
    }





    public ObservableCollection<Order> OrdersCollection
    {
        get => ordesCollection;
        set
        {
            ordesCollection = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Dish> DishCollection
    {
        get => dishcCollection;
        set
        {
            dishcCollection = value;
            OnPropertyChanged();
        }
    }
}