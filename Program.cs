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

            var clid = "ak220315";

            var apikey = "TqOJqLrboDMwXfmIdvgQGygNHySFXLUvsuyIGV";

            //var request = new GetRequest($"https://reqres.in/api/users?page=1"); //образаемся к апиsss

            var request = new GetRequest($"https://taxi-routeinfo.taxi.yandex.net/taxi_info?clid={clid}&apikey={apikey}&rll=<lon,lat~lon,lat>&class=<class_str>&req=<req_str>"); //образаемся к апиsss

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
