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

                // Convertendo os textos da labels:

                int qnt_adultos = Convert.ToInt32(lbl_qnt_adultos.Text);

                int qnt_criancas = Convert.ToInt32(lbl_qnt_criancas.Text);

                // Criando memsagens para possíveis erros: 

                if(qnt_adultos.Equals(0) && qnt_criancas.Equals(0))
                {

                    throw new Exception("Adicione ao menos uma pessoa antes de prosseguir.");

                }

                else if (qnt_adultos.Equals(0) && qnt_criancas != 0)
                {

                    throw new Exception("Adicione ao menos um responsável pela(s) criança(s).");

                }

                else
                {

                    Model.Suites suite_escolhida = (Model.Suites)pck_suite.SelectedItem;

                    if (suite_escolhida == null)
                    {

                        throw new Exception("Escolha uma suite antes de prosseguir.");

                    }

                    else
                    {

                        // Criando o objeto "dados_hospedagem":

                        Model.Hospedagem dados_hospedagem = new Model.Hospedagem()
                        {

                            suite = suite_escolhida,

                            /* Apesar de terem o mesmo nome, não são a mesma coisa. As variáveis que vem antes
                             * do igual, referem-se a variáveis do objeto, e as que vem depois, referem-se a
                             variáveis locais. */

                            qnt_adultos = qnt_adultos,

                            qnt_criancas = qnt_criancas,

                            // Calculando a quantidade de dias que o usuário ficará no hotel:

                            qnt_dias = Model.Hospedagem.Tempo_Estadia(dtpck_checkin.Date, dtpck_checkout.Date),

                            data_checkin = dtpck_checkin.Date,

                            data_checkout = dtpck_checkout.Date

                        };

                        // Calculando o valor da estadia:

                        dados_hospedagem.valor_total = dados_hospedagem.Valor_Estadia();

                        /* A palavra "var" serve para quando não sabemos o tipo de uma variável e, portanto,
                         * o sistema será o responsável por determinar isso. O sistema irá analizar o que é colocado dentro
                         * da variável em específico para então depois determinar seu tipo. Um exemplo, é se o valor da
                         * variável "tela_de_calculos" fosse o número dois. O sistema iria analizar que isso é um número
                         * inteiro e, então, definiria o tipo dessa variável como "int". */

                        var tela_de_calculos = new Calculos_Hospedagem();

                        /* intruindo ao sistema que procure o objeto "dados_hospedagem" e que permita o uso de seus dados na
                         * página "tela_de_calculos". */

                        tela_de_calculos.BindingContext = dados_hospedagem;

                        // Abrindo a página "tela_de_calculos".

                        await Navigation.PushAsync(tela_de_calculos);

                    }

                }

            }

            catch(Exception ex)
            {

                await DisplayAlert("Aviso!", ex.Message, "OK");

            }

        }

    }

}