using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGBslider : ContentPage
    {
        Slider redSlider = new Slider { Minimum = 0, Maximum = 255 };
        Slider greenSlider = new Slider { Minimum = 0, Maximum = 255 };
        Slider blueSlider = new Slider { Minimum = 0, Maximum = 255 };
        Label redLabel = new Label();
        Label greenLabel = new Label();
        Label blueLabel = new Label();
        BoxView boxView = new BoxView();
        Button randomColorButton = new Button { Text = "Random Color" };
        Stepper sizeStepper = new Stepper { Minimum = 90, Maximum = 250, Increment = 10, Value = 100 };

        public RGBslider()
        {

            redSlider.ValueChanged += OnSliderValueChanged;
            greenSlider.ValueChanged += OnSliderValueChanged;
            blueSlider.ValueChanged += OnSliderValueChanged;
            sizeStepper.ValueChanged += OnSizeStepperValueChanged;

            redLabel.Text = "Red=00";
            greenLabel.Text = "Green=00";
            blueLabel.Text = "Blue=00";

            randomColorButton.Clicked += OnRandomColorButtonClicked;


            AbsoluteLayout.SetLayoutBounds(boxView, new Rectangle(0.5, 0.1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(boxView, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(redSlider, new Rectangle(0.5, 0.4, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(redSlider, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(redLabel, new Rectangle(0.5, 0.5, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(redLabel, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(greenSlider, new Rectangle(0.5, 0.6, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(greenSlider, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(greenLabel, new Rectangle(0.5, 0.7, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(greenLabel, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(blueSlider, new Rectangle(0.5, 0.8, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(blueSlider, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(blueLabel, new Rectangle(0.5, 0.9, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(blueLabel, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(randomColorButton, new Rectangle(0.5, 1, 0.8, 0.1));
            AbsoluteLayout.SetLayoutFlags(randomColorButton, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(sizeStepper, new Rectangle(0.5, 0.9, 0.5, 0.1));
            AbsoluteLayout.SetLayoutFlags(sizeStepper, AbsoluteLayoutFlags.All);

            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            absoluteLayout.Children.Add(boxView);
            absoluteLayout.Children.Add(redSlider);
            absoluteLayout.Children.Add(redLabel);
            absoluteLayout.Children.Add(greenSlider);
            absoluteLayout.Children.Add(greenLabel);
            absoluteLayout.Children.Add(blueSlider);
            absoluteLayout.Children.Add(blueLabel);
            absoluteLayout.Children.Add(randomColorButton);
            absoluteLayout.Children.Add(sizeStepper);

            Content = absoluteLayout;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == redSlider)
            {
                redLabel.Text = string.Format("Red={0:X2}", Convert.ToInt32(e.NewValue));
            }
            else if (sender == greenSlider)
            {
                greenLabel.Text = string.Format("Green={0:X2}", Convert.ToInt32(e.NewValue));
            }
            else if (sender == blueSlider)
            {
                blueLabel.Text = string.Format("Blue={0:X2}", Convert.ToInt32(e.NewValue));
            }

            boxView.Color = Color.FromRgb(Convert.ToInt32(redSlider.Value),
                                          Convert.ToInt32(greenSlider.Value),
                                          Convert.ToInt32(blueSlider.Value));
        }

        void OnRandomColorButtonClicked(object sender, EventArgs e)
        {
            Random random = new Random();
            redSlider.Value = random.Next(0, 256);
            greenSlider.Value = random.Next(0, 256);
            blueSlider.Value = random.Next(0, 256);
        }

        void OnSizeStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newSize = sizeStepper.Value;
            boxView.HeightRequest = boxView.WidthRequest = newSize;
        }
    }
}
