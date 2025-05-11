using System.Collections;

public interface IStatus{
    public string GetStatusName();
    public float GetValue();
    public float GetMaxValue();
    public void ChangeValue(float value);
    public IEnumerator DecayByTime(float time,float decayRate);
}