using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CepApp.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CepApp
{
    public partial class MainPage : ContentPage
    {
        async void Handle_Completed(object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            string cep = txtcep.Text;
            var json = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var dados = JsonConvert.DeserializeObject<Endereco>(json);

            lbllogradouro.Text = dados.logradouro;
            lblcomplemento.Text = dados.complemento;
            lblbairro.Text = dados.bairro;
            lbllocalidade.Text = dados.localidade;
            lbluf.Text = dados.uf;
            lblunidade.Text = dados.unidade;
            lblgia.Text = dados.gia;
            lblibge.Text = dados.ibge;
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
