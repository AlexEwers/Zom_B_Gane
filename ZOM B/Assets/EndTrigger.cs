using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
 void OnTriggerEnter()
    {
        {
            SceneManager.LoadScene("you'rewinner");
        }
    }
}
