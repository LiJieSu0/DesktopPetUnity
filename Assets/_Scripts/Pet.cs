using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public delegate void StatusUpdate();
    public event StatusUpdate OnStatusUpdate;
    public static Pet instance;
    public bool isMouseInside = false;
    public List<IStatus> statusList = new List<IStatus>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
    void OnMouseEnter()
    {
        isMouseInside=true;
    }
    void OnMouseExit()
    {
        isMouseInside=false;
    }

    public void OnUpdateStatus()
    {
        foreach (IStatus status in statusList)
        {
            Debug.Log(status.GetStatusName() + ": " + status.GetValue() + "/" + status.GetMaxValue());
        }
        OnStatusUpdate?.Invoke();
    }

    public IStatus GetStatusByName(string statusName)
    {
        foreach (IStatus status in statusList)
        {
            if (status.GetStatusName() == statusName)
            {
                return status;
            }
        }
        throw new System.Exception("Status not found");
    }
}
