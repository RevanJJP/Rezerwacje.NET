using Rezerwacje.NET.Model;
using Rezerwacje.NET.ViewModel;
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
        private ReservationsHandler _reservationsHandler;
        private Reservation _reservation;
        public ReservationEditWindow(ReservationsHandler reservationsHandler, Reservation reservation = null)
        {
            if(reservationsHandler == null)
            {
                return;
            }

            _reservationsHandler = reservationsHandler;
            _reservation = reservation;
            
            InitializeComponent();

            if (_reservation != null) FillForm();
            else SetFormToNewReservation();
        }

        private void FillForm()
        {

        }

        private void SetFormToNewReservation()
        {

        }

    }
}
