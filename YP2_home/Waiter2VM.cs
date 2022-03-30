using System.Collections.ObjectModel;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace YP2_home;

public class Waiter2VM : ViewModelCafe
{
    private ObservableCollection<Order> ordesCollection = new(Helper.db.Orders.Include(x => x.IdStatusNavigation));
    private ObservableCollection<Dish> dishcCollection = new(Helper.db.Dishes);
    private RelayCommand adddish;
    private RelayCommand removedish;
    private Dish dish_sel;
    private Dish dish_sel2;
    private ObservableCollection<Dish> dish_col = new(Helper.db.Dishes);
    public decimal sumdish = 0;
    public decimal sumdish2 = 0;


    public RelayCommand AddDish
    {
        get
        {
            return adddish ??
                   (adddish = new RelayCommand((x) =>
                   {
                       if (Dish_Sel != null)
                       {
                           Dish_Col.Add(Helper.db.Dishes.FirstOrDefault(x => x.NameDish == Dish_Sel.NameDish));
                       }
                       if (Dish_Sel == null)
                       {
                           return;
                       }
                       foreach (Dish item in Dish_Col)
                       {
                           sumdish += item.Price;
                       }
                       sumdish2 = sumdish;
                       OnPropertyChanged();
                   }));
        }

    }
    public RelayCommand RemoveDish
    {
        get
        {
            return removedish ??
                (removedish = new RelayCommand((x) =>
                {
                    if (Dish_Sel2 != null && Dish_Col.Count != 0)
                    {
                        Dish_Col.Remove(Dish_Col.FirstOrDefault(x => x.NameDish == Dish_Sel2.NameDish));
                    }
                    if (Dish_Sel2 == null)
                    {
                        return;
                    }
                    if (Dish_Col.Count != 0)
                    {
                        foreach (Dish item in Dish_Col)
                        {
                            sumdish2 -=item.Price;
                        }
                    }
                    OnPropertyChanged();
                }));
        }
    }


   

    public Dish Dish_Sel2
    {
        get => dish_sel2;
        set
        {
            dish_sel2 = value;
            OnPropertyChanged();
        }
    }

    public Dish Dish_Sel
    {
        get => dish_sel;
        set
        {
            dish_sel = value;
            OnPropertyChanged();
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
    public ObservableCollection<Dish> Dish_Col
    {
        get => dish_col;
        set
        {

            dish_col = value;
            OnPropertyChanged();
        }
    }
}
