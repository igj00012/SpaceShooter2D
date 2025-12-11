using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] GameObject endGame;
    [SerializeField] TextMeshProUGUI finalMessage;

    [Header("Audio Clips")]
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGame.SetActive(false);
    }

    public void GameWin()
    {
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySFX(win);

        endGame.SetActive(true);

        finalMessage.SetText("VICTORY");
        finalMessage.color = Color.yellow;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioManager.instance.StopMusic();
        AudioManager.instance.PlaySFX(lose);

        endGame.SetActive(true);

        finalMessage.SetText("DEFEAT");
        finalMessage.color = Color.red;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        AudioManager.instance.PlaySFX(clip);

        SceneManager.LoadScene(1);

        AudioManager.instance.PlayMusic(music);
    }

    public void Exit() 
    {
        Time.timeScale = 1f;

        AudioManager.instance.PlaySFX(clip);

        SceneManager.LoadScene(0);
    }
}
