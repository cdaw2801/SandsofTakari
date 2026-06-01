using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class WaterBarScript : MonoBehaviour
{
    public Slider waterLevel;
    
    public void SetMaxWaterLevel(float health)
    {
        waterLevel.maxValue = health;
        waterLevel.value = health;
    }
    public void SetWaterLevel(float health)
    {
        waterLevel.value = health;
    }
}
