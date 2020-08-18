using Rezerwacje.NET.ViewModel;
using Rezerwacje.NET.ViewModel.ViewObjects;
using System;
using System.Collections.Generic;
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
    public partial class GuestFormWindow : Window
    {
        private DataManager _dataManager;
        public GuestFormWindow(DataManager dataManager)
        {
            _dataManager = dataManager;
            InitializeComponent();
        }

        private void AddGuestButton_Click(object sender, RoutedEventArgs e)
        {
            GuestViewObject guest = new GuestViewObject();
            guest.Name = NameForm.Text;
            guest.Surname = SurnameForm.Text;
            guest.Email = EmailForm.Text;
            guest.Phone = PhoneForm.Text;


            guest.AddToDatabase(_dataManager.Context);
            WindowManager.ShowPopupMessage($"Created new guest: {guest.Name} {guest.Surname}.");
            _dataManager.Update();
        }
    }
}
