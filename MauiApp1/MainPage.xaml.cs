namespace MauiApp1
{

    public partial class MainPage : ContentPage
    {
      
        int count = 0;

      
        public MainPage()
        {
            InitializeComponent();
        }

        // Este método é chamado quando o botão "Ver Notícias" é clicado.
        
        private async void OnNewsButtonClicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new NewPage1());
        }
    }
}
