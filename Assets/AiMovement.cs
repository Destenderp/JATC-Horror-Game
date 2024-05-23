using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NavMeshPlus.Extensions;
using TL.Core;
using TL.UtilityAI.Actions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AiMovement : MonoBehaviour
{
    static NavMeshAgent agent;
    bool canPosition = true;
    bool persuingPlayer = false;
    [SerializeField] int health;

    Vector2[] directions = {Vector2.down, Vector2.left, Vector2.right, Vector2.up};
    [SerializeField] Transform player;
    Vector3 target;
    int r;
    public enum movementSettings
    {
        Static,
        Free,
        Wall
    }
    [SerializeField] movementSettings movement;
    //int r;
    //int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        canPosition = true;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(persuingPlayer);
            Debug.DrawRay(transform.position, Vector2.up*100, Color.red);
            Debug.DrawRay(transform.position, Vector2.left*100, Color.green);
            Debug.DrawRay(transform.position, Vector2.right*100, Color.blue);
            Debug.DrawRay(transform.position, Vector2.down*100, Color.black);
        Debug.Log(target);
        switch (movement)
        {
            case movementSettings.Static:
                target = player.position;
                break;
            case movementSettings.Free:
                if(canPosition && !persuingPlayer)
                    StartCoroutine(decidePosition(0,5));
                else if(persuingPlayer)
                    target = player.position;
                break;
            case movementSettings.Wall:
                if(canPosition && !persuingPlayer)
                    StartCoroutine(decidePosition(1,5));
                else if(persuingPlayer)
                    target = player.position;
                break;
        }
        Debug.Log("REMAINING DISTANCE: " + agent.remainingDistance);
        agent.SetDestination(target);
        Vector3 targetT = target;
        float angle = Mathf.Atan2(targetT.y - gameObject.transform.position.y, targetT.x-gameObject.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle-90));

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
    IEnumerator decidePosition(int movementStyle, float cooldownTime)
    {
        canPosition = false;
        Debug.Log("Running" + movementStyle);
        yield return new WaitForSeconds(cooldownTime);
        if(movementStyle == 0)
        {
            target = new Vector3(UnityEngine.Random.Range(-12.5f,12.5f), UnityEngine.Random.Range(-7,7), 0);
        }
        if(movementStyle == 1)
        {
            Debug.Log("Movement Style 1 Running");
            List<Vector2> positions = new List<Vector2>();
            for (int i = 0; i < directions.Length; i++)
            {
                Debug.Log("Looking for Walls");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], 99, LayerMask.GetMask("Wall"));
                if(hit.collider != null)
                {
                    Debug.Log("Found a Wall!");
                    positions.Add(hit.collider.transform.position);
                }
            }
            if(positions.Count == 1)
            {
                Debug.Log("Setting Position");
                target = positions[0];
            }
            else
            {
                int choice = UnityEngine.Random.Range(0,positions.Count);
                target = positions[choice];
            }


        }
        canPosition = true;
    }
    public void takeDamage(int damage)
    {
        health += damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
            persuingPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.name == "Player")
            persuingPlayer = false;
    }
}
