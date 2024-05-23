using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TL.Core;

namespace TL.UtilityAI
{

    public class AIBrain : MonoBehaviour
    {
        /*
         * FOR TUTORIAL CREATE A WAIT FUNCTION FOR WHEN PLAYER IS ACTUALLY PLAYING THE GAME
         */
        public bool finishedDeciding { get; set; }
        public Action bestAction { get; set; }
        private BossController boss;

       
        void Start()
        {
            boss = GetComponent<BossController>();
        }

      
        void Update()
        {
            if(bestAction is null)
            {
                DecideBestAction(boss.actionsAvaliable);
            }
        }

        // Loop through all the available actions
        // Give the highest scoring action
        public void DecideBestAction(Action[] actionsAvaliable)
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            for(int i = 0; i < actionsAvaliable.Length; i++)
            {
                if (ScoreAction(actionsAvaliable[i])  > score) 
                {
                    nextBestActionIndex = i;
                    score = actionsAvaliable[i].score;
                }
            }
            bestAction = actionsAvaliable[nextBestActionIndex];
            finishedDeciding = true;

        }

        //Loop through all the considerations of the action
        //Score all the considerations
        //Average the considerations ==> overall action score

        public float ScoreAction(Action action)
        {
            float score = 1f;
            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration(boss);
                score *= considerationScore;

                if(score == 0)
                {
                    action.score = 0;
                    return action.score; // There isn't a point making a decision.
                }

            }

            // Averaging scheme of overall score
            // Rescales Schematics to make Reasonable numbers.
            // Dave Mark Pioneer Utility AI (My Inspiration).

            float originalScore = score;  
            float modFactor = 1 - (1 /action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;



        }


    }
}
