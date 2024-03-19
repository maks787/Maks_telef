using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    
    public partial class riigid : ContentPage
    {
        Label lbl;
        ListView listView;
        ObservableCollection<riik> rigid = new ObservableCollection<riik> {
            new riik("Eesti","Tallinn",5000000,"eesti.png"),
            new riik("Ukraine", "Kiev",10000000, "ukraine.png"),
            new riik("USA", "Washington", 20000000,"u.jpg"),
            new riik("Belarus", "Minsk", 800000,"iphone13.jpg") };
        riik selectedTelefon;
        Button Lisa, Kustuta;

        public riigid()
        {
            Title = "List page";
            listView = new ListView
            {
                ItemsSource = rigid,
                Footer = DateTime.Now.ToString("t"),
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell ic = new ImageCell { TextColor = Color.Black, DetailColor = Color.Green };
                    ic.SetBinding(ImageCell.TextProperty, "Nimetus");
                    Binding companyBinding = new Binding { Path = "pealinn", StringFormat = "pealinn riik on {0}" };
                    ic.SetBinding(ImageCell.DetailProperty, companyBinding);
                    ic.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return ic;
                })
            };
            lbl = new Label
            {
                Text = "riigi loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            listView.ItemTapped += ListView_ItemTapped;
            Lisa = new Button { Text = "Lisa Riik" };
            Lisa.Clicked += Lisa_Clicked;
            Kustuta = new Button { Text = "Kustuta riik" };
            Kustuta.Clicked += Kustuta_Clicked;
            this.Content = new StackLayout { Children = { lbl, listView, Lisa, Kustuta } };
        }

        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            rigid.Remove(selectedTelefon);
            lbl.Text = "Riigid loetelu";
        }


        private async void Lisa_Clicked(object sender, EventArgs e)
        {
            string nimetus = await DisplayPromptAsync("Nimetus", "Kirjuta nimetus");
            if (nimetus == null)
                return;
            string pealinn = await DisplayPromptAsync("pealinn", "Kirjuta pealinn");
            if (pealinn == null)
                return;
            string inimesed = await DisplayPromptAsync("Rahvastiku suurus", "Kirjuta Rahvastiku suurus", keyboard: Keyboard.Numeric);
            if (inimesed == null)
                return;
            riik rik = new riik(nimetus, pealinn, int.Parse(inimesed), "aue.jpg");
            if (rigid.Any(x => x.Nimetus == rik.Nimetus))
                return;
            rigid.Add(rik);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            selectedTelefon = e.Item as riik;
            lbl.Text = $"{selectedTelefon.Pealinn} | {selectedTelefon.Nimetus} - {selectedTelefon.inimesed} ";
        }
    }
}