using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Gradient healthGradient;
    public Image border;
    public Image fill;

    float showHealthPercentage = 75f;
    float visibleTime = 3f;
    bool visible = false;

    private float maxHealth, currentHealth;
    
    private void Awake()
    {
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 0);
    }

    private void Start()
    {
        ShowHealthBar();
    }

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;

        Color fillColor = healthGradient.Evaluate(health);

        fill.color = new Color(fillColor.r, fillColor.g, fillColor.b, fill.color.a);
    }

    public void SetHealth(float health)
    {
        fill.fillAmount = health / maxHealth;

        Color fillColor = healthGradient.Evaluate(fill.fillAmount);
        fill.color = fillColor;
    }

    void ShowHealthBar()
    {
        StartCoroutine(FadeImage(border, 0.5f, true));
        StartCoroutine(FadeImage(fill, 0.5f, true));
    }

    IEnumerator FadeImage(Image image, float time, bool fadeIn)
    {
        Color imageColor = image.color;

        if (fadeIn)
        {
            for (float i = 1 - time; i <= 1; i += Time.deltaTime)
            {
                imageColor.a = i;
                image.color = imageColor;
                yield return null;
            }
            visible = true;
        }
        else
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                imageColor.a = i;
                image.color = imageColor;
                yield return null;
            }
            visible = false;
        }

        yield break;
    }

}
