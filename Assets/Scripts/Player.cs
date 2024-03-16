using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class Player : MonoBehaviour
{
    //UR MOM
    [SerializeField]InputAction c_playerMove;
    public InputAction c_mousePosition;
    [SerializeField]InputAction c_shoot;
    [SerializeField]InputAction c_reload;
    [SerializeField]InputAction c_interact;
    
    [SerializeField]float speed;
    [SerializeField]int ammoCount;

    private PlayerWeapon s_playerWeapon;
    [SerializeField]UIHandler s_UIHandler;
    private Rigidbody2D rb;

    [SerializeField]GameObject interactable;

    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        c_playerMove.Enable();
        c_mousePosition.Enable();
        c_shoot.Enable();
        c_reload.Enable();
        c_interact.Enable();

        c_shoot.performed += shoot;
        c_reload.performed += reload;
        c_interact.performed += interact;

        mask = LayerMask.GetMask("Interactable");

        rb = gameObject.GetComponent<Rigidbody2D>();
        s_playerWeapon = gameObject.GetComponentInChildren<PlayerWeapon>();
    }
    // Update is called once per frame
    void Update()
    {
        playerMovement();
        updateUI();
    }
    void playerMovement()
    {
        Vector2 player, mouse, gun;
        float angle;
        player = gameObject.transform.position;
        mouse = (Vector2)Camera.main.ScreenToWorldPoint(c_mousePosition.ReadValue<Vector2>());
        angle = Mathf.Atan2(player.y - mouse.y, player.x-mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle+90));
        gun = s_playerWeapon.transform.position;

        rb.MovePosition(rb.position += c_playerMove.ReadValue<Vector2>()*Time.deltaTime*5);
    }
    void shoot(InputAction.CallbackContext ctx)
    {
        s_playerWeapon.shoot();
    }
    void reload(InputAction.CallbackContext ctx)
    {
        int current = s_playerWeapon.getcurrentMagSize();
        int max = s_playerWeapon.getMaxMagSize();
        int need = max - current;
        if(need > ammoCount)
            need = ammoCount;
        if(ammoCount == 0)
        {
            Debug.Log("You are out of bullets");
            return;
        }
        Debug.Log(need);
        s_playerWeapon.reload(need);
        ammoCount -= need;
    }
    void interact(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  mask);
        if(hit == true)
        {
            Intractable temp = hit.transform.gameObject.GetComponent<Intractable>();
            ammoCount += temp.getBulletCount();
            temp.useInteractable();
        }
    }
    void updateUI()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 2,  mask);
        if(hit == true)
            s_UIHandler.setInteractText(true, hit.transform.gameObject.name);
        else
            s_UIHandler.setInteractText(false);
    }
}
