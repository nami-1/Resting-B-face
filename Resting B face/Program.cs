using System.Text.Json;
using RestSharp;
using System.IO;

RestClient client = new("https://digi-api.com/api/v1/digimon");

Console.WriteLine("Which Digimon?");
string digiName = Console.ReadLine();

RestRequest request = new ($"{digiName}");

RestResponse response = client.GetAsync(request).Result;

if (response.StatusCode == System.Net.HttpStatusCode.OK) {
    Digimon d = JsonSerializer.Deserialize<Digimon>(response.Content);
    Console.WriteLine(d.Id);
    File.WriteAllText("digimon.json", response.Content);
}  

else {
    Console.WriteLine("What do you mean?");
}

Console.ReadLine();