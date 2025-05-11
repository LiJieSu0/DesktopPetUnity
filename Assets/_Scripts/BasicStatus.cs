using System.Collections;
using UnityEngine;
public class BasicStatus : IStatus
{
    protected float value;
    protected float maxValue;
    private string statusName;

    public BasicStatus(float value, float maxValue, string statusName)
    {
        this.value = value;
        this.maxValue = maxValue;
        this.statusName = statusName;
    }

    public float GetValue()
    {
        return value;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }

    public void ChangeValue(float value)
    {
        Pet.instance.OnUpdateStatus();
        this.value += value;
        if (this.value > maxValue)
        {
            this.value = maxValue;
        }
        else if (this.value < 0)
        {
            this.value = 0;
        }
    }

    public string GetStatusName()
    {
        return statusName;
        throw new System.NotImplementedException();
    }
    public IEnumerator DecayByTime(float time, float decayRate)
    {
        while(true){
            yield return new WaitForSeconds(time);
            ChangeValue(-decayRate);
        }
    }
}
