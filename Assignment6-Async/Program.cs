using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    private static async Task FetchAndWriteContentAsync(string url)
    {
        using HttpClient client = new HttpClient();
        try
        {
            // Fetch content from the URL asynchronously
            string content = await client.GetStringAsync(url);

            // Write the content to a file asynchronously
            await File.WriteAllTextAsync("A.txt", content);

            Console.WriteLine("Content successfully written to A.txt");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"File error: {e.Message}");
        }
    }

    public static async Task Main(string[] args)
    {

        string url= "https://www.w3.org/TR/2003/REC-PNG-20031110/iso_8859-1.txt";
        await FetchAndWriteContentAsync(url);
    }
}
