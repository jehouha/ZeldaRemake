using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{   
    /////////////////////////////////
    //   Start & Update Script     //
    /////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        // Set rupee count to 0
        rupeeCount = 0;
        RupeeCounter();
        
        // Set life hearts to visible
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);

        // Apply audio manager
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerMovement Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        LifeCounter();
        //PlayerAttack();
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
        /*if ((Input.GetKey("d")) || Input.GetKey("right")) 
        {
            animator.Play("Player_side");

            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKey("a") || Input.GetKey("left")) 
        {
            animator.Play("Player_side");

            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey("w") || Input.GetKey("up")) 
        {
            animator.Play("Player_back");
        }

        if (Input.GetKey("s") || Input.GetKey("down")) 
        {
            animator.Play("Player_front");
        }

        PlayerAttack();*/
    }

    /////////////////////////////////
    //    PlayerAttack Script      //
    /////////////////////////////////

    bool isAttacking = false;

    /*Animator animator;
    SpriteRenderer spriteRenderer;

    void PlayerAttack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Melee_attack");
        }

        if (Input.GetButtonDown("Fire2") && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Ranged_attack");
        }
    }*/

    /////////////////////////////////
    //         Lives Script        //
    /////////////////////////////////

    // Sets number of lives and lives sprites in Unity
    public int lives = 3;
    public GameObject life1, life2, life3;

    void LifeCounter()
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

        if (lives <= 0)
        {
            EndGame();
        }
    }

    /////////////////////////////////
    //        Rupee Counter        //
    /////////////////////////////////

    // Accepts the Text UI object in Unity
    public Text countText;

    // Holds the number of Rupees
    private int rupeeCount;

    void RupeeCounter()
    {
        countText.text = "X" + rupeeCount.ToString();
    }

    /////////////////////////////////
    //        Camera Script        //
    /////////////////////////////////

    void CameraMove()
    {
        transform.position = new Vector2(-23.0f, 10.0f);
        Camera.main.transform.position = new Vector3(-23.0f, 11.15f, -10f);
    }

    /////////////////////////////////
    //    Sound Effects Script     //
    /////////////////////////////////

    // Reference AudioManager script
    private AudioManager audioManager;

    // Sound names
    public string bgmSoundName;
    public string hitSoundName;
    /*public string rangedSoundName;
    public string meleeSoundName;
    public string pickupSoundName;
    public string doorSoundName;*/

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
            Debug.Log("player damage taken");
            lives--;
            audioManager.PlaySound(hitSoundName);
        }

        if (other.gameObject.CompareTag("heart"))
        {
            Debug.Log("heart added");
            lives++;
            other.gameObject.SetActive(false);
            //audioManager.PlaySound(pickupSoundName);
        }

        if (other.gameObject.CompareTag("rupee"))
        {
            Debug.Log("rupee added");
            rupeeCount++;
            other.gameObject.SetActive(false);
            RupeeCounter();
            //audioManager.PlaySound(pickupSoundName);
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
                RupeeCounter();
                //audioManager.PlaySound(pickupSoundName);
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
            //audioManager.PlaySound(pickupSoundName);
        }

        if (other.gameObject.CompareTag("door"))
        {
            Debug.Log("gone thru door");
            CameraMove();
            //audioManager.PlaySound(doorSoundName);
        }
    }

    /////////////////////////////////
    //      Game Over Script       //
    /////////////////////////////////

    bool gameOver = false;

    private PauseManager pauseManager;

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Debug.Log("EndGame Run");
            SceneManager.LoadScene(0);
            //pauseManager.LoseGame();
        }
    }
}
