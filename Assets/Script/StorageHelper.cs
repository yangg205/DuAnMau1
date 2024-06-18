using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

namespace Assets.Script
{
    public class StorageHelper
    {
        private readonly string filename = "game_data.txt";
        public GameDataPlayed played;
        public void LoadData()
        {
            played = new GameDataPlayed()
            {
                plays = new List<GameData>
                {

                }
            };
            //doc chuoi tu file
            string dataAsJason = StorageManager.LoadFromFile(filename);
            if(dataAsJason != null)
            {
                // chuyen chuoi jason thanh object
                played = JsonUtility.FromJson<GameDataPlayed>(dataAsJason);
            }
        }
        public void SaveData()
        {
            //chuyen object thanh chuoi json
            string dataAsJason = JsonUtility.ToJson(played);
            //luu chuoi json vao file
            StorageManager.SaveToFile(filename, dataAsJason);
        }
    }
}
