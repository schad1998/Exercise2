using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject fish_prefab;

    public GameObject Bomb_prefab;
    public int target_score = 20;
    public Text myText;
    public net_movement display_catch_score;

    // Start is called before the first frame update
    void Start()
    {
        spwanning_things(); 
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = "Score: " + display_catch_score.score.ToString();
        
    }

    void spwan_fish()
    {
        float temporary_position = Random.Range(-6f,6f);
        Instantiate(fish_prefab, new Vector3(temporary_position, 10f, 0), Quaternion.identity);
    }

    void spwan_Bomb()
    {
        float temporary_pos_bomb = Random.Range(-6f,6f);
        Instantiate(Bomb_prefab, new Vector3(temporary_pos_bomb, 10f, 0), Quaternion.identity); 
    }

    public void spwanning_things()
    {
        InvokeRepeating("spwan_fish", 2,2);
        InvokeRepeating("spwan_Bomb", 6,6);  
    }

    public void stop_spwanning()
    {
        CancelInvoke();
    }
}
