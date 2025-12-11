using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [Header("Hearts")]
    [SerializeField] Image[] hearts;

    [Header("Heart images")]
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] AudioClip hit;

    private float maxHealth = 10;

    public void UpdateHP(float currentHP)
    {
        float newHealth = maxHealth / hearts.Length;

        for (int i = hearts.Length - 1; i >= 0; --i)
        {
            float treshold = newHealth * (i + 1);

            if (currentHP >= treshold)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;

                AudioManager.instance.PlaySFX(hit);
            }
        }
    }

    public float GetMaxHealth() { return maxHealth; }
}
