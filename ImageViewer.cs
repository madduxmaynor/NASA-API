using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using static System.Net.Mime.MediaTypeNames;

namespace API // this took so long and i could not get it to work i tried almost everything
              // including asking chatgpt but it didn't help
{ 
    /*
    class ImagesViewer
    {
        private readonly string apiKey;

        public ImagesViewer(string apiKey)
        {
            this.apiKey = apiKey;
        }
        
        public async Task ViewImagesOfTheDay()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}");
                Console.WriteLine("Images of the Day:");
    /
                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response);
                var imageUrl = json.url;
                var imageTitle = json.title;
                var imageExplanation = json.explanation;

                Console.WriteLine($"Title: {imageTitle}");
                Console.WriteLine($"Explanation: {imageExplanation}");

                Console.WriteLine($"Image URL: {imageUrl}"); 

                if (Uri.TryCreate(imageUrl, UriKind.Absolute, out Uri validUri))
                {
                    using (var imageClient = new HttpClient())
                    {
                        var imageBytes = await imageClient.GetByteArrayAsync(validUri);
                        DisplayImage(imageBytes);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid image URL: " + imageUrl);
                }

                Console.WriteLine("Enter to return to the main menu.");
                Console.ReadLine();
            }
        }
        
    private void DisplayImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
                {
                    
                    string tempImagePath = Path.Combine(Path.GetTempPath(), "nasa_image.jpg");
                    image.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    Process.Start(tempImagePath);
                }
            }
        }
    }
    */
}
