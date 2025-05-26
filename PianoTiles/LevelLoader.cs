using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace PianoTiles
{
    public class LevelLoader
    {
        public static char[,] LoadLevelFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Split(' ').Length;

            char[,] map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] tiles = lines[i].Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = tiles[j][0];
                }
            }

            return map;
        }

        public static List<string> GetAllLevelFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath, "*.lvl").ToList();
        }
    }
}
