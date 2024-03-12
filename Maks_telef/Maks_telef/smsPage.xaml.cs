using Plugin.Messaging;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Maks_telef
{
    public partial class smsPage : ContentPage
    {
        EntryCell tel_nr, email, text;
        Picker contactPicker;
        Dictionary<string, string> contacts;

        public smsPage()
        {   
            tel_nr = new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            };
            contactPicker = new Picker
            {
                Title = "Vali kontakt",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            email = new EntryCell
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email
            };

            text = new EntryCell
            {
                Label = "Tekst",
                Placeholder = "Sisesta tekst",
                Keyboard = Keyboard.Default
            };



            contacts = new Dictionary<string, string>();

            LoadContacts();
            Button sms_btn = new Button { Text = "Saada SMS" };
            sms_btn.Clicked += Sms_btn_Clicked;

            Button call_btn = new Button { Text = "Helista" };
            call_btn.Clicked += Call_btn_Clicked;

            Button mail_btn = new Button { Text = "Kirjuta kiri" };
            mail_btn.Clicked += Mail_btn_Clicked;

            Button saveContact_btn = new Button { Text = "Salvesta" };
            saveContact_btn.Clicked += SaveContact_btn_Clicked;

            StackLayout actionStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { call_btn, sms_btn, mail_btn, saveContact_btn }
            };
            TableView tableView = new TableView

            {

                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed")
                    {
                        text
                    },
                    new TableSection("Kontaktiandmed")
                    {
                        tel_nr,
                        new ViewCell { View = contactPicker },
                        email
                    }
                }
            };




            Content = new StackLayout { Children = { tableView,   actionStackLayout } };

        }

        private void Sms_btn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tel_nr.Text) || string.IsNullOrWhiteSpace(text.Text))
            {
                DisplayAlert("Error", "Telefon ja tekst peavad olema täidetud!", "OK");
                return;
            }

            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel_nr.Text, text.Text);
            }
            else
            {
                DisplayAlert("Error", "SMS saatmine ei ole võimalik sellel seadmel!", "OK");
            }
        }

        private void Call_btn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tel_nr.Text))
            {
                DisplayAlert("Error", "Telefon peab olema täidetud!", "OK");
                return;
            }

            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel_nr.Text);
            }
            else
            {
                DisplayAlert("Error", "Telefoniga helistamine ei ole võimalik sellel seadmel!", "OK");
            }
        }

        private void Mail_btn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(text.Text))
            {
                DisplayAlert("Error", "Email ja tekst peavad olema täidetud!", "OK");
                return;
            }

            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(email.Text, "Tervitus!", text.Text);
            }
            else
            {
                DisplayAlert("Error", "Emaili saatmine ei ole võimalik sellel seadmel!", "OK");
            }
        }

        private void SaveContact_btn_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tel_nr.Text))
            {
                string name = tel_nr.Text;
                string value = tel_nr.Text;
                contacts[name] = value;
                contactPicker.Items.Add(name);
            }
        }

        private void LoadContacts()
        {
            foreach (var contact in contacts)
            {
                contactPicker.Items.Add(contact.Key);
            }
        }
    }
}
