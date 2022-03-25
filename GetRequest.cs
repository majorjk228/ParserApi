using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ParserApi
{
    public class GetRequest
    {
        HttpWebRequest _request; // создаем объект
        string _adress; //заводим переменная

        public string Response { get; set; }

        public GetRequest(string adress) //конструктор который принимает адресс
        {
            _adress = adress;
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress); //создаем сам запрос
            _request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse(); //ответ сервера
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd(); //записываем ответ
            }
            catch (Exception)
            {
            }
        }
    }
}
