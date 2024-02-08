using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class startpage : ContentPage
    {
        
        public startpage()
        {
            Button Timer_btn = new Button
            {
                Text = "START timer",
                BackgroundColor = Color.Aqua,
                TextColor = Color.Fuchsia,

            };
            Button Entry_btn = new Button
            {
               Text="Tere tulemast",
               BackgroundColor= Color.Blue,
               TextColor= Color.Fuchsia,

            };
            Button Box_btn = new Button
            {
                Text = "Ava box",
                BackgroundColor = Color.Black,
                TextColor = Color.Fuchsia,

            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.FromRgb(32, 32, 255),
                
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            
            st.Children.Add(Timer_btn);
            st.Children.Add(Entry_btn);
            st.Children.Add(Box_btn);
            Content = st;
            Entry_btn.Clicked += Entry_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;

        }

        private async void Timer_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }

        private async void Entry_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxView_Page());
        }


    }
}