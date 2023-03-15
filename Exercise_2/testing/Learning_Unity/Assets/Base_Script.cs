using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Base_Script : MonoBehaviour
{
    public int Total_Lives = 3;
    public GameManager stop_drops;

    public Text Display_end_result;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fish_Img")
        {
            Total_Lives -= 1;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Bomb_Tag_again")
        {
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Display_end_result.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Total_Lives==0)
        {
            stop_drops.stop_spwanning();
            Display_end_result.gameObject.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
    
    }
    IEnumerator ExampleCoroutine()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
