using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image HP;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)

    {
        slider.value = health;
        SetColor(health);
    }

    public void SetColor(int health)
    {
        float healthPercentage = (float)health / slider.maxValue;
        if (healthPercentage <= 0.5f)
        {
            HP.color = Color.yellow;
        }

    }
}
