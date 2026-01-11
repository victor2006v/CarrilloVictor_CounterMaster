using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDetection : MonoBehaviour{

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (this.gameObject.CompareTag("Door") && !hasTriggered) {
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
        if (this.gameObject.CompareTag("Finish") && !hasTriggered) {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
            SceneManager.LoadScene(0);
            hasTriggered = true;
        }

    }
}
