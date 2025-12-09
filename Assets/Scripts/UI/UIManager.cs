using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] GameObject endGame;
    [SerializeField] TextMeshProUGUI finalMessage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGame.SetActive(false);
    }

    public void GameWin()
    {
        endGame.SetActive(true);

        finalMessage.SetText("VICTORY");
        finalMessage.color = Color.yellow;
    }

    public void GameOver()
    {
        endGame.SetActive(true);

        finalMessage.SetText("DEFEAT");
        finalMessage.color = Color.red;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit() 
    {
        SceneManager.LoadScene(0);
    }
}
