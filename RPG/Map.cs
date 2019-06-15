using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    /// <summary>
    /// Объект города
    /// </summary>
    class TownObject
    {
        public TownObject(string Name)
        {
            this.Name = Name;
        }




        public string Name { get; set; }
    }

    /// <summary>
    /// Таверна
    /// </summary>
    class Tavern : TownObject
    {
        /// <summary>
        /// Создание таверны
        /// </summary>
        /// <param name="Name">Название таверны</param>
        public Tavern(string Name)
            : base(Name)
        {

        }


        /// <summary>
        /// Магазин таверны
        /// </summary>
        List<Item> TavernShop;

        /// <summary>
        /// Квесты таверны
        /// </summary>
        List<QuestEngine.Quest> quests;



    }

    /// <summary>
    /// Магазин
    /// </summary>
    class Shop : TownObject
    {

        /// <summary>
        /// Создание магазина
        /// </summary>
        /// <param name="Name">Название магазина</param>
        public Shop(string Name)
            :base(Name)
        {

        }

        /// <summary>
        /// Предметы из магазина (оружие, броня и.т.п)
        /// </summary>
        List<Item> ShopItems;

    }



    /// <summary>
    /// Город
    /// </summary>
    class Town
    {
        /// <summary>
        /// Создание города
        /// </summary>
        /// <param name="Name">Название города</param>
        /// <param name="coord">Координаты города</param>
        /// <param name="Id">ID города</param>
        /// <param name="town">Список объектов города</param>
        public Town(string Name, Coords coord, int Id, List<TownObject> town = null)
        {
            this.Name = Name;
            this.coord = coord;
            this.Id = Id;
            if (town != null)
                this.town = town;
        }

        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Координаты города
        /// </summary>
        public Coords coord { get; set; }


        /// <summary>
        /// Список объектов города
        /// </summary>
        List<TownObject> town { get; set; } = new List<TownObject>();


        /// <summary>
        /// ID города
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Координаты
    /// </summary>
    class Coords
    {
        /// <summary>
        /// Создание координат
        /// </summary>
        /// <param name="xCord">Координата X</param>
        /// <param name="yCord">Координата Y</param>
        public Coords(int xCord, int yCord)
        {
            this.xCord = xCord;
            this.yCord = yCord;
        }

        /// <summary>
        /// Координата X
        /// </summary>
        public int xCord { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public int yCord { get; set; }

    }

    /// <summary>
    /// Карта игры
    /// </summary>
    static class Map
    {
        /// <summary>
        /// Расстояние между городами
        /// </summary>
        public static int[,] distance;

        /// <summary>
        /// Добавить город
        /// </summary>
        /// <param name="Name">Название города</param>
        /// <param name="coord">Координаты города</param>
        /// <param name="Id">ID города</param>
        /// <param name="town">Список объектов города</param>
        public static void AddTown(string Name, Coords coord, int Id, List<TownObject> town = null)
        {
            Towns.Add(new Town(Name, coord, Id, town));
        }

        /// <summary>
        /// Убрать город 
        /// </summary>
        /// <param name="Name">Название города</param>
        public static void RemoveTown(string Name)
        {
            Town finded = Towns.Find(x => x.Name == Name);
            if (finded != null)
                Towns.Remove(finded);
        }

        /// <summary>
        /// Создание карты
        /// </summary>
        public static void CreateMap()
        {
            string[] mapobjects = System.IO.File.ReadAllLines(@"C:\Users\riiji\source\repos\RPG\RPG\epicgame.map");
            for (int i = 0; i < mapobjects.Length; ++i)
            {
                string[] s1, s2;
                s1 = mapobjects[i].Split(':');
                s2 = s1[0].Split(';');
                AddTown(s1[1], new Coords(Int32.Parse(s2[0]), Int32.Parse(s2[1])), i, null);
            }
            distance = new int[mapobjects.Length, mapobjects.Length];

            for (int i = 0; i < mapobjects.Length; ++i)
            {
                for (int j = 0; j < mapobjects.Length; ++j)
                {
                    int xCordi = Towns[i].coord.xCord;
                    int yCordi = Towns[i].coord.yCord;

                    int xCordj = Towns[j].coord.xCord;
                    int yCordj = Towns[j].coord.yCord;

                    int dst = (int)Math.Sqrt(Math.Abs(xCordi - xCordj) * Math.Abs(xCordi - xCordj) + Math.Abs(yCordi - yCordj) * Math.Abs(yCordi - yCordj));

                    distance[i, j] = dst;
                    distance[j, i] = dst;

                }

            }

        }

        /// <summary>
        /// Вернуть ID города по имени города
        /// </summary>
        /// <param name="s">Имя города</param>
        /// <returns>ID города</returns>
        private static int IdTownByName(string s)
        {
            Town t1 = Towns.Find(x => x.Name == s);
            if (t1 != null)
                return t1.Id;
            return -1;
        }

        /// <summary>
        /// Получить расстояние между городами
        /// </summary>
        /// <param name="id1">ID первого города</param>
        /// <param name="id2">ID второго города</param>
        /// <returns></returns>
        public static int GetDistance(int id1, int id2)
        {
            return distance[id1, id2];
        }

        /// <summary>
        /// Получить расстояние между городами
        /// </summary>
        /// <param name="n1">Название первого города</param>
        /// <param name="n2">Название второго города</param>
        /// <returns></returns>
        public static int GetDistance(string n1, string n2)
        {
            int fid = IdTownByName(n1);
            int sid = IdTownByName(n2);

            if (fid != -1 && fid != -1)
                return distance[fid, sid];
            return -1;
        }

        /// <summary>
        /// Список объектов города
        /// </summary>
        public static List<Town> Towns { get; set; } = new List<Town>();
    }


}
