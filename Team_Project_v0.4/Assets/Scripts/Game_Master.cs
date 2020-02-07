using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Master : MonoBehaviour
{
    /////////////////////////////////
    //   Start & Update Script     //
    /////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        // Set rupee count to 0
        rupeeCount = 0;
        rupeeCounter();
        
        // Set life hearts to visible
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);

        // Plays BGM
        audioManager.PlaySound(bgmSoundName);
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerMovement Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        lifeCounter();
        playerAttack();
    }

    /////////////////////////////////
    //    PlayerMovement Script    //
    /////////////////////////////////
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Directions for animation
        if ((Input.GetKey("d")) || Input.GetKey("right")) 
        {
            animator.Play("Player_side");

            spriteRenderer.flipX = false;
        }

        if (Input.GetKey("a") || Input.GetKey("left")) 
        {
            animator.Play("Player_side");

            spriteRenderer.flipX = true;
        }

        if (Input.GetKey("w") || Input.GetKey("up")) 
        {
            animator.Play("Player_back");
        }

        if (Input.GetKey("s") || Input.GetKey("down")) 
        {
            animator.Play("Player_front");
        }

        playerAttack();
    }

    /////////////////////////////////
    //    PlayerAttack Script      //
    /////////////////////////////////

    Animator animator;
    SpriteRenderer spriteRenderer;

    void playerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.Play("Melee_attack");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            animator.Play("Ranged_attack");
        }
    }

    /////////////////////////////////
    //        Camera Script        //
    /////////////////////////////////

    void cameraMove()
    {
        transform.position = new Vector2(-23.0f, 10.0f);
        Camera.main.transform.position = new Vector3(-23.0f, 11.15f, -10f);
    }

    /////////////////////////////////
    //         Lives Script        //
    /////////////////////////////////

    // Sets number of lives and lives sprites in Unity
    public int lives = 3;
    public GameObject life1, life2, life3;

    void lifeCounter()
    {
        // Turn on and off life hearts
        switch (lives)
        {
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 2:
                life1.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
            case 1:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                break;
            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
        }
    }

    /////////////////////////////////
    //    Sound Effects Script     //
    /////////////////////////////////

    // Sound names
    public string bgmSoundName;
    public string hitSoundName;
    public string rangedSoundName;
    public string meleeSoundName;
    public string pickupSoundName;
    public string doorSoundName;

    /////////////////////////////////
    // 2D Collider Triggers Script //
    /////////////////////////////////

    // Inventory Bools
    public bool keyHeld = false;
    public bool swordHeld = false;

    // Inventory Numbers
    public Text haveKey;
    public GameObject haveSword;

    // Note: Require 'Is Trigger'
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("damage taken");
            lives--;
            audioManager.PlaySound(hitSoundName);
        }

        if (other.gameObject.CompareTag("heart"))
        {
            Debug.Log("heart added");
            lives++;
            other.gameObject.SetActive(false);
            audioManager.PlaySound(pickupSoundName);
        }

        if (other.gameObject.CompareTag("rupee"))
        {
            Debug.Log("rupee added");
            rupeeCount++;
            other.gameObject.SetActive(false);
            rupeeCounter();
            audioManager.PlaySound(pickupSoundName);
        }
        
        if (other.gameObject.CompareTag("key"))
        {
            if (rupeeCount >= 10)
            {
                Debug.Log("key added");
                keyHeld = true;
                other.gameObject.SetActive(false);
                haveKey.text = "X1";
                Debug.Log("money spent");
                rupeeCount = rupeeCount - 10;
                rupeeCounter();
                audioManager.PlaySound(pickupSoundName);
            }
            else
            {
                Debug.Log("not enough rupees");
            }
        }

        if (other.gameObject.CompareTag("sword"))
        {
            Debug.Log("sword added");
            swordHeld = true;
            other.gameObject.SetActive(false);
            haveSword.gameObject.SetActive(true);
            audioManager.PlaySound(pickupSoundName);
        }

        if (other.gameObject.CompareTag("door"))
        {
            Debug.Log("gone thru door");
            cameraMove();
            audioManager.PlaySound(doorSoundName);
        }
    }

    /////////////////////////////////
    //        Rupee Counter        //
    /////////////////////////////////

    // Accepts the Text UI object in Unity
    public Text countText;

    // Holds the number of Rupees
    private int rupeeCount;

    void rupeeCounter()
    {
        countText.text = "X" + rupeeCount.ToString();
    }
}
