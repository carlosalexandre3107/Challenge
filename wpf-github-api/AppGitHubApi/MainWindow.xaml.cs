using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Octokit;

namespace AppGitHubApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private GitHubClient gitHubClient;
        private string loginDoUsuario;
        private string senhaDoUsuario;

        public MainWindow() {
            InitializeComponent();
            gitHubClient = new GitHubClient(new ProductHeaderValue("octokit"));
        }

        private void LogarNoGitHub(object sender, RoutedEventArgs e) {
            if (CapiturandoEhValidandoLoginEhSenha()) {
                if (ValidarAcessoAoGitHub())
                    ExibirBuscaDeRepositorios();
            }
        }

        private void BuscarPorRepositoriosDoUsuario(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(NomeUsuarioGitHub.Text))
                    BuscaRepositorioDoUsuario();
                else
                    ExibirAlertaDeErro("Usuário não encontrado.");
            }
            catch (Exception ex)
            {
                ExibirAlertaDeErro(ex.InnerException.Message);
            }
        }

        private bool CapiturandoEhValidandoLoginEhSenha() {
            bool loginEhValido = false;

            loginDoUsuario = LoginDoGitHub.Text;
            senhaDoUsuario = SenhaDoGitHub.Password;

            if (!string.IsNullOrEmpty(loginDoUsuario) && !string.IsNullOrEmpty(senhaDoUsuario))
                loginEhValido = true;
            else
                ExibirAlertaDeErro("Informe seu usuário e senha.");

            return loginEhValido;
        }

        private void ExibirAlertaDeErro(string mensagem) {
            MessageBox.Show(mensagem, "Alerta de erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ExibirGridDeRepositorios() {
            labelListaDeRepositorios.Visibility = Visibility.Visible;
            dataGridRepositorios.Visibility = Visibility.Visible;
        }

        private void ExibirBuscaDeRepositorios() {
            labelUsuarioGitHub.Visibility = Visibility.Visible;
            NomeUsuarioGitHub.Visibility = Visibility.Visible;
            buttonBuscar.Visibility = Visibility.Visible;
        }

        private bool ValidarAcessoAoGitHub() {
            Credentials credencialBase = new Credentials(loginDoUsuario, senhaDoUsuario);
            gitHubClient.Credentials = credencialBase;

            bool credencialValida = gitHubClient.User.Get(loginDoUsuario).Result != null ? true : false;
            return credencialValida;
        }

        private void BuscaRepositorioDoUsuario() {
            var usuarioPesquisado = new SearchRepositoriesRequest() { User = NomeUsuarioGitHub.Text };
            SearchRepositoryResult retornoDaBusca = gitHubClient.Search.SearchRepo(usuarioPesquisado).Result;
            PreencherGridComRepositorios(retornoDaBusca);
        }

        private void PreencherGridComRepositorios(SearchRepositoryResult retornoDaBusca) {
            if (retornoDaBusca != null) {
                LimparDataGrid();
                if (retornoDaBusca.Items.Any()) {
                    ExibirGridDeRepositorios();

                    var listaDeRepositorioModel = new List<RepositorioModel>();
                    foreach (var item in retornoDaBusca.Items) {
                        listaDeRepositorioModel.Add(new RepositorioModel(item.Id, item.Name, item.HtmlUrl));
                    }
                    dataGridRepositorios.ItemsSource = listaDeRepositorioModel;
                }
                else {
                    ExibirAlertaDeErro("O usuário informado não possui repositórios.");
                }
            }
            else {
                ExibirAlertaDeErro("Repositório do usuário não foi encontrado.");
            }
        }

        private void LimparDataGrid()
        {
            dataGridRepositorios.Items.Clear();
        }
    }

    public class RepositorioModel {
        public RepositorioModel(long id, string nome, string url) {
            Id = id.ToString();
            Nome = nome;
            Url = url;
        }

        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Url { get; private set; }
    }
}
