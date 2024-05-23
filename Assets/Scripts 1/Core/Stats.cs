using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace TL.Core
{
    public class Stats : MonoBehaviour

    {
        public static List<Boss> bosses = new List<Boss>();
        public static List<Player> player = new List<Player>();
        public static int bossIDLevel;
        public static string bossName;
        public static int bossHealth;
        public static int bossDamage;
        public static int level = 3;
     
        private void Awake()
        {
            // int Level Number, int BossID, string Boss Name, int Health, int Damage
            // BOSS STATS: DO NOT CHANGE

            bosses.Add(new Boss(1, 1, "Video", 100, 0));
            bosses.Add(new Boss(1, 2, "Audio", 100, 0));
            bosses.Add(new Boss(2, 3, "Graphics", 100, 0));
            bosses.Add(new Boss(3, 4, "Animation", 100, 0));
            bosses.Add(new Boss(4, 5, "Game Vidoe", 100, 0));

            // int playerHealth, int Old Reliable Damage, int Mellee Damage
            //TESTING
            player.Add(new Player(5));
        }
        public void Start()
        {
         //DEPENDING ON THE LEVEL CHANGES THE BOSS STATS
            
        }
        public void Update()
        {
            switch (level)
            {
                case 1:
                    bossIDLevel = bosses[0].level;
                    bossName = bosses[0].name;
                    bossHealth = bosses[0].health;
                    bossDamage = bosses[0].damage;

                    break;
                case 2:
                    bossIDLevel = bosses[2].level;
                    bossName = bosses[2].name;
                    bossHealth = bosses[2].health;
                    bossDamage = bosses[2].damage;
                  

                    break;
                case 3:
                    bossIDLevel = bosses[3].level;
                    bossName = bosses[3].name;
                    bossHealth = bosses[3].health;
                    bossDamage = bosses[3].damage;
                   

                    break;
                case 4:
                    bossIDLevel = bosses[4].level;
                    bossName = bosses[4].name;
                    bossHealth = bosses[4].health;
                    bossDamage = bosses[4].damage;
                  

                    break;
                default:
                    break;
            }
        }
        
    }
}
