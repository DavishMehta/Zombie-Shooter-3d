using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCanvas : MonoBehaviour
{
    [SerializeField] Canvas attackCanvas;
    [SerializeField] float canvasLifeTime = 1.3f;
    void Start()
    {
        attackCanvas.enabled = false;  
    }

    public void OnAttack() {
        StartCoroutine("beingAttacked");
    }

    IEnumerator beingAttacked()
    {
        attackCanvas.enabled = true;
        yield return new WaitForSecondsRealtime(canvasLifeTime);
        attackCanvas.enabled = false;
    }
}
