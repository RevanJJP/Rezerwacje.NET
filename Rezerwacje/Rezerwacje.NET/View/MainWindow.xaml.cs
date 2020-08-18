using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Rezerwacje.NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataManager DataManager { get; }

        public MainWindow()
        {
            DataManager = new DataManager();
            DataManager.Update();

            InitializeComponent();
            UpdateReservationDataGrid();
        }

        private void NewReservationButton_Click(object sender, RoutedEventArgs e)
        {
            ReservationEditWindow reservationEditWindow = new ReservationEditWindow(DataManager);
            reservationEditWindow.ShowDialog();
            UpdateReservationDataGrid();
        }

        private void editReservationButton_Click(object sender, RoutedEventArgs e)
        {
            ReservationViewObject reservationObject = (ReservationViewObject) reservationsDataGrid.SelectedItem;
            if (reservationObject == null)
            {
                WindowManager.ShowPopupMessage("Select reservation to edit.");
                return;
            }

            ReservationEditWindow reservationEditWindow = new ReservationEditWindow(DataManager, reservationObject);
            reservationEditWindow.ShowDialog();
            UpdateReservationDataGrid();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateReservationDataGrid()
        {
            reservationsDataGrid.ItemsSource = DataManager.Reservations;
        }
    }
}
