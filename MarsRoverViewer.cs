using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class MarsRoverViewer
    {
        public async Task ViewMarsroverPhotos()
        {
            var apiKey = "6mc7zY58wRNXnSe0mwwXD5hGg2ddWQjgdJ3hbgGA";
            Console.Write("Enter mars rover name. example: Type curiosity ");
            var roverName = Console.ReadLine().Trim();

            using (var httpClient = new HttpClient())
            {
                var resp= await httpClient.GetStringAsync($"https://api.nasa.gov/mars-photos/api/v1/rovers/{roverName}/latest_photos?api_key={apiKey}");
                Console.WriteLine($"Mars Rover Photos ({roverName}):");
                Console.WriteLine(resp);
            }

            Console.WriteLine("Enter to return to the main menu.");
            Console.ReadLine();
        }
    }
}
