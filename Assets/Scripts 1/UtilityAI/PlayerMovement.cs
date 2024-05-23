using System.Collections;
using System.Collections.Generic;
using TL.Core;
using TL.UtilityAI.Actions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public InputAction c_mousePosition;
    [SerializeField] InputAction c_playerMove;
    public InputAction c_mouseClicked;

    private float distance;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        c_mousePosition.Enable();
        c_playerMove.Enable();
        c_mouseClicked.Enable();
       
    }

    // Update is called once per frame
    void Update()
    {
        //playerMovement();
       
            
    }
    // void playerMovement()
    // {
    //     Vector2 player, mouse;
    //     float angle;
    //     player = gameObject.transform.position;
    //     mouse = (Vector2)Camera.main.ScreenToWorldPoint(c_mousePosition.ReadValue<Vector2>());
    //     angle = Mathf.Atan2(player.y - mouse.y, player.x - mouse.x) * Mathf.Rad2Deg;
    //     transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    //     distance = Mathf.Sqrt(Mathf.Pow(player.x - mouse.x, 2) + Mathf.Pow(player.y - mouse.y, 2));

    //     rb.MovePosition(rb.position += c_playerMove.ReadValue<Vector2>() * Time.deltaTime * Stats.player[0].speed);
    // }
}

   




