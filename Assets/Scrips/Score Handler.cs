using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    WeaponScript weaponScript;
    AmmoHandler ammoHandler;
    
    void Start()
    {
        ammoHandler = GetComponent<AmmoHandler>();
    }

    void Update()
    {
        Score.text = ammoHandler.GetAmmo(GetComponentInChildren<WeaponScript>().ammogetter).ToString();
    }
}
