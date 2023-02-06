using app356.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app356.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class Page2 : ContentPage
    {

        private ObservableCollection<Contacts> myList;

        
        public ObservableCollection<Contacts> MyList
        {
            get { return myList; }
            set { myList = value; }

        }

        private async void Button_Clickedn_Clicked(object sender, EventArgs e)
        {
             // Prompt the user for input
        string appName = await DisplayPromptAsync("Enter app name", "App name:");
        string appType = await DisplayPromptAsync("Enter app type", "App type:");
        string appYear = await DisplayPromptAsync("Enter app year", "App year:");
        string appVersionString = await DisplayPromptAsync("Enter app version (Double type data)", "App version:");

                // Parse the app version as a double
        double appVersion;
        if (!double.TryParse(appVersionString, out appVersion))
        {
            // If the parsing fails, show an error message and return
            await DisplayAlert("Error", "Invalid app version", "OK");
            return;
        }

        // Add the entered data to the MyList ObservableCollection
        MyList.Add(new Contacts() 
        { 
            AppName = appName, 
            AppType = appType,
            AppsYear = appYear,
            AppVersion = appVersion,
            Image = "ad.png" 
        });
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            // Get the selected items
            var selectedItems = MyList.Where(x => x.IsSelected).ToList();

            // Remove the selected items from the MyList ObservableCollection
            foreach (var item in selectedItems)
            {
                MyList.Remove(item);
            }
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            MyList.Remove((Contacts)mi.CommandParameter);
        }

        private void ContactsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Get the tapped item
            var item = e.Item as Contacts;

            // Toggle the IsSelected property
            item.IsSelected = !item.IsSelected;

            // Update the item in the list
            MyList[MyList.IndexOf(item)] = item;
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            // Get the selected item
            var selectedItem = MyList.FirstOrDefault(x => x.IsSelected);
            if (selectedItem == null)
            {
                // No item is selected, show an error message
                DisplayAlert("Error", "No item is selected", "OK");
                return;
            }
            // Prompt the user for input
            string appName = await DisplayPromptAsync("Enter app name", "App name:", initialValue: selectedItem.AppName);
            string appType = await DisplayPromptAsync("Enter app type", "App type:", initialValue: selectedItem.AppType);
            string appYear = await DisplayPromptAsync("Enter app year", "App year:", initialValue: selectedItem.AppsYear);
            string appVersionString = await DisplayPromptAsync("Enter app version (Double type data)", "App version:", initialValue: selectedItem.AppVersion.ToString());

            // Parse the app version as a double
            double appVersion;
            if (!double.TryParse(appVersionString, out appVersion))
            {
                // If the parsing fails, show an error message and return
                await DisplayAlert("Error", "Invalid app version", "OK");
                return;
            }

            // Update the selected item with the new data
            selectedItem.AppName = appName;
            selectedItem.AppType = appType;
            selectedItem.AppsYear = appYear;
            selectedItem.AppVersion = appVersion;

            // Update the item in the list
            MyList[MyList.IndexOf(selectedItem)] = selectedItem;

        }

        public Page2()
        {

            InitializeComponent();
            this.BindingContext = this;
            // Initialize the ContactsList object.

            
            MyList = new ObservableCollection<Contacts>();
            //add your list items here
            MyList.Add(new Contacts() { AppVersion = 1.1, AppsYear = "2000" ,  AppType = " education", AppName = "E-learn",  Image = "ad.png" });
            MyList.Add(new Contacts() { AppVersion = 1.2, AppsYear = "2001", AppType = " lifestyle", AppName = "grab", Image = "ad.png" });
            MyList.Add(new Contacts() { AppVersion = 1.3, AppsYear = "2002",  AppType = " social media", AppName = "FB", Image = "ad.png" });
            MyList.Add(new Contacts() { AppVersion = 1.4, AppsYear = "2003", AppType = " productivity", AppName = "class", Image = "ad.png" });
            MyList.Add(new Contacts() { AppVersion = 1.5, AppsYear = "2004", AppType = " entertainment", AppName = "YOUTUBE",  Image = "ad.png" });

            ContactsList.ItemsSource = MyList;



        }
        
        




    }


}