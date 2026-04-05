using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// MARK: Start and Update deleted because they are no needed.
public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamController examManager;
    [SerializeField] private List<MissileLauncher> missileLaunchers;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private Transform aircraftTransform;
    private Coroutine activeCountdown;

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
            foreach (MissileLauncher ml in missileLaunchers) ml.DestroyActiveMissile();
        }
    }

    private IEnumerator MissileCountdown(){
        while(true){
            yield return new WaitForSeconds(missileDelay);
            foreach (MissileLauncher ml in missileLaunchers) ml.Launch(aircraftTransform);
            Debug.Log("Missile launched!");
        }
    }
}
