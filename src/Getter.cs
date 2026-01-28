namespace csharp_stuff;

using System.Net.Http;
class Getter
{

    private static void Main(string[] args)
    {
        string inputUrl = args[0];
        Console.WriteLine($"Sending Request to Input URL: {inputUrl}");
        SendRequest(inputUrl);
    }

    private static void SendRequest(string url)
    {
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        Task<HttpResponseMessage> task = client.SendAsync(request);
        task.Wait();
        HttpResponseMessage response = task.Result;
        HttpContent content = response.Content;
        Task<string> stream = content.ReadAsStringAsync();
        stream.Wait();
        Console.WriteLine(stream.Result);
    }
}
