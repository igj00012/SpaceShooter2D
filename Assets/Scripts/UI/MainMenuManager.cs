using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AudioClip clip;

    void Start()
    {

    }

    public void StartButton()
    {
        AudioManager.instance.PlaySFX(clip);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        AudioManager.instance.PlaySFX(clip);

        Application.Quit();
    }
}
