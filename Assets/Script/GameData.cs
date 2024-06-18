using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    //Luu tru thong tin nguoi choi
    [Serializable]
    public class GameData
    {
        public int score = 0;
        public string timePlayed;
    }
    [Serializable]
    public class GameDataPlayed
    {
        public List<GameData> plays;
    }
}
