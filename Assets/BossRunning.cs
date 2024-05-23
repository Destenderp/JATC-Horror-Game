using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRunning : MonoBehaviour
{
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        boss.SetActive(true);
    }
}
