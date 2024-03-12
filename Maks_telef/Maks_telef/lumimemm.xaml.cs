using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class lumimemm : ContentPage
    {
        BoxView boxr1, boxr2, boxdef;
        Button hideButton, showButton, changeColorButton;
        Random rnd;
        Slider sl;

        public lumimemm()
        {
            rnd = new Random();
            boxdef = new BoxView
            {
                CornerRadius = 1,
                WidthRequest = 70,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = RandomColor()
            };

            boxr1 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = RandomColor()
            };

            boxr2 = new BoxView
            {
                CornerRadius = 400,
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.White
            };

            hideButton = new Button { Text = "Peita", WidthRequest = 20, HeightRequest = 20 };
            hideButton.Clicked += HideButton_Clicked;

            showButton = new Button { Text = "Näita", WidthRequest = 20, HeightRequest = 20 };
            showButton.Clicked += ShowButton_Clicked;

            changeColorButton = new Button { Text = "Muuda värv", WidthRequest = 100, HeightRequest = 50 };
            changeColorButton.Clicked += ChangeColorButton_Clicked;
            sl = new Slider
            {
                Minimum = 0.5,
                Maximum = 2,
                Value = 1 
            };
            sl.ValueChanged += SizeSlider_ValueChanged;

            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { boxr1, boxr2, boxdef, hideButton, showButton, changeColorButton,sl }
            };

            AbsoluteLayout.SetLayoutBounds(boxdef, new Rectangle(0.4, 0.13, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxdef, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(boxr1, new Rectangle(0.4, 0.29, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxr1, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(boxr2, new Rectangle(0.4, 0.59, 300, 200));
            AbsoluteLayout.SetLayoutFlags(boxr2, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(hideButton, new Rectangle(0.1, 0.9, 100, 100));
            AbsoluteLayout.SetLayoutFlags(hideButton, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(showButton, new Rectangle(0.5, 0.9, 100, 100));
            AbsoluteLayout.SetLayoutFlags(showButton, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(changeColorButton, new Rectangle(0.9, 0.9, 100, 100));
            AbsoluteLayout.SetLayoutFlags(changeColorButton, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(sl, new Rectangle(0.5, 0.8, 300, 100));
            AbsoluteLayout.SetLayoutFlags(sl, AbsoluteLayoutFlags.PositionProportional);


            Content = abs;
            this.BackgroundColor = Color.Blue;
        }

        private async void HideButton_Clicked(object sender, EventArgs e)
        {
            await FadeOut();
        }

        private async Task FadeOut()
        {
            await Task.WhenAll(
                boxr1.FadeTo(0, 1000),
                boxr2.FadeTo(0, 1000),
                boxdef.FadeTo(0, 1000)
            );
        }
        private void SizeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;
            boxr1.Scale = value;
            boxr2.Scale = value;
            boxdef.Scale = value;
        }
        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            boxr1.IsVisible = true;
            boxr2.IsVisible = true;
            boxdef.IsVisible = true;
            boxr1.Opacity = 1;
            boxr2.Opacity = 1;
            boxdef.Opacity = 1;
        }

        private void ChangeColorButton_Clicked(object sender, EventArgs e)
        {
            boxr1.BackgroundColor = RandomColor();
            boxr2.BackgroundColor = RandomColor();
            boxdef.BackgroundColor = RandomColor();
        }

        private Color RandomColor()
        {
            byte[] rgb = new byte[3];
            rnd.NextBytes(rgb);
            return Color.FromRgb(rgb[0], rgb[1], rgb[2]);
        }
    }
}
