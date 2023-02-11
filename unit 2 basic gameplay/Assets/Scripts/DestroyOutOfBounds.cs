using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 40;
    private float botBound = -15;
    private int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Lives " + lives);
        if (transform.position.z > topBound) Destroy(gameObject);
        else if (transform.position.z < botBound)
        {
            lives -= 1;
            if (lives == 0)
            {
                Debug.Log("Game Over!");
                Destroy(gameObject);
                Thread.Sleep(5000);
                Application.Quit();
            }
            
        }

    }
}
