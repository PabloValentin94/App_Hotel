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

    public partial class Calculos_Hospedagem : ContentPage
    {

        public Calculos_Hospedagem()
        {

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

        }

        private void btn_voltar_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();

        }
    }

}