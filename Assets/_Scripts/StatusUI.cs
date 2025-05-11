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
        if(this.transform.childCount==Pet.instance.statusList.Count)
            return; // Already generated
        foreach (IStatus status in Pet.instance.statusList)
        {
            TextMeshProUGUI newText = Instantiate(statusText, this.transform);
            newText.text = status.GetStatusName() + ": " + status.GetValue() + "/" + status.GetMaxValue() + "\n";
        }
    }
    public void UpdateStatusText(){
        Debug.Log("Count "+Pet.instance.statusList.Count);
        if(this.transform.childCount!=Pet.instance.statusList.Count){
            GenerateStatusText();
        }
        for(int i=0;i<Pet.instance.statusList.Count;i++){
            TextMeshProUGUI text = this.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            text.text = Pet.instance.statusList[i].GetStatusName() + ": " + Pet.instance.statusList[i].GetValue() + "/" + Pet.instance.statusList[i].GetMaxValue() + "\n";
        }   
    }
}
