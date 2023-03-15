using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class net_movement : MonoBehaviour
{
    public Rigidbody2D net;
    public float speed = 5f;
    public bool move_left = false;
    public bool move_right = false;

    public Text Final_Result;
    public Text You_Win;

    public GameManager game_manager;
    
    public int score = 0;
    
    [SerializeField]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fish_Img")
        {
            score = score + 1;
            Destroy(collision.gameObject);
        }
        
        if(score == game_manager.target_score)
        {
            game_manager.stop_spwanning();
            You_Win.gameObject.SetActive(true);
            Final_Result.gameObject.SetActive(false);
            StartCoroutine(ExampleCoroutine());
        }

        if(collision.tag == "Bomb_Tag_again")
        {
            Destroy(collision.gameObject);
            game_manager.stop_spwanning();
            Final_Result.gameObject.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Final_Result.gameObject.SetActive(false);
        You_Win.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the net object
        Vector3 currentPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.A))
        {
            move_left = true;

            // Move the object to the left position until A is pressed
            net.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            // Since the A key has been released we want to stop moving to the left 
            move_left = false;
            // Now this is a very important part as we want the user to continuously
            // keep playing the game [Thereby, playing with the A and D keys at very short intervals]
            if (move_right == false)
            {
                net.velocity = new Vector2(0f, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            move_right = true;
            // Move the object to the right position
            net.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            move_right = false;
            // So again we only want the velocity to be zero when the user is not pressing A to change the 
            // direction
            if (move_left == false)
            {
                net.velocity = new Vector2(0f, 0f);
            }
        }

        // Clamp the position of the net object to the edges of the screen
        float clampedX = Mathf.Clamp(currentPosition.x, -6f, 6f);
        transform.position = new Vector3(clampedX, currentPosition.y, currentPosition.z);
    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
