using UnityEngine;

public class PlayerDetection : MonoBehaviour{

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player")) {
            Door door = GetComponentInParent<Door>();

            if (door != null) {
                hasTriggered = true;

                CrowdSystem crowdSystem = other.GetComponentInParent<CrowdSystem>();

                if (crowdSystem != null) {
                    int bonusAmount = door.GetBonusAmount(other.transform.position.x);
                    BonusType bonusType = door.GetBonusType(other.transform.position.x);
                    crowdSystem.ApplyBonus(bonusType, bonusAmount);
                } else {
                    Debug.LogError("CrowdSystem not found! Make sure the Player or its parent has CrowdSystem component.");
                }
            }
        }
    }
}
