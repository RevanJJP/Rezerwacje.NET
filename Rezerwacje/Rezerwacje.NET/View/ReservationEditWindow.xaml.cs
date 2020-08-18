using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rezerwacje.NET
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class ReservationEditWindow : Window
    {
        private DataManager _dataManager;
        private ReservationViewObject _reservation;
        private bool _isReservationNew = false;

        public ReservationEditWindow(DataManager dataManager, ReservationViewObject reservation = null)
        {
            if(dataManager == null)
            {
                return;
            }

            _dataManager = dataManager;
            _reservation = reservation;
            
            InitializeComponent();
            SetupDataGrids();

            if (_reservation != null)
            { 
                FillForm(); 
            }
            else
            {
                _reservation = new ReservationViewObject();
                _isReservationNew = true;
                SetFormToNewReservation();
            }
        }

        private void FillForm()
        {
            if (_reservation == null) return;
            FromDatePicker.SelectedDate = _reservation.From;
            ToDatePicker.SelectedDate = _reservation.To;
            int roomNumber = (int)_reservation.RoomNumber;

            if (roomNumber > 0)
            {
                RoomViewObject room = _dataManager.GetRoom(roomNumber);
                foreach (var obj in RoomsDataGrid.Items)
                {
                    if (((RoomViewObject)obj).RoomNumber == room.RoomNumber)
                    {
                        RoomsDataGrid.SelectedItem = obj;
                        break;
                    }
                }
            }


            int guestId = (int)_reservation.getGuestId();
            if (guestId > 0)
            {
                GuestViewObject guest = _dataManager.GetGuest(guestId);
                foreach (var obj in GuestsDataGrid.Items)
                {
                    if (((GuestViewObject)obj).Id == guest.Id)
                    {
                        GuestsDataGrid.SelectedItem = obj;
                        break;
                    }
                }
            }
        }

        private void SetFormToNewReservation()
        {
            DeleteButton.IsEnabled = false;
        }

        private void SetupDataGrids()
        {
            RoomsDataGrid.ItemsSource = _dataManager.Rooms;
            GuestsDataGrid.ItemsSource = _dataManager.Guests;
        }

        private void NewGuestButton_Click(object sender, RoutedEventArgs e)
        {
            GuestFormWindow guestFormWindow = new GuestFormWindow();
            guestFormWindow.ShowDialog();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? fromDate = FromDatePicker.SelectedDate;
            if (fromDate == null)
            {
                WindowManager.ShowPopupMessage("Please select From date.");
                return;
            }
            _reservation.From = fromDate;

            DateTime? toDate = ToDatePicker.SelectedDate;
            if (toDate == null)
            {
                WindowManager.ShowPopupMessage("Please select To date.");
                return;
            }
            _reservation.To = toDate;

            RoomViewObject roomViewObject = (RoomViewObject) RoomsDataGrid.SelectedItem;
            if (roomViewObject == null)
            {
                WindowManager.ShowPopupMessage("Please select room.");
                return;
            }
            _reservation.setRoom(roomViewObject.RoomNumber);

            GuestViewObject guestViewObject = (GuestViewObject) GuestsDataGrid.SelectedItem;
            if(guestViewObject == null)
            {
                WindowManager.ShowPopupMessage("Please select guest.");
                return;
            }
            _reservation.setGuest(guestViewObject.Id);


            if (_isReservationNew)
            {
                _reservation.AddToDatabase(_dataManager.Context);
                WindowManager.ShowPopupMessage($"Created reservation no. {_reservation.Id} on {_reservation.GuestName} {_reservation.GuestSurname}.");
            }
            else
            {
                _reservation.SaveChangesToDatabase(_dataManager.Context);
                WindowManager.ShowPopupMessage($"Updated reservation no. {_reservation.Id} on {_reservation.GuestName} {_reservation.GuestSurname}.");
            }

            _dataManager.Update();
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            _reservation.RemoveFromDatabase(_dataManager.Context);
            _dataManager.Update();
            WindowManager.ShowPopupMessage($"Removed reservation.");
            this.Close();

        }
    }
}
