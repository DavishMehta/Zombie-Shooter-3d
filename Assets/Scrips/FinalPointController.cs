using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalPointController : MonoBehaviour
{
    //[SerializeField] Texttmeshpro
    [SerializeField] TextMeshProUGUI Winning_text_holder;
    DeathHandler deathHandler;
    private void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        deathHandler.ShowWinCanvas(Winning_text_holder);
    }
}
