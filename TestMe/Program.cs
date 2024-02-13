using HousingModel;
using System.Net.Http.Json;
public partial class Program
{
    public static async Task Main(string[] args)
    {
        Console.ReadKey();
        HttpClient client = new HttpClient();
        var resp = await client.GetAsync("https://localhost:7262/api/AppUser/Test");
        string sresp = await resp.Content.ReadAsStringAsync();
        Console.WriteLine(sresp);

        //Login should fail
        HttpClient client2 = new HttpClient();
        var data = new AppLogin() { Email = "ahmad", Password = "password" };
        var content = JsonContent.Create(data);
        var resp2 = await client2.PostAsync("https://localhost:7262/api/AppUser/Login", content);
        string sresp2 = await resp2.Content.ReadAsStringAsync();
        client.Dispose();
        Console.WriteLine(sresp2);

        //Register dummy user
        HttpClient client3 = new HttpClient();
        var data3 = new AppUser() { Email = "dummy@gmail.com", Password = "password", FirstName = "Dummy", LastName = "Dummy", IsBuyer = false, IsSeller = false, IsAdmin = false };
        var content3 = JsonContent.Create(data3);
        var resp3 = await client3.PostAsync("https://localhost:7262/api/AppUser/Register", content3);
        string s3 = await resp3.Content.ReadAsStringAsync();
        Console.WriteLine(s3);

        //Login should go OK
        HttpClient client4 = new HttpClient();
        var data4 = new AppLogin() { Email = "dummy@gmail.com", Password = "password" };
        var content4 = JsonContent.Create(data4);
        var resp4 = await client4.PostAsync("https://localhost:7262/api/AppUser/Login", content4);
        string sresp4 = await resp4.Content.ReadAsStringAsync();
        client.Dispose();
        Console.WriteLine(sresp4);

        HttpClient client5 = new HttpClient();
        MultipartFormDataContent c = new MultipartFormDataContent
        {
            { new StringContent("email"), "email" },
            { new StringContent("password"), "oldPassword" },
            { new StringContent("password1"), "newPassword" }
        };
        var resp5 = await client5.PostAsync("https://localhost:7262/api/AppUser/ChangePassword", c);
        string sresp5 = await resp5.Content.ReadAsStringAsync();
        client.Dispose();
        Console.WriteLine(sresp5);

        Console.ReadKey();
    }
}
