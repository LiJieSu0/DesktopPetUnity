public class HealthStatus : BasicStatus
{
    private string statusName = "Health";

    public HealthStatus(float value, float maxValue) : base(value, maxValue, "Health")
    {
        this.value = value;
        this.maxValue = maxValue;
    }
    
}