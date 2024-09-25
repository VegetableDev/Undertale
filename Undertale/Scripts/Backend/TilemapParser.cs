using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Undertale.Scripts.Backend
{
    public static class TilemapParser
    {
        public static Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            string json = File.ReadAllText(filepath);
            

            return result;
        }

        
    }

    

}
