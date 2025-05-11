using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    Button btn1;
    Button btn2;
    Image img;
    void Start()
    {
        btn1=GameObject.Find("Btn1").GetComponent<Button>();
        btn2 = GameObject.Find("Btn2").GetComponent<Button>();
        img=GetComponent<Image>();
        btn1.onClick.AddListener(() => { Pet.instance.statusList[1].ChangeValue(50); });
        btn2.onClick.AddListener(() => { img.color = Color.blue; });
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMenuActive()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }   
}
