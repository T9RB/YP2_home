﻿using System.Collections.ObjectModel;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Windows;

namespace YP2_home;

public class Waiter2VM : ViewModelCafe
{
    private ObservableCollection<Order> ordesCollection = new(Helper.db.Orders.Include(x => x.IdStatusNavigation));
    private ObservableCollection<Dish> dishcCollection = new(Helper.db.Dishes);
    private RelayCommand adddish;
    private RelayCommand removedish;
    private RelayCommand newOrder;
    private Dish dish_sel;
    private Dish dish_sel2;
    private ObservableCollection<Dish> dish_col = new(Helper.db.Dishes.Where(x => x.NameDish == "dish"));
    private ObservableCollection<DishInOrder> dish_in_order;
    private decimal sum;
    public decimal Sum = 0;
    //zxc
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
                           MessageBox.Show("Вы не выбрали блюда!");
                           return;
                       }
                       Sum = 0;
                       foreach (Dish item in Dish_Col)
                       {
                           if (item != null)
                           {
                               Sum += item.Price;
                           }
                       }
                       Sumdish = Sum;
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
                    if (Dish_Sel2 != null)
                    {
                        Dish_Col.Remove(Dish_Col.FirstOrDefault(x => x.IdDish == Dish_Sel2.IdDish));
                    }
                    else if (Dish_Col.Count == 1)
                    {
                        Dish_Col.Clear();
                    }
                    if(Dish_Sel2 == null)
                    {
                        return;
                    }

                    Sum = 0;
                    foreach (Dish item in Dish_Col)
                    {
                        if (item != null)
                        {
                            Sum += item.Price;
                        }
                    }
                    Sumdish = Sum;

                    OnPropertyChanged();
                }));
        }
    }
    public RelayCommand NewOrder
    {
        get
        {
            return newOrder ??
                (newOrder = new RelayCommand((x) =>
                {
                    if (Dish_Col.Count != 0)
                    {
                        Order order = new Order()
                        {
                            IdStatus = 1,
                            Sum = Sum,
                            IdUsers = Helper.id_user,
                        };
                        Helper.db.Orders.Add(order);
                        Helper.db.SaveChanges();

                        foreach (Dish? item  in Dish_Col)
                        {
                            DishInOrder dishIns = new()
                            {
                                IdDish = item.IdDish,
                                IdOrder = Helper.db.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault().OrderId, //Сортировка по убыванию ID, поиск первого (по условию) OrderID
                            };
                            Helper.db.DishInOrders.Add(dishIns);
                            Helper.db.SaveChanges();
                        }
                        MessageBox.Show("Заказ добавлен.");
                    }
                     else
                     {
                        MessageBox.Show("Вы не выбрали блюда.");
                        return;
                     }

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
    public ObservableCollection<DishInOrder> DishInOfder
    {
        get => dish_in_order;
        set
        {
            dish_in_order = value;
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
    public decimal Sumdish 
    {
        get => sum;
        set
        {
            sum = value;
            OnPropertyChanged();
        }
    }
}
