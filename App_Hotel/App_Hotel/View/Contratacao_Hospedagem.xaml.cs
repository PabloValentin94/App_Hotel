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

            // Desabilitando a barra de navegação:

            NavigationPage.SetHasNavigationBar(this, false);

            // Definindo uma variável com as mesmas funcionalidades do arquivo App:

            PropriedadesApp = (App)Application.Current;

            // Inserindo itens itens dentro do Picker, através da lista "tipos_de_suite":

            pck_suite.ItemsSource = PropriedadesApp.tipos_de_suite;

            // Configurando os DatePickers:

            dtpck_checkin.MinimumDate = DateTime.Now.AddDays(3);

            dtpck_checkin.MaximumDate = dtpck_checkin.Date.AddDays(34);

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);

            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddDays(35);

        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {

            /* Esse método é chamado quando o usuário selecionar uma data no DatePicker de check-in,
             * redefinindo a data mínima/máxima de saída. */

            dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);

            dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddDays(35);

        }

        private async void btn_calcular_Clicked(object sender, EventArgs e)
        {

            try
            {

                int qnt_adultos = Convert.ToInt32(lbl_qnt_adultos.Text);

                int qnt_criancas = Convert.ToInt32(lbl_qnt_criancas.Text);

                if(qnt_adultos.Equals(0) && qnt_criancas.Equals(0))
                {

                    throw new Exception("Adicione ao menos uma pessoa antes de prosseguir.");

                }

                else if (qnt_adultos.Equals(0) && qnt_criancas != 0)
                {

                    throw new Exception("Adicione ao menos um responsável pelas crianças.");

                }

            }

            catch(Exception ex)
            {

                await DisplayAlert("Aviso!", ex.Message, "OK");

            }

        }

    }

}