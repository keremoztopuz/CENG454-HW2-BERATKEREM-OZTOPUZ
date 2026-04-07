using UnityEngine;
using System.Collections.Generic;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioClip launchAudio;

    private List<GameObject> activeMissiles = new List<GameObject>();

public void Launch(Transform target)
{
    Debug.Log("Launch called!");
    Debug.Log("missilePrefab: " + missilePrefab);
    Debug.Log("launchPoint: " + launchPoint);
    
    GameObject spawnedMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
    activeMissiles.Add(spawnedMissile);
    MissileHoming homing = spawnedMissile.GetComponent<MissileHoming>();

    if(homing != null){
        homing.SetTarget(target);
        }

    if (launchAudio != null){
        AudioSource.PlayClipAtPoint(launchAudio, Camera.main.transform.position, 0.5f);
        }
    }

public void DestroyActiveMissile()
{
    foreach(GameObject missile in activeMissiles){
        Destroy(missile);
    }
    activeMissiles.Clear();
    }

}

