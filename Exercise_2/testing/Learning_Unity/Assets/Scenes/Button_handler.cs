using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_handler : MonoBehaviour
{
   public void ONCLICK_start()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void OnClick_Quit()
   {
        Application.Quit();
   }

   public void ONCLICK_Back_to_main()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2 );
   }

}
