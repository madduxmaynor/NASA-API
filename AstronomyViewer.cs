using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class AstronomyViewer
    {

        public async Task ViewAstronomy()
        {
            var apiKey = "6mc7zY58wRNXnSe0mwwXD5hGg2ddWQjgdJ3hbgGA";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($" https://api.nasa.gov/planetary/apod?api_key={apiKey}");
                Console.WriteLine("Astronomy Picture of the Day:");
                Console.WriteLine(response); 
            }

            Console.WriteLine("Enter to return to the main menu");
            Console.ReadLine();
        }
    }
}
