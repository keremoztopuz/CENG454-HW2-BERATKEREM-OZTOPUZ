using UnityEngine;
using TMPro;

public class FlightExamController : MonoBehaviour
{

    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    private bool hasTakenOff;
    private bool inDangerZone;
    private bool threatCleaned;
    private bool missionCompleted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateHUD();
    }

    private void updateHUD() {
        if (missionCompleted) {
            statusText.text = "Mission Completed."
        } else if {inDangerZone} {
            statusText.text = "DANGER ZONE"
        } else if (hasTakenOff) {
            statusText.text = "In Flight"
        } else {
            statusText.text = "On Ground."
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
        updateHUD();
    }

    public void ExitDangerZone() {
        inDangerZone = false;
        threatCleaned = true;
        missionText.text = "The danger zone has been left. Stay on the safe zone.";
        updateHUD();
    }

    public void OnMissileHit() {
        hasTakenOff = false;
        threatCleaned = false;
        inDangerZone = false;
        missionText.text = "Missile Hit!"
        missionText.color = Color.red;
        updateHUD();
    }

    public void OnLanded() {
        if (hasTakenOff && threatCleaned) {
            missionCompleted = true;
            missionText.text = "Congratulations soldier. You can return home now.";
            updateHUD();
        }
    }

    void Update()
    {
        
    }
}
