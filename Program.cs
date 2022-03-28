using Newtonsoft.Json.Linq;
using ParserApi;
using System;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {
            //var key = "2"; можно использовать как "https://reqres.in/api/users?page={key}" класть значение из переменной

            //var users = "users"; 

            var request = new GetRequest($"https://reqres.in/api/users?page=1"); //образаемся к апиsss

            request.Run();

            var response = request.Response; // ответ от портала

            var json = JObject.Parse(response);//выводим из джсон

            var data = json["data"];

            foreach (var elements in data)
            {
                var name = elements["first_name"];
                var email = elements["email"];
                var lastname = elements["last_name"];

                Console.WriteLine($"Имя:{name} \n Фамилия:{lastname} \n Мыло:{email}"); //вывожу данные из джсона на консоль(изи парс):)
            }
        }
    }
}
