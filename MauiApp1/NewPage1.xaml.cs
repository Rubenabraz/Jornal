using NewsAPI; 
using NewsAPI.Models; 
using NewsAPI.Constants; 
using System.Collections.ObjectModel; 

namespace MauiApp1
{
    public partial class NewPage1 : ContentPage
    {
        // Lista observável para armazenar os artigos de notícias.
        public ObservableCollection<Article> Articles { get; private set; }

        public NewPage1()
        {
            InitializeComponent(); 
            Articles = new ObservableCollection<Article>(); // Cria uma nova lista observável.
            BindingContext = this; // Define o contexto de ligação (Binding) para esta classe.
        }

        // Método chamado automaticamente quando a página aparece na tela.
        protected override async void OnAppearing()
        {
            base.OnAppearing(); // Chama a implementação base do método (boas práticas).

            try
            {
                

                Console.WriteLine("Fetching news...");

              

                var newsApiClient = new NewsApiClient("677de4d51d3a4b2d97f1cef7ac4d7ec8");

                // Faz uma requisição para buscar os destaques de notícias (headlines).

                var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Country = Countries.US,

                    Category = Categories.Technology, 

                    PageSize = 20

                });

                // Verifica se a resposta foi bem-sucedida e se há artigos disponíveis.

                if (articlesResponse.Status == Statuses.Ok && articlesResponse.Articles != null)
                {
                  

                    Console.WriteLine($"Total articles: {articlesResponse.TotalResults}");

                    

                    Articles.Clear();

                    // Adiciona cada artigo retornado à lista observável.

                    foreach (var article in articlesResponse.Articles)
                    {
                        Articles.Add(article);
                    }
                }
                else
                {
                    // Log se a resposta falhar ou se nenhum artigo for encontrado.

                    Console.WriteLine("Failed to fetch articles or no articles found.");
                }
            }
            catch (Exception ex)
            {

              

                Console.WriteLine($"Error fetching news: {ex.Message}");
            }
        }
    }
}
