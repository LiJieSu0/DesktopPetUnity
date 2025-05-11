public class HappinessStatus : BasicStatus
{
    private string statusName = "Happiness";

    public HappinessStatus(float value, float maxValue) : base(value, maxValue, "Happiness")
    {
        this.value = value;
        this.maxValue = maxValue;
    }
}