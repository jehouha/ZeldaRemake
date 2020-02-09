using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
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

    // Set rupee as loot
    public GameObject lootDrop;

    void lifeCounter()
    {
        if (lives <= 0)
        {
            Destroy(this.gameObject);
            GameObject a = Instantiate(lootDrop, transform.position, lootDrop.transform.rotation) as GameObject;
        }
    }

    /////////////////////////////////
    // 2D Collider Triggers Script //
    /////////////////////////////////

    // Reference AudioManager script
    private AudioManager audioManager;

    public string enemyHitSoundName;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enemy hit");
        if (other.gameObject.CompareTag("player"))
        {
            Debug.Log("enemy damage taken");
            lives--;
            lifeCounter();
            audioManager.PlaySound(enemyHitSoundName);
        }
    }
}
