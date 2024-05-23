using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;

namespace TL.UtilityAI

{

    public class BossController : MonoBehaviour
    {
       
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvaliable;
        public Stats stats { get; set; }
      


        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
            stats = GetComponent<Stats>();

    }

        // Update is called once per frame
        void Update()
        {
            if (aiBrain.finishedDeciding)
            {
                aiBrain.finishedDeciding = false;
                aiBrain.bestAction.Execute(this);
            }
        }

        public void OnFinishedAction()
        {
            aiBrain.DecideBestAction(actionsAvaliable);
        }
        #region Coroutine
        public void DoAttack(int time)
        {
            StartCoroutine(AttackCoroutine(time));
        }
        public void DoEvade(int time)
        {
            StartCoroutine(EvadeCoroutine(time));
        }

        public void wait(int time)
        {
            StartCoroutine(WaitCoroutine(time));
        }
      
        IEnumerator AttackCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            OnFinishedAction();
        }
        IEnumerator EvadeCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            OnFinishedAction();

        }
        IEnumerator WaitCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
           

        }

        #endregion
    }
}

