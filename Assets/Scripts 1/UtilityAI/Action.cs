using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;


namespace TL.UtilityAI
{
    // Scriptable Objects: Stateless objects that is not aware of what is in the start of the game

    public abstract class Action : ScriptableObject
    {

        public BossController boss;
        public string Name;
        private float _score;

        public float score
        {
            get { return _score; }
            set
            {
                this._score = Mathf.Clamp01(value);
            }
        }

        /*
         ********************************************
         * All Actions Are Scored The Same Way.
         * Not All Considerations Are The Same
         ******************************************** 
         */

        public Consideration[] considerations;

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract void Execute(BossController boss);
       
    }
}
