using System.Collections;
using UnityEngine;

public class StatusManager:MonoBehaviour{

    private Pet currPet;
    private HungerStatus hungerStatus;
    private HealthStatus healthStatus;
    private HappinessStatus happinessStatus;
    private Coroutine hungerCoroutine;
    private Coroutine healthCoroutine;
    private Coroutine happinessCoroutine;

    void Start()
    {
        currPet = Pet.instance;
        InitStatus();
        healthStatus = currPet.GetStatusByName("Health") as HealthStatus;
        hungerStatus = currPet.GetStatusByName("Hunger") as HungerStatus;
        happinessStatus = currPet.GetStatusByName("Happiness") as HappinessStatus;
        hungerCoroutine = StartCoroutine(hungerStatus.DecayByTime(1f, 10f));
    }

    void Update()
    {
        if(hungerStatus.GetValue() <= 50 && happinessCoroutine== null){
            happinessCoroutine=StartCoroutine(happinessStatus.DecayByTime(1f, 1f));
        }
        if(hungerStatus.GetValue() <= 0 && healthCoroutine== null){
            healthCoroutine=StartCoroutine(healthStatus.DecayByTime(1f, 1f));
        }
        if(hungerStatus.GetValue() > 50 && happinessCoroutine!= null){
            StopCoroutine(happinessCoroutine);
            happinessCoroutine=null;
        }
        if(hungerStatus.GetValue() > 0 && healthCoroutine!= null){
            StopCoroutine(healthCoroutine);
            healthCoroutine=null;
        }

    }
    void InitStatus(){
        currPet.statusList.Add(new HealthStatus(100, 100));
        currPet.statusList.Add(new HungerStatus(100, 100));
        currPet.statusList.Add(new HappinessStatus(100, 100));
    }
    
}