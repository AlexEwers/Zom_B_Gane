using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Score score;

    public void Targetdestoryed(Target target)
    {
        if  (target.health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
