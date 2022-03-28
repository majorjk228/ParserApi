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

            var otkuda = "37.513044,55.842994"; // тарифы поездки 37.589569560,55.733780~37,56

            var kuda = "37.55434,55.547973"; // пожелания клиента для поиска машиныk



            //var request = new GetRequest($"https://reqres.in/api/users?page=1"); //образаемся к апиsss

            //var request = new GetRequest($"https://taxi-routeinfo.taxi.yandex.net/taxi_info?clid=<{clid}>&apikey=<{apikey}>&rll=<37.513044,55.842994~37.55434,55.547973>&class=<class_str>&req=<req_str>"); //образаемся к апиsss

            var request = new GetRequest($"https://taxi-routeinfo.taxi.yandex.net/taxi_info?rll={otkuda}~{kuda}&clid={clid}&apikey={apikey}");

            request.Run();

            var response = request.Response; // ответ от портала

            Console.WriteLine(response);


            var json = JObject.Parse(response);//выводим из джсон

            var data = json["options"];


            foreach (var elements in data)
            {
                /* var name = elements["first_name"];
                 var email = elements["email"];
                 var lastname = elements["last_name"];
                 Console.WriteLine($"Имя:{name} \n Фамилия:{lastname} \n Мыло:{email}"); //вывожу данные из джсона на консоль(изи парс):)*/
                var name = elements["class_name"];
                var price = elements["price_text"];
                Console.WriteLine($"Имя:{name} \n Цена:{price} \n"); //вывожу данные из джсона на консоль(изи парс):)*/
            }
            
            var name1 = data[0]["price"]; //вывожу вне цикла значения ищ массива оптионс
            var time = json["time"];
            var val = json["currency"];
            Console.WriteLine("Время: " + time);
            Console.WriteLine("Валюта: " + val);
            Console.WriteLine("Цена: " + name1);
            Console.ReadKey();
        }
    }
}
