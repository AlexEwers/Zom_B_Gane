using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    public int Deaths;
    private UIManager UIManager;

    private void Start()
    {
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            Deaths++;
            UIManager.UpdateDeath(Deaths);
        }
    }
}
