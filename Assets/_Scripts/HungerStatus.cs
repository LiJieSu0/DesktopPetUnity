using System.Collections;
using UnityEngine;
public class HungerStatus : BasicStatus
{

    private string statusName = "Hunger";

    public HungerStatus(float value, float maxValue) : base(value, maxValue, "Hunger")
    {
        this.value = value;
        this.maxValue = maxValue;
    }

}