using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.UtilityAI;
using TL.Core;


namespace TL.UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Survive", menuName = "UtilityAI/Actions/Survive")]
    public class Survive : Action
    {
        //Dependency Injection: Class doesn't have a local reference to a local input
        public override void Execute(BossController boss)
        {
            Debug.Log("Survive");
            boss.DoEvade(2);
        }

    }
}