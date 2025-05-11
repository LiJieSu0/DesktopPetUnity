using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText;

    void Start()
    {
        Pet.instance.OnStatusUpdate += UpdateStatusText;
        GenerateStatusText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateStatusText()
    {
        foreach (IStatus status in Pet.instance.statusList)
        {
            TextMeshProUGUI newText = Instantiate(statusText, this.transform);
            newText.text = status.GetStatusName() + ": " + status.GetValue() + "/" + status.GetMaxValue() + "\n";
        }
    }
    public void UpdateStatusText(){
        for(int i=0;i<Pet.instance.statusList.Count;i++){
            TextMeshProUGUI text = this.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            text.text = Pet.instance.statusList[i].GetStatusName() + ": " + Pet.instance.statusList[i].GetValue() + "/" + Pet.instance.statusList[i].GetMaxValue() + "\n";
        }
    }
}
