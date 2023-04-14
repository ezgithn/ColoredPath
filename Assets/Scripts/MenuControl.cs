using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public string Level1;

   // public void GoNextScene()
    //{
   //  SceneManager.LoadScene(Level1);
  //  }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenOptions()
    {

    }
    public void CloseOptions()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {

    }


}
