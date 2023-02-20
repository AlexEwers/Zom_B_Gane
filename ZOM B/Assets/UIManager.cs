using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _ammoText;
    [SerializeField]
    private Text _DeathText;
    public void UpdateAmmo(int count)
    {
        _ammoText.text = "Ammo:" + count; 
    }
    public void UpdateDeath(int count)
    {
        _DeathText.text = "Deaths: " + count;
    }
}
