using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatZomLev : MonoBehaviour {

    public GameObject[] enemies;



    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Base_Enemy");
            if (enemies.Length == 0)
        {
            SceneManager.LoadScene("Level 2");
        }
        
    }
}
