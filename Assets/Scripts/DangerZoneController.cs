using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamController examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
    private Coroutine activeCountdown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnTriggerEnter(Collider other) {
        if(!other.CompareTag("Player")) return;
        examManager.EnterDangerZone();
        activeCountdown = StartCoroutine(MissileCountdown());
    }

    void OnTriggerExit(Collider other) {
        if(!other.CompareTag("Player")) return;
        if(activeCountdown != null){
            StopCoroutine(activeCountdown);
            activeCountdown = null;
            examManager.ExitDangerZone();
        }

    }

}

