using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamController examManager;
    
    void OnTriggerEnter(Collider other) 
    {
        if (!other.CompareTag("Player")) return;
        examManager.OnLanded();
    }
}
