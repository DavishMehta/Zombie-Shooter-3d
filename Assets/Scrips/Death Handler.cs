using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    public void Start()
    {
        canvas.enabled = false;
    }

    public void ShowGameoverCanvas()
    {
        canvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ShowWinCanvas(TextMeshProUGUI Winning_text_holder)
    {
        Debug.Log("hii");
        Winning_text_holder.text = "YOU WON";
        canvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void reload_level() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void QuitApplication() {
        Application.Quit(); 
    }
}
