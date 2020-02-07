using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /////////////////////////////////
    //         Lives Script        //
    /////////////////////////////////

    // Sets number of lives in Unity
    public int lives = 1;

    void lifeCounter()
    {
        if (lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /////////////////////////////////
    // 2D Collider Triggers Script //
    /////////////////////////////////

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enemy hit");
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("enemy damage taken");
            lives--;
            lifeCounter();
        }
    }
}
