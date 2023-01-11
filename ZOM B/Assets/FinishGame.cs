using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public void ReturntoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}