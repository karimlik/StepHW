var client = new HttpClient();
HttpRequestMessage request;
var search = "";
Console.WriteLine("Choose API to use:\n1. Free NBA API\n2. Urban Dictionary API: ");
var choice = Console.ReadLine();
if (choice == "1")
{
    Console.WriteLine("Input name of NBA player for search: ");
    search = Console.ReadLine();
    request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://free-nba.p.rapidapi.com/players?page=0&per_page=25&search={search}"), //Search by Name
        Headers =
    {
        { "X-RapidAPI-Key", "39db6b236emsh94fb894febdb8a7p16ef56jsn6d4099a231bd" },
        { "X-RapidAPI-Host", "free-nba.p.rapidapi.com" }, //Free NBA API
    },
    };

    using (var response = await client.SendAsync(request))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();

        Console.WriteLine(body);
    }
}
else if (choice == "2")
{
    Console.WriteLine("Input term to get definition of: ");
    search = Console.ReadLine();
    request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"https://mashape-community-urban-dictionary.p.rapidapi.com/define?term={search}"),
        Headers =
    {
        { "X-RapidAPI-Key", "39db6b236emsh94fb894febdb8a7p16ef56jsn6d4099a231bd" },
        { "X-RapidAPI-Host", "mashape-community-urban-dictionary.p.rapidapi.com" },
    },
    };
    using (var response = await client.SendAsync(request))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Console.WriteLine(body);
    }
}

else
{
    Console.WriteLine("Which part of 1 and 2 is not understandable? Men getdim");
    return;
}