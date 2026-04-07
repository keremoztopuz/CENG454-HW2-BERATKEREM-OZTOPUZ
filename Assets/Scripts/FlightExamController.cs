using UnityEngine;
using TMPro;

public class FlightExamController : MonoBehaviour
{
    [SerializeField] private Transform aircraft;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private AudioSource dangerZoneAudio;
    [SerializeField] private AudioSource safeAudio;
    [SerializeField] private AudioSource missionAudio;

    private bool hasTakenOff;
    private bool inDangerZone;
    private bool threatCleaned;
    private bool missionCompleted;

    private Vector3 beginningPosition;
    private Quaternion beginningRotation;

    void Start()
    {
        beginningPosition = aircraft.position;
        beginningRotation = aircraft.rotation;
        updateHUD();
    }

    private void updateHUD() {
        if (missionCompleted) {
            statusText.text = "Mission Completed.";
        } else if (inDangerZone) {
            statusText.text = "DANGER ZONE";
        } else if (hasTakenOff) {
            statusText.text = "In Flight";
        } else {
            statusText.text = "On Ground.";
        }
    }

    public void OnTakeoff() {
        hasTakenOff = true;
        updateHUD();
    }

    public void EnterDangerZone() {
        inDangerZone = true;
        missionText.text = "ENTERED DANGER ZONE! LEAVE IMMEDIATELY!";
        missionText.color = Color.red;
        dangerZoneAudio.Play();
        updateHUD();
    }

    public void ExitDangerZone() {
        inDangerZone = false;
        threatCleaned = true;
        missionText.text = "The danger zone has been left. Stay on the safe zone.";
        dangerZoneAudio.Stop();
        safeAudio.Play();
        updateHUD();
    }

    public void OnMissileHit() {
        hasTakenOff = false;
        threatCleaned = false;
        inDangerZone = false;
        missionText.text = "Missile Hit! Mission Failed. Press M to try again.";
        missionText.color = Color.red;
        updateHUD();
    }

    public void OnLanded() {
        if (hasTakenOff && threatCleaned) {
            missionCompleted = true;
            missionText.text = "Congratulations soldier. You can return home now.";
            missionAudio.Play();
            updateHUD();
        }
    }

    public void ResetMission() {
        hasTakenOff = false;
        inDangerZone = false;
        threatCleaned = false;
        missionCompleted = false;
        missionText.text = "";
        missionText.color = Color.white;
        updateHUD();

        aircraft.position = beginningPosition;
        aircraft.rotation = beginningRotation;
    }

}
