using Client;
using System.Net.Http.Json;

string url = "https://localhost:7019/Task";

Console.WriteLine("Введите количество тасков");
int tasks = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Выполнять их параллельно?\n1 - true\t2-false");
bool parallel = Console.ReadLine() == "1";

int total = 0; //счётчик суммы времени

var client = new HttpClient();
JsonContent content = JsonContent.Create(new RequestView { tasks = tasks, parallel = parallel });
using var response = await client.PostAsync(url, content);
List<ResponseView>? responseList = await response.Content.ReadFromJsonAsync<List<ResponseView>>();

if(responseList != null)
    foreach(var item in responseList)
    {
        total += item.time;
        Console.WriteLine($"{item.order} = {item.time}");
    }
Console.WriteLine($"total = {total}");
Console.ReadLine();