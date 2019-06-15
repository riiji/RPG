using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class TownObject
    {

    }

    class Town
    {
        public Town(string Name, Coords coord, int Id,List<TownObject> town = null)
        {
            this.Name = Name;
            this.coord = coord;
            this.Id = Id;
            if (town != null)
                this.town = town;
        }

        public string Name { get; set; }

        public Coords coord { get; set; }

        List<TownObject> town { get; set; } = new List<TownObject>();

        public int Id { get; set; }
    }

    class Coords
    {
        public Coords(int xCord, int yCord)
        {
            this.xCord = xCord;
            this.yCord = yCord;
        }

        public int xCord { get; set; }
        public int yCord { get; set; }

    }

    static class Map
    {
        public static int[,] distance;

        public static void AddTown(string Name, Coords coord,int Id, List<TownObject> town = null)
        {
            Towns.Add(new Town(Name, coord, Id,town));
        }

        public static void RemoveTown(string Name)
        {
            Town finded = Towns.Find(x => x.Name == Name);
            if (finded != null)
                Towns.Remove(finded);
        }

        public static void CreateMap()
        {
            string[] mapobjects = System.IO.File.ReadAllLines(@"C:\Users\riiji\source\repos\RPG\RPG\epicgame.map");
            for (int i = 0; i < mapobjects.Length; ++i)
            {
                string[] s1, s2;
                s1 = mapobjects[i].Split(':');
                s2 = s1[0].Split(';');
                AddTown(s1[1], new Coords(Int32.Parse(s2[0]), Int32.Parse(s2[1])), i,null);
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

                    distance[i,j] = dst;
                    distance[j,i] = dst;

                }
                
            }

        }

        private static int IdTownByName(string s)
        {
            Town t1 = Towns.Find(x => x.Name == s);
            if (t1 != null)
                return t1.Id;
            return -1;
        }

        public static int GetDistance(int id1, int id2)
        {
            return distance[id1, id2];
        }

        public static int GetDistance(string n1,string n2)
        {
            int fid = IdTownByName(n1);
            int sid = IdTownByName(n2);

            if (fid != -1 && fid != -1)
                return distance[fid, sid];
            return -1;
        }

        public static List<Town> Towns { get; set; } = new List<Town>();
    }


}
