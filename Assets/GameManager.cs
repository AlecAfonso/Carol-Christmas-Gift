using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int count = 0;
    private int totalLetters = 62;
    public GameObject linkButton;
    public GameObject resetPanel;

    private void Update() {
        if (count >= totalLetters) {
            linkButton.SetActive(true);
        }
    }

    public void addLetter() {
        count++;
    }

    public void OpenLink() {
        Application.OpenURL("https://drive.google.com/drive/folders/1N75lpV-5qf1T7YQ11B6nUck8_rtMTQRn");
    }

    public void OpenResetMenu() { 
        resetPanel.SetActive(true);
    }

    public void CloseResetMenu() {
        resetPanel.SetActive(false);
    }

    public void ResetCurrentScene() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
