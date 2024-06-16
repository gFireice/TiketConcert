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

        public static List<Model.Orderer> Orders { get; set; } = new List<Model.Orderer>();

        public static string[] Place = { 
        "ул. Пушкина, дом Колотушкина 4А",
        "ул. Фарфоровая, дом 4Б",
        "ул. Сретенка, дом 9",
        "ул. Рядовая, дом 46",
        "пр-кт Богатый, дом 56Ю",
        "ул. Бузовой, дом Арбузовой 34"
        };
        public static string[] Organization = {
        "Рус",
        "Фэйвл",
        "Гэллмэн",
        "Дросида",
        "Элиз",
        "Оол",
        "Ахметжамиль",
        "Чечек",
        "Новомира"};
        public static string[] MusicStyle = {
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
