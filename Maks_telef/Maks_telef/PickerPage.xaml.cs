using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        string[] lehed = new string[4] { "https://tahvel.edu.ee/", "https://moodle.edu.ee/", "https://www.tthk.ee/", "https://www.instagram.com/" };
        string[] nimetused = new string[4] { "Tahvel", "moodle", "tthk", "instagram" };

        Entry addressEntry;
        StackLayout historyLayout;
        List<string> history = new List<string>();

        public PickerPage()
        {
            picker = new Picker
            {
                Title = "Veebilehed"
            };
            foreach (string leht in nimetused)
            {
                picker.Items.Add(leht);
            }

            addressEntry = new Entry
            {
                Placeholder = "Sisse URL",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            addressEntry.Completed += AddressEntry_Completed;

            var btnHome = new Button
            {
                Text = "Kodu",
                HorizontalOptions = LayoutOptions.Start
            };
            btnHome.Clicked += BtnHome_Clicked;

            var btnBack = new Button
            {
                Text = "<-",
                HorizontalOptions = LayoutOptions.Center
            };
            btnBack.Clicked += BtnBack_Clicked;

            var btnForward = new Button
            {
                Text = "->",
                HorizontalOptions = LayoutOptions.End
            };
            btnForward.Clicked += BtnForward_Clicked;

            var btnHistory = new Button
            {
                Text = "Ajalugu",
                HorizontalOptions = LayoutOptions.CenterAndExpand

            };
            btnHistory.Clicked += BtnHistory_Clicked;

            historyLayout = new StackLayout
            {
                IsVisible = false
            };
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.w3schools.com/" },
                HeightRequest = 500,
                WidthRequest = 100,
            };
            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnHome, btnBack, btnForward, btnHistory }
            };

            SwipeGestureRecognizer swipe_right = new SwipeGestureRecognizer();
            swipe_right.Swiped += Swipe_Swiped;
            picker.SelectedIndexChanged += Valime_leht_avamiseks;
            webView.Navigated += WebView_Navigated;

            st = new StackLayout
            {
                Children = { picker, addressEntry, historyLayout, buttonLayout, webView }
            };
            st.GestureRecognizers.Add(swipe_right);
            Content = st;
        }

        private void BtnHome_Clicked(object sender, EventArgs e)
        {
            AddToHistory(webView.Source.ToString());
            webView.Source = new UrlWebViewSource { Url = "https://www.w3schools.com/" };
        }

        private void BtnBack_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
                AddToHistory(webView.Source.ToString());
            }
        }

        private void BtnForward_Clicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
                AddToHistory(webView.Source.ToString());
            }
        }

        private void BtnHistory_Clicked(object sender, EventArgs e)
        {
            historyLayout.IsVisible = !historyLayout.IsVisible;
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Right:
                    if (webView.CanGoBack)
                    {
                        webView.GoBack();
                        AddToHistory(webView.Source.ToString());
                    }
                    break;
                case SwipeDirection.Left:
                    if (webView.CanGoForward)
                    {
                        webView.GoForward();
                        AddToHistory(webView.Source.ToString());
                    }
                    break;
                case SwipeDirection.Up:
                    webView.Source = new UrlWebViewSource { Url = lehed[0] };
                    AddToHistory(webView.Source.ToString());
                    break;
                case SwipeDirection.Down:
                    webView.Source = new UrlWebViewSource { Url = lehed[lehed.Length - 1] };
                    AddToHistory(webView.Source.ToString());
                    break;
                default:
                    break;
            }
        }

        private void Valime_leht_avamiseks(object sender, EventArgs e)
        {
            if (picker.SelectedIndex < nimetused.Length)
            {
                webView.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
                AddToHistory(webView.Source.ToString());
            }
            else
            {
                int customPageIndex = picker.SelectedIndex - nimetused.Length;
            }
        }

        private void AddressEntry_Completed(object sender, EventArgs e)
        {
            string url = addressEntry.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }

                if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    webView.Source = new UrlWebViewSource { Url = url };
                    AddToHistory(url);
                }
                else
                {
                    DisplayAlert("Viga", "Vale URL", "OK");
                }
            }
        }

        private void AddToHistory(string url)
        {
            if (Array.Exists(lehed, element => element == url))
            {
                history.Insert(0, url);
                if (history.Count > 5)
                    history.RemoveAt(5);

                UpdateHistory();
            }
        }

        private void UpdateHistory()
        {
            historyLayout.Children.Clear();
            foreach (var url in history)
            {
                var historyLabel = new Label
                {
                    Text = url,
                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                    TextColor = Color.Blue,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    VerticalOptions = LayoutOptions.Center
                };

                historyLabel.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        webView.Source = new UrlWebViewSource { Url = url };
                    })
                });

                historyLayout.Children.Add(historyLabel);
            }
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            string url = e.Url;
            AddToHistory(url);
        }
    }
}
