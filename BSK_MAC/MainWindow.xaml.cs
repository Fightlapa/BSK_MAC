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
using System.Data.Entity;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;
using System.Threading;

namespace BSK_MAC
{
    public partial class MainWindow : Window
    {
        MainContext ctx;
        int g_clearanceLevel = 0;
        public MainWindow()
        {
            ctx = new MainContext();
#if false
                var m1 = from b in ctx.Miastas
                            where b.Nazwa.Equals("Sopot")
                            select b;
                //Miasto m1 = new Miasto() { Nazwa = "Sopot", Wojewodztwo = "Pomorskie",Classification = 1 };
                Garaz g1 = new Garaz() { PojemnoscCiezarowych = 1, PojemnoscOsobowych = 1, NazwaMiasta = m1.First<Miasto>() };
                
                //ctx.Miastas.Add(m1);
                ctx.Garazes.Add(g1);
                ctx.SaveChanges();
#endif
            InitializeComponent();
            PopulateAllDataGrids();

        }
        private void PopulateAllDataGrids()
        {
            ctx.Miastas.Load();
            ctx.Garazes.Load();
            ctx.Uzytkowniks.Load();
            //SamDataGrid.ItemsSource = dc.PodBazas;
            //ModDataGrid.ItemsSource = dc.Models;
            //ProDataGrid.ItemsSource = dc.Producents;
            //UmoDataGrid.ItemsSource = dc.Umowas;
            //DeaDataGrid.ItemsSource = dc.Dealers;
            MiaDataGrid.ItemsSource = ctx.Miastas.Local;
            GarDataGrid.ItemsSource = ctx.Garazes.Local;
            UsrDataGrid.ItemsSource = ctx.Uzytkowniks.Local;
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var changes = ctx.ChangeTracker.Entries()
            .Where(t => t.State != EntityState.Unchanged);
            foreach (var change in changes)
            {
                var baza = change.Entity as Baza;
                if (baza != null)
                {
                    if (baza.Classification >= g_clearanceLevel)//write up
                    {
                        //ok
                    }
                    else
                    {
                        change.State = EntityState.Detached;
                        MessageBox.Show("Wpis '" + baza.ToString() + "' był niezgodny z zasadą Write Up.");
                    }
                }
            }
            ctx.SaveChanges();
            PopulateAllDataGrids();
        }
        private void Row_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var uzytkownik = UsrDataGrid.SelectedItem as Uzytkownik;
            if (uzytkownik != null)
            {
                g_clearanceLevel = uzytkownik.Clearance;
                UsrLabel.Content = "Wybrany użytkownik: " + uzytkownik.ToString()+".";
            }
        }

        private void UpdateView(DataGrid dg)
        {
            var itemSource = dg.ItemsSource;
            foreach (Baza item in itemSource)
            {
                var row = dg.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (row != null)//TODO this is needed because wpf is lazy in loading data. When we open the tab for the first time this shall be null.. I should somehow first make sure this is populated so I can actually modify rows.
                {
                    
                    if ((item).Classification <= g_clearanceLevel)//read down
                    {
                        row.Height = double.NaN;
                    }
                    else
                    {
                        row.Height = 0.0;
                    }
                }

            }
        }

        DataGrid previousDataGridSelected = null;
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabMia.IsSelected && previousDataGridSelected != MiaDataGrid)//this is needed, because upon each click in datagrid wpf calls this ecent, and when we create a new row it is automatically set as 0 and then hidden, so we cant do anything
            {
                previousDataGridSelected = MiaDataGrid;
                UpdateView(MiaDataGrid);
            }
            if (TabGar.IsSelected && previousDataGridSelected != GarDataGrid)
            {
                previousDataGridSelected = GarDataGrid;
                UpdateView(GarDataGrid);
            }
            if (TabUsr.IsSelected && previousDataGridSelected != UsrDataGrid)
            {
                previousDataGridSelected = UsrDataGrid;
                // we dont do this for him UpdateView(GarDataGrid);
            }
        }
    }
}
