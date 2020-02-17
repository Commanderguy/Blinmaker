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
using System.Windows.Media.Animation;

namespace Cooker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


        // Data for Margin of the Group Box
        // Unexpanded = -20
        //Expanded    = -50


    public static class CookerLogic
    {
        public const int eggsMin = 1;
        public const int milkMin = 200;
        public const int flourMin = 100;
    }

    public partial class MainWindow : Window
    {
        Thickness newThick;
        private bool easterEggActivated = true;

        public List<Tuple<int, int, int, string>> EasterEggs = new List<Tuple<int, int, int, string>>();


/**////////////////////////////////////////////////////////////////////////////////////////////////
/**/    private void addEasterEgg(int Eggs, int Milk, int Flour, string message)                 ///
/**/    {                                                                                       ///
/**/        EasterEggs.Add(new Tuple<int, int, int, string>(Eggs, Milk, Flour, message));        ///
/**/    }                                                                                       ///
/**/    private void easterEggHandler(int val1, int val2, int val3)                             ///
/**/    {                                                                                       ///
/**/        foreach(var x in EasterEggs)                                                        ///     Comment out to delete Easter eggs
/**/        {                                                                                   ///
/**/            if(val1 == x.Item1 && val2 == x.Item2 && val3 == x.Item3)                       ///
/**/            {                                                                               ///
/**/                HowMany.Text = x.Item4;                                                     ///
/**/            }                                                                               ///
/**/        }                                                                                   ///
/**/    }                                                                                       /// 
/**////////////////////////////////////////////////////////////////////////////////////////////////



        public void calculateBlin()
        {
            try
            {
                
                int eggsAmountX = Convert.ToInt32(EggsAmount.Text) / CookerLogic.eggsMin;
                int milkAmountX = Convert.ToInt32(MilkAmount.Text) / CookerLogic.milkMin;
                int flourAmountX = Convert.ToInt32(FlourAmount.Text) / CookerLogic.flourMin;

                int amount;

                if (eggsAmountX < milkAmountX && eggsAmountX < flourAmountX)
                {
                    amount = (eggsAmountX * 4);
                }
                else if (milkAmountX < eggsAmountX && milkAmountX < flourAmountX)
                {
                    amount = (milkAmountX * 4);
                }
                else
                {
                    amount = (flourAmountX * 4);
                }
                AmountCanInt.Text = amount.ToString();
                if(amount == 0)
                {
                    HowMany.Text = "No blin today :(";

                    //                            If commented out, the window wont get small again if you have 0 blins
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    /*newThick = Margin;
                    newThick.Bottom = -20;
                    this.BeginAnimation(Window.MarginProperty, new System.Windows.Media.Animation.ThicknessAnimation(newThick, TimeSpan.FromSeconds(1)));
                    this.BeginAnimation(Window.HeightProperty, new System.Windows.Media.Animation.DoubleAnimation(240, TimeSpan.FromSeconds(1)));*/ 

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    
                }
                else
                {
                    amount /= 4;
                    HowMany.Text = "You will need " + amount * CookerLogic.eggsMin + " eggs,\n" + amount * CookerLogic.milkMin + "ml milk and \n" + amount * CookerLogic.flourMin + "g flour";
                    this.BeginAnimation(Window.HeightProperty, new System.Windows.Media.Animation.DoubleAnimation(270, TimeSpan.FromSeconds(1)));
                    newThick = Margin;
                    newThick.Bottom = -50;
                    this.BeginAnimation(Window.MarginProperty, new System.Windows.Media.Animation.ThicknessAnimation(newThick, TimeSpan.FromSeconds(1)));
                }

                // Comment this out to delete the eastereggs
                if (!easterEggActivated) { return; }
                easterEggHandler(Convert.ToInt32(EggsAmount.Text), Convert.ToInt32(MilkAmount.Text), Convert.ToInt32(FlourAmount.Text));
            }
            catch(System.NullReferenceException)
            {
                return;
            }
            catch(System.FormatException)
            {
                return;
            }
            
        }
        public MainWindow()
        {
            InitializeComponent();
            // You can add Easter eggs at this point
            addEasterEgg(12, 30, 1922, "Славься, Отече...\nPress e to deactivate EasterEggs");
            addEasterEgg(7, 6, 2012, "THIS is $200 Laptop\nWell, more like $195\nPress e to deactivate EasterEggs");

            easterEggActivated = true;
        }

        private void FlourAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBlin();
        }

        private void MilkAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBlin();
        }

        private void EggsAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBlin();
        }

        private void ColumnDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void EggsAmount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void EggsAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(EggsAmount.Text) == 0)
            {
                EggsAmount.Text = "";
            }
            }catch(System.FormatException)
            {
                return;
            }
}

        private void MilkAmount_GotFocus(object sender, RoutedEventArgs e)
        {
    try
    {
            if (Convert.ToInt32(MilkAmount.Text) == 0)
            {
                MilkAmount.Text = "";
            }
            }catch(System.FormatException)
            {
                return;
            }
}

        private void FlourAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(FlourAmount.Text) == 0)
                {
                    FlourAmount.Text = "";
                }
            }catch(System.FormatException)
            {
                return;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.E)
            {
                easterEggActivated = false;
            }
        }
    }
}
