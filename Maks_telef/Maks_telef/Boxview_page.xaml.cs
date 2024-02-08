using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxView_Page : ContentPage
    {
        BoxView box;
        Random rnd = new Random();
        int clickCounter = 0; 

        Label clickLabel; 

        public BoxView_Page()
        {
            int r = 0, g = 0, b = 0;

            box = new BoxView
            {
                Color = Color.FromRgb(r, g, b),
                CornerRadius = 10,
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);

            clickLabel = new Label
            {
                Text = "Clicks: 0",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            StackLayout st = new StackLayout { Children = { box, clickLabel } };
            Content = st;
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            clickCounter++;

            clickLabel.Text = $"Klipseda: {clickCounter}";

            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}
