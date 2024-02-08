using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lumimemm : ContentPage
    {
        BoxView head = new BoxView();
        BoxView body = new BoxView();
        BoxView hat = new BoxView();

        public lumimemm()
        {

            head = new BoxView
            {
                Color = Color.Gray,
                CornerRadius = 150,
                WidthRequest = 150,
                HeightRequest = 150
            };

            body = new BoxView
            {
                Color = Color.Gray,
                CornerRadius = 230,
                WidthRequest = 230,
                HeightRequest = 230
            };

            hat = new BoxView
            {
                Color = Color.Black,
                WidthRequest = 20,
                HeightRequest = 150
            };

            StackLayout stackLayout = new StackLayout
            {
                Children = { hat, head, body }, 
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = stackLayout;
        }
    }
}
