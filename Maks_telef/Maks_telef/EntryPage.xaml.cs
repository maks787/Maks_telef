using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Label lbl;
        Editor editor;

        public EntryPage()
        {
            Button Tagasi_btn = new Button
            {
                Text = "Tagasi start lehele",
                BackgroundColor = Color.Blue,
                TextColor = Color.Fuchsia,
            };

            lbl = new Label 
            {
                Text = "Mingi Tekst",
                BackgroundColor = Color.FromRgb(200, 32, 0),
                TextColor = Color.Fuchsia,
            };

            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst..",
                HorizontalOptions = LayoutOptions.Center,
            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255),
                Children = { lbl, Tagasi_btn },
                VerticalOptions = LayoutOptions.End
            };

            Content = st;
            Tagasi_btn.Clicked += Tagasi_btn_Clicked;
            editor.TextChanged += Editor_TextChanged;
        }

        private async void Editor_TextChanged(object sender, EventArgs e)
        {
            lbl.Text = editor.Text;
        }

        private async void Tagasi_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
