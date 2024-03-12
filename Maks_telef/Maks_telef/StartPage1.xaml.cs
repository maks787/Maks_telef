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
    public partial class StartPage1 : ContentPage
    {       List<ContentPage> pages = new List<ContentPage>() { new EntryPage(),new TimePage(),new BoxView_Page(),new DateTimePage(), new StepperSlider_Page(), new RGBslider(), new lumimemm(),new FramePage(), new xo(), new PickerPage(), new smsPage(), new CarouselPage() };
            List<string> texts = new List<string>() { "Ava entry leht","Ava timer leht", "Ava Box leht", "Ava Date leht", "Ava Slider leht", "Ava rgb slider leht", "Ava lumemmem leht", "Ava Frame leht", "Ava Trips traps trull leht","ava veeb leht","sms leht","Ava carousel" };
            StackLayout st;
        public StartPage1()
        {
            st = new StackLayout
            {
                 Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.AliceBlue
            };
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.AntiqueWhite,
                    TextColor=Color.Black,
                    TabIndex= i
                };
                st.Children.Add(button);
                button.Clicked += Ava_leht;
                
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Ava_leht(object sender, EventArgs e)
        {
            Button btn= (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}