using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudio;

    private GameObject activeMissile;

public void Launch(Transform target){
    GameObject spawnedMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
    activeMissile = spawnedMissile;
    MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

    if(homing != null){
        homing.SetTarget(target);
        }

    if (launchAudio != null) {
        launchAudio.Play();
        }
    }

public void DestroyActiveMissile(){
    if(activeMissile != null){
        Destroy(activeMissile);
        activeMissile = null;
        }
    }

}

