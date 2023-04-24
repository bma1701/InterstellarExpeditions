using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour
{
public Slider slider;

    public void SetMaxFuel(float fuel)
    {
        slider.maxValue = 200f;
        slider.value = fuel;
    }

    // Start is called before the first frame update
    public void SetFuel(float fuel)
    {
        slider.value = fuel;
    }
}
