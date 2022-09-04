using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Hotel.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Contratacao_Hospedagem : ContentPage
    {

        App PropriedadesApp;

        public Contratacao_Hospedagem()
        {

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

            pck_suite.ItemsSource = PropriedadesApp.tipos_de_suite;

            dtpck_checkin.MinimumDate = DateTime.Now.AddDays(3);

            dtpck_checkin.MaximumDate = dtpck_checkin.Date.AddDays(34);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);

            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddDays(35);

        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);

            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddDays(35);

        }

        private void btn_calcular_Clicked(object sender, EventArgs e)
        {



        }

    }

}