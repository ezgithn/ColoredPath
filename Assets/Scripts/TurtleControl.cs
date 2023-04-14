using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurtleControl : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float restartDelay = 3f;

    public Vector3 startPos1;
    public Vector3 startPos2;

    public Transform currentPoint;
    public GameObject TurtleShell;
    
  
    void Start()
    {
        startPos1 = TurtleShell.transform.position;
    }

    void Update()
    {
        TurtleShell.transform.position = Vector3.MoveTowards(TurtleShell.transform.position, startPos1, Time.deltaTime * moveSpeed);

        if (TurtleShell.transform.position == startPos1)
        { startPos1 = startPos2;
            
        }

        if (startPos1 == startPos2)
        {
            startPos2 = TurtleShell.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Invoke("RestartLevel", restartDelay);
        }

    }
    void RestartGame()
    {
        StartCoroutine(WaitAndRestart());
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(restartDelay);
    }

}
    
