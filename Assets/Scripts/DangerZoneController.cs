using UnityEngine;
using System.Collections;

// MARK: Start and Update deleted because they are no needed.
public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamController examManager;
    //[SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
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
        }
    }

    private IEnumerator MissileCountdown(){
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("Missile launched!");
    }
}
