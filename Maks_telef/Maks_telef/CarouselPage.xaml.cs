//using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//namespace Maks_telef
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class MainPage : CarouselPage
//    {
//        public MainPage()
//        {
//            var redStackLayout = new StackLayout
//            {
//                BackgroundColor = Color.Red,
//                Children =
//                {
//                    new Label
//                    {
//                        Text = "Red Page",
//                        HorizontalOptions = LayoutOptions.Center,
//                        VerticalOptions = LayoutOptions.CenterAndExpand
//                    }
//                }
//            };

//            var greenStackLayout = new StackLayout
//            {
//                BackgroundColor = Color.Green,
//                Children =
//                {
//                    new Label
//                    {
//                        Text = "Green Page",
//                        HorizontalOptions = LayoutOptions.Center,
//                        VerticalOptions = LayoutOptions.CenterAndExpand
//                    }
//                }
//            };

//            var blueStackLayout = new StackLayout
//            {
//                BackgroundColor = Color.Blue,
//                Children =
//                {
//                    new Label
//                    {
//                        Text = "Blue Page",
//                        HorizontalOptions = LayoutOptions.Center,
//                        VerticalOptions = LayoutOptions.CenterAndExpand
//                    }
//                }
//            };

//            this.Children.Add(new ContentPage { Content = redStackLayout });
//            this.Children.Add(new ContentPage { Content = greenStackLayout });
//            this.Children.Add(new ContentPage { Content = blueStackLayout });
//        }
//    }
//}
