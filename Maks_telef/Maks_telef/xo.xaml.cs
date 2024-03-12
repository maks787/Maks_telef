using System;
using Xamarin.Forms;

namespace Maks_telef
{
    public partial class xo : ContentPage
    {
        private bool isFirstPlayerRed = true;
        private bool gameEnded = false;
        private Button[,] buttons;
        

        public xo()
        {

            Grid gameGrid = new Grid();

            buttons = new Button[3, 3];

            Button newGameButton = new Button
            {
                Text = "Uus mäng",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            newGameButton.Clicked += NewGameButton_Clicked;

            Button colorButton = new Button
            {
                Text = "Vali värv",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            colorButton.Clicked += ColorButton_Clicked;
            Button botButton = new Button
            {
                Text = "Roboot",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            botButton.Clicked += BotButton_Clicked;
            gameGrid.Children.Add(botButton, 0, 5);
            Grid.SetColumnSpan(botButton, 3);
            gameGrid.Children.Add(newGameButton, 0, 3);
            Grid.SetColumnSpan(newGameButton, 3);
            gameGrid.Children.Add(colorButton, 0, 4);
            Grid.SetColumnSpan(colorButton, 3);

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button
                    {
                        BackgroundColor = Color.White,
                        CommandParameter = new Tuple<int, int>(row, col),
                        HeightRequest = 60,
                        WidthRequest = 60
                    };

                    button.Clicked += OnButtonClicked;

                    buttons[row, col] = button;
                    gameGrid.Children.Add(button, col, row);
                }
            }

            Content = gameGrid;
        }

        private void NewGameButton_Clicked(object sender, EventArgs e)
        {
            gameEnded = false;
            isFirstPlayerRed = true;

            foreach (var btn in buttons)
            {
                btn.BackgroundColor = Color.White;
                btn.Text = "";
            }
        }

        private async void ColorButton_Clicked(object sender, EventArgs e)
        {
            var color = await DisplayActionSheet("Valige mängija värv", null, null, "Punane", "Sinine");
            isFirstPlayerRed = color == "Punane";
        }
        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].BackgroundColor != Color.White &&
                    buttons[i, 0].BackgroundColor == buttons[i, 1].BackgroundColor &&
                    buttons[i, 1].BackgroundColor == buttons[i, 2].BackgroundColor)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (buttons[0, i].BackgroundColor != Color.White &&
                    buttons[0, i].BackgroundColor == buttons[1, i].BackgroundColor &&
                    buttons[1, i].BackgroundColor == buttons[2, i].BackgroundColor)
                {
                    return true;
                }
            }

            if (buttons[0, 0].BackgroundColor != Color.White &&
                buttons[0, 0].BackgroundColor == buttons[1, 1].BackgroundColor &&
                buttons[1, 1].BackgroundColor == buttons[2, 2].BackgroundColor)
            {
                return true;
            }


            return false;
        }
        private void BotGame()
        {
            Random random = new Random();

            if (!gameEnded)
            {
                int row, col;
                do
                {
                    row = random.Next(0, 3);
                    col = random.Next(0, 3);
                } while (!string.IsNullOrEmpty(buttons[row, col].Text) || buttons[row, col].BackgroundColor != Color.White);

                if (string.IsNullOrEmpty(buttons[row, col].Text))
                {
                    buttons[row, col].BackgroundColor = isFirstPlayerRed ? Color.Red : Color.Blue;

                    if (CheckWin())
                    {
                        string winner = isFirstPlayerRed ? "Punane" : "Sinine";
                        DisplayAlert("Võitmine!", $"Võitnud mängija {winner}!", "OK");
                        gameEnded = true;
                    }
                    else
                    {
                        bool isDraw = true;
                        foreach (var btn in buttons)
                        {
                            if (string.IsNullOrEmpty(btn.Text))
                            {
                                isDraw = false;
                                break;
                            }
                        }
                        if (isDraw)
                        {
                            DisplayAlert("viik", "viik!", "OK");
                            gameEnded = true;
                        }
                    }

                    isFirstPlayerRed = !isFirstPlayerRed;
                }
            }
        
        

    }

    private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            if (!gameEnded && string.IsNullOrEmpty(button.Text))
            {
                button.BackgroundColor = isFirstPlayerRed ? Color.Red : Color.Blue;
                button.Text = isFirstPlayerRed ? "X" : "O";

                if (CheckWin())
                {
                    string winner = isFirstPlayerRed ? "Punane" : "Sinine";
                    DisplayAlert("Võitmine!", $"Võitnud mängija {winner}!", "OK");
                    gameEnded = true;
                }
                else
                {
                    bool isDraw = true;
                    foreach (var btn in buttons)
                    {
                        if (string.IsNullOrEmpty(btn.Text))
                        {
                            isDraw = false;
                            break;
                        }
                    }
                    if (isDraw)
                    {
                        DisplayAlert("viik", "viik!", "OK");
                        gameEnded = true;
                    }
                }

                isFirstPlayerRed = !isFirstPlayerRed;

                if (!gameEnded)
                {
                    
                }
            }
            else if (gameEnded)
            {
                DisplayAlert("Viga", "Mäng on juba lõppenud. Alusta uut mängu!", "OK");
            }
            else
            {
                DisplayAlert("Viga", "See lahter on juba hõivatud", "OK");
            }
        }

        private void BotButton_Clicked(object sender, EventArgs e)
        {
            BotGame();
        }

    }
}
