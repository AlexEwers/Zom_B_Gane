using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerMoves thePlayer;
    public int maxhealth = 3;
    public int currenthealth = 3;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    public HealthBar healthBar;
    public int Deaths;

    private UIManager UIManager;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        thePlayer = FindObjectOfType<PlayerMoves>();
        healthBar.SetMaxHealth(maxhealth);
        UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    public void TakeDamage(int amount)
    {
        currenthealth -= amount;
        healthBar.SetHealth(currenthealth);


        if (currenthealth <= 0)
        {
            Player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            currenthealth = 3;
            healthBar.SetMaxHealth(maxhealth);
            Deaths++;
            UIManager.UpdateDeath(Deaths);
        }
    }


}
