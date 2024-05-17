using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

public class AiMovement : MonoBehaviour
{
    static NavMeshAgent agent;
    bool canPosition = true;
    [SerializeField] Transform player;
    Vector3 target;
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
                if(canPosition)
                    StartCoroutine(decidePosition(0,5));
                break;
            case movementSettings.Wall:
                if(canPosition)
                    StartCoroutine(decidePosition(1,10));
                break;
        }
        agent.SetDestination(target);
        Vector3 targetT = target;
        float angle = Mathf.Atan2(targetT.y - gameObject.transform.position.y, targetT.x-gameObject.transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle-90));
    }
    IEnumerator decidePosition(int movementStyle, float cooldownTime)
    {
        canPosition = false;
        yield return new WaitForSeconds(cooldownTime);
        if(movementStyle == 0)
        {
            target = new Vector3(UnityEngine.Random.Range(-12.5f,12.5f), UnityEngine.Random.Range(-7,7), 0);
        }
        else if(movementStyle == 1)
        {
            RaycastHit2D hitU = Physics2D.Raycast(transform.position, Vector2.up, 99, LayerMask.GetMask("Wall"));
            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 99, LayerMask.GetMask("Wall"));
            RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, 99, LayerMask.GetMask("Wall"));
            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 99, LayerMask.GetMask("Wall"));
        }
        canPosition = true;
    }
}
