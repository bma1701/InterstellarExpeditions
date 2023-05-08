using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
    public Slider slider;
    public FloatSO currentFuel;

    private void Start()
    {
        slider.maxValue = 200f;
        slider.value = currentFuel.Value;
    }

    private void Update()
    {
        slider.value = currentFuel.Value;
    }

}
