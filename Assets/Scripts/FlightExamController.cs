using UnityEngine;
using TMPro;

public class FlightExamController : MonoBehaviour
{

    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private bool hasTakenOff;
    [SerializeField] private bool inDangerZone;
    [SerializeField] private bool threatCleaned;
    [SerializeField] private bool missionCompleted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
