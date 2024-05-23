using System.Collections;
using System.Collections.Generic;
using TL.UtilityAI;
using TL.UtilityAI.Actions;
using UnityEngine;
using UnityEngine.AI;



namespace TL.Core
{
    public class MoveController : MonoBehaviour
    {
        
        static NavMeshAgent agent;
        [SerializeField] Transform target;
        int r;
       
        
        void Start()
        {
             agent = GetComponent<NavMeshAgent>();
             agent.updateRotation = false;
             agent.updateUpAxis = false;
           
        }


        void Update()
        {
            agent.SetDestination(target.position);
            // Graphics Controller
            if(Stats.level == 1)
            {
                if (agent.remainingDistance < 2)
                {
                    Attack.cameraFlashEnabled = true;
                }
                if(agent.remainingDistance <= 4)
                {
                    Attack.stillShotEnabled = true;
                }
            }
            if (Stats.level == 2)
            {
                r = Random.Range(0, 3);
                if (agent.remainingDistance > 1)
                {
                    Attack.shootEnabled = true;
                }
                else
                {
                    Attack.shootEnabled = false;
                }
                if (r == 2)
                {
                    Attack.bloodEnabled = true;
                }
                else
                {
                    Attack.bloodEnabled = false;
                }
                if(r == 0)
                {
                    Attack.colorShiftEnabled = true;
                }
                else
                {
                    Attack.colorShiftEnabled = false;
                }
            }

            // Raging Ricky Controller

            if(Stats.level == 3)
            {
                r++;
                if (agent.remainingDistance > 1 && agent.remainingDistance < 2)
                {
                    Attack.shootEnabled = true;
                }
                else if(agent.remainingDistance > 3)
                {
                    Attack.shootEnabled = false;

                  

                    Attack.missleEnabled = true;

                }
                else
                {
                    Attack.missleEnabled = false;
                }
                if (r < 7)
                {
                    Debug.Log("5");
                    Attack.castleOfGlassEnabled = false;
                   
                }
                else
                {
                        Debug.Log("4");
                        Attack.castleOfGlassEnabled = true;
                    r = 0;
                    
                  
                }
                


            }

            // VIDEO GAME CONTROLLER
            if (Stats.level == 4)
            {
                r = Random.Range(0, 10);
                if (agent.remainingDistance < 2)
                {
                    agent.stoppingDistance = 1.2f;
                
                }if(agent.remainingDistance > 3)
                {
                    Attack.puppeteerEnabled = true;
                }
                else
                {
                    Attack.puppeteerEnabled= false;
                }
                
                if(r == 7)
                {
                    Attack.squareOfLightingEnabled = true;
                }
                else
                {
                    Attack.squareOfLightingEnabled= false;
  
                }
                
            }
           
        }
        
    }
}
