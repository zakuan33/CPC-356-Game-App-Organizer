using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app356.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    



    public partial class Page1 : ContentPage
    {

        // Assume that the development date of the app is December 10, 2022
        private static readonly DateTime CreationDate = new DateTime(2022, 12, 10);

        public Page1()
        {
            InitializeComponent();
            // Calculate the number of days since the profile was created
            TimeSpan timeSinceCreation = DateTime.Now - CreationDate;
            int daysSinceCreation = timeSinceCreation.Days;

            // Create a label to display the number of days since the profile was created
            Label daysLabel = new Label
            {
                Text = $"Your profile has been created for {daysSinceCreation} days.",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
             // Create labels to display your name and year of study
            Label nameLabel = new Label
            {
                Text = "Name: Zakuan Nafis bin Mohd Yahaya ",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };
            Label yearLabel = new Label
            {
                Text = "Year of study: 4th year sem 1",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            // Create a list of  favorite apps
            List<string> favoriteApps = new List<string>
            {
                "TradingView",
                "Facebook",
                "WhatsApp"
            };

            // Create a list of  favorite games
            List<string> favoriteGames = new List<string>
            {
                "PUBG",
                "Mobile Legends"
            };

            // Create a ListView to display the favorite apps
            ListView appsListView = new ListView
            {
                // Set the header and footer of the ListView
                Header = new Label { Text = "Favorite Apps" },
                ItemsSource = favoriteApps,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Create a ListView to display the favorite games
            ListView gamesListView = new ListView
            {
                // Set the header and footer of the ListView
                Header = new Label { Text = "Favorite Games" },
                ItemsSource = favoriteGames,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Add the labels and ListViews to a stack layout
            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    daysLabel,
                    nameLabel,
                    yearLabel,
                    appsListView,
                    gamesListView
                }
            };

            // Add the stack layout to the page
          this.Content = stackLayout;
        }
        

    }
}