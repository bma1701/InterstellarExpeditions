using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    public FloatSO currentHealth;
    private void Start()
    {
        slider.maxValue = 100f;
        slider.value = currentHealth.Value;
    }

    private void Update()
    {
        slider.value = currentHealth.Value;
    }

}
