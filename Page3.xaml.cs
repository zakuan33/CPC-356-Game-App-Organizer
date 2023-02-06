using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



namespace app356.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

           
        }

        private async void GetWeatherButton_Clicked(object sender, EventArgs e)
        {
            // Get the location from the user input
            string zipcode = ZipCodeTextBox.Text;
            try
            {
                // Make a request to the weather API using the location
                string apiKey = "28bd3a1d43e9f9e5097884691f6f7d66";
                string countrycode = "my";
                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?zip={zipcode},{countrycode}&appid={apiKey}";
                HttpClient client = new HttpClient();
                string jsonData = await client.GetStringAsync(apiUrl);

                // Parse the JSON data and extract the weather information
                JObject weatherData = JObject.Parse(jsonData);
                float temperature = (float)weatherData["main"]["temp"];
                string weatherCondition = (string)weatherData["weather"][0]["main"];
               // Console.WriteLine(jsonData);

                // Display the weather information to the user
                TemperatureLabel.Text = $"Temperature: {temperature}°F";
                ConditionLabel.Text = $"Condition: {weatherCondition}";
            }
            catch (HttpRequestException ex)
            {
                // There was an error making the request to the API
                TemperatureLabel.Text = "Error getting weather data: { ex.Message } (Status code: { ex.StatusCode})";
            }
            catch (JsonException ex)
            {
                // There was an error parsing the JSON data
                TemperatureLabel.Text = "Error getting weather data: " + ex.Message;
            }

         
        }

    }
}