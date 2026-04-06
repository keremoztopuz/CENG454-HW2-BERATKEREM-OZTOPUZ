using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    private AudioSource launchAudio;

    private GameObject activeMissile;

public void Launch(Transform target)
{
    Debug.Log("Launch called!");
    Debug.Log("missilePrefab: " + missilePrefab);
    Debug.Log("launchPoint: " + launchPoint);
    
    GameObject spawnedMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
    activeMissile = spawnedMissile;
    MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

    if(homing != null){
        homing.SetTarget(target);
        }

    launchAudio?.Play();
    }

public void DestroyActiveMissile()
{
    if(activeMissile != null){
        Destroy(activeMissile);
        activeMissile = null;
        }
    }

}

