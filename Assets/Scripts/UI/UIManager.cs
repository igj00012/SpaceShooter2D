using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] GameObject endGame;
    [SerializeField] TextMeshProUGUI finalMessage;

    [Header("Images")]
    [SerializeField] Image background;
    [SerializeField] Sprite victoryImage;
    [SerializeField] Sprite defeatImage;

    [Header("Player reference")]
    [SerializeField] GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDestroyed())
        {
            GameOver();
        }
    }

    public void GameWin()
    {
        if (player != null)
        {
            endGame.SetActive(true);
            finalMessage.SetText("VICTORY");
            background.sprite = victoryImage;
            finalMessage.color = Color.yellow;
        }
    }

    void GameOver()
    {
        if (player == null)
        {
            endGame.SetActive(true);
            finalMessage.SetText("DEFEAT");
            background.sprite = defeatImage;
            finalMessage.color = Color.red;
        }
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
