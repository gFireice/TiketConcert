using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketConcert.Api;

namespace TiketConcert.Class
{
    public class AppData
    {
        public static Api.ApiControler Context { get; set; } = new Api.ApiControler();
        public static void updateContext()
        {
            Context = new Api.ApiControler();
        }

        public static List<Model.Concert> basket { get; set; } = new List<Model.Concert>();

        public static List<Model.Concert> concerts { get; set; } = new List<Model.Concert>();

        

        public static List<String> Place = new List<String> { 
        "Пусто",
        "ул. Пушкина, дом Колотушкина 4А",
        "ул. Фарфоровая, дом 4Б",
        "ул. Сретенка, дом 9",
        "ул. Рядовая, дом 46",
        "пр-кт Богатый, дом 56Ю",
        "ул. Бузовой, дом Арбузовой 34"
        };
        public static List<String> PlaceA = new List<String>
        {
            "Пусто",
            "Lounge-bar \"У Фархата\"",
            "Концертный зал \"Фарфоровое зеркало\"",
            "Бар \"Алиби\"",
            "Концертный зал \"Почемучка\"",
            "Крокус Сити Холл",
            "Бар \"Ольга\""
        };
        public static List<String> Organization = new List<string> {
        "Пусто",
        "Рус",
        "Фэйвл",
        "Гэллмэн",
        "Дросида",
        "Элиз",
        "Оол",
        "Ахметжамиль",
        "Чечек",
        "Новомира"};
        public static List<String> MusicStyle = new List<String>{
        "Пусто",
        "Рок",
        "Металл",
        "Хип-хоп",
        "Симфония",
        "Квартет",
        "Джаз",
        "Блюз",
        "Панк",
        "Танцевальная",
        "Этническая",
        };
    }
}
