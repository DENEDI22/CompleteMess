using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient healthGradient;
    public Image border;
    public Image fill;

    float showHealthPercentage = 75f;
    float visibleTime = 3f;
    bool visible = false;

    private void Awake()
    {
        border.color = new Color(border.color.r, border.color.g, border.color.b, 0);
        fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 0);
    }

    private void Start()
    {
        StartCoroutine(ShowHealthBarForTime(visibleTime));
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        Color fillColor = healthGradient.Evaluate(health);

        fill.color = new Color(fillColor.r, fillColor.g, fillColor.b, fill.color.a);
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        Color fillColor = healthGradient.Evaluate(slider.normalizedValue);
        fill.color = new Color(fillColor.r, fillColor.g, fillColor.b, fill.color.a);

        if (!visible)
        {
            if (slider.normalizedValue <= showHealthPercentage / 100f)
            {
                ShowHealthBar();
            }
            else
            {
                StartCoroutine(ShowHealthBarForTime(visibleTime));
            }
        }
    }

    void ShowHealthBar()
    {
        StartCoroutine(FadeImage(border, 0.5f, true));
        StartCoroutine(FadeImage(fill, 0.5f, true));
    }

    void HideHealthBar()
    {
        StartCoroutine(FadeImage(border, 1f, false));
        StartCoroutine(FadeImage(fill, 1f, false));
    }

    IEnumerator ShowHealthBarForTime(float time)
    {
        ShowHealthBar();
        yield return new WaitForSeconds(time);
        HideHealthBar();
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
