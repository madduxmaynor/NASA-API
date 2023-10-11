using System;
using System.Net.Http;
using System.Threading.Tasks;
using API;

class Program
{
    static async Task Main()
    {
        var apiKey = "6mc7zY58wRNXnSe0mwwXD5hGg2ddWQjgdJ3hbgGA"; 
        //var imagesViewer = new ImagesViewer(apiKey);
        var marsRoverViewer = new MarsRoverViewer();
        var astronomyViewer = new AstronomyViewer();
        var imageViewer = new ImageViewer(apiKey);
        GalagaGame galagaGame = new GalagaGame();

        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Play Galaga");
            Console.WriteLine("2. View Teh Mars Rover Photos");
            Console.WriteLine("3. View The Astronomy Picture of the Day");
            //Console.WriteLine("4. View The an Image");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        await galagaGame.RunGame();
                        //await imagesViewer.ViewImagesOfTheDay();
                        break;
                    case 2:
                        await marsRoverViewer.ViewMarsroverPhotos();
                        break;
                    case 3:
                        await astronomyViewer.ViewAstronomy();
                        break;
                    case 4:
                        await imageViewer.ViewImage(); 
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Burt Wrong.Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Burt Wrong.Try again.");
            }
        }
    }

    
}
class GalagaGame
{
    private Galaga galaga;

    public GalagaGame()
    {
        galaga = new Galaga();
    }

    public async Task RunGame()
    {
        Galaga.Run();
    }
}
class ImageViewer
{
    private readonly string apiKey;

    public ImageViewer(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task ViewImage()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetStringAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}");
            Console.WriteLine("View an Image:");
            Console.WriteLine(response); 
        }

        Console.WriteLine("Enter to return to the main menu.");
        Console.ReadLine();
    }

}