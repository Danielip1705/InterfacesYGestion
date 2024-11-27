namespace Crud
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Button(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CreatePage");
        }
    }
}
