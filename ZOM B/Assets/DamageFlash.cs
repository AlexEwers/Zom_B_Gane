using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

    MeshRenderer meshrenderer;
    Color origColor;
    float flashTime = .15f;
    // Start is called before the first frame update
    void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();
        origColor = meshrenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlashStart();
        }
    }

    void FlashStart()
    {
        meshrenderer.material.color = Color.black;
        Invoke("FlashStop", flashTime);
    }

    void FlashStop()
    {
        meshrenderer.material.color = origColor;

    }
}
