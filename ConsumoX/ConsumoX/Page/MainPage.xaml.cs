using ConsumoX.Model;
using ConsumoX.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsumoX
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HttpService<ListaUsuarios> getService;
        HttpService<Funcionario> postService;
        public MainPage()
        {
            InitializeComponent();
            getService = new HttpService<ListaUsuarios>("https://reqres.in/", "/api/users");
            postService = new HttpService<Funcionario>("https://reqres.in/", "/api/users");
        }
        private async void BtnGet_Clicked(object sender, EventArgs e)
        {
            var lista = await getService.Get(this.txtPage.Text);

            foreach (var usuario in lista.data)
            {
                this.lblRetornoGet.Text += $"{usuario.first_name}  ";
            }
        }

        private async void BtnPost_Clicked(object sender, EventArgs e)
        {
            Funcionario enviar = new Funcionario { name = this.txtName.Text, job = this.txtJob.Text};

            var retorno = await postService.Post(enviar);

            lblRetornoPost.Text = retorno.createdAt.ToShortTimeString();
        }
    }
}
