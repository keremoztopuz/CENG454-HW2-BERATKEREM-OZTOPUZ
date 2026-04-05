using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    //[SerializeField] private float turnSpeed = 100f;
    private Transform target;
    
    [SerializeField] private FlightExamController examManager;

    public void SetTarget(Transform newTarget) {
        Debug.Log("Target set: " + newTarget.name);
        target = newTarget;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Trigger entered by" + other.name);
        if (other.CompareTag("DangerZone")) return; 
        if (!other.CompareTag("Player")) return;
        examManager.OnMissileHit();
        Destroy(gameObject);
    }

    void Update()
    {
        if (!target) return;
        Vector3 direction = (target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position += direction * moveSpeed * Time.deltaTime; 
    }
}
