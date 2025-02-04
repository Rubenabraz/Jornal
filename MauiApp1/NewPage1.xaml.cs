using NewsAPI; 
using NewsAPI.Models; 
using NewsAPI.Constants; 
using System.Collections.ObjectModel; 

namespace MauiApp1
{
    public partial class NewPage1 : ContentPage
    {
        // Lista observ�vel para armazenar os artigos de not�cias.
        public ObservableCollection<Article> Articles { get; private set; }

        public NewPage1()
        {
            InitializeComponent(); 
            Articles = new ObservableCollection<Article>(); // Cria uma nova lista observ�vel.
            BindingContext = this; // Define o contexto de liga��o (Binding) para esta classe.
        }

        // M�todo chamado automaticamente quando a p�gina aparece na tela.
        protected override async void OnAppearing()
        {
            base.OnAppearing(); // Chama a implementa��o base do m�todo (boas pr�ticas).

            try
            {
                

                Console.WriteLine("Fetching news...");

              

                var newsApiClient = new NewsApiClient("677de4d51d3a4b2d97f1cef7ac4d7ec8");

                // Faz uma requisi��o para buscar os destaques de not�cias (headlines).

                var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
                {
                    Country = Countries.US,

                    Category = Categories.Technology, 

                    PageSize = 20

                });

                // Verifica se a resposta foi bem-sucedida e se h� artigos dispon�veis.

                if (articlesResponse.Status == Statuses.Ok && articlesResponse.Articles != null)
                {
                  

                    Console.WriteLine($"Total articles: {articlesResponse.TotalResults}");

                    

                    Articles.Clear();

                    // Adiciona cada artigo retornado � lista observ�vel.

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
