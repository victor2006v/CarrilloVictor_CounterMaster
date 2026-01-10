using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
    [Header("Prefab Runner")]
    [SerializeField] private GameObject runnerPrefab;

    [Header("Settings")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    [Header("Runners parent")]
    [SerializeField] private Transform runnersParent;

    // Start is called before the first frame update
    void Start()
    {
        PlaceCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < runnersParent.childCount; i++) {
            Vector3 childPosition = GetCharacterLocalPosition(i);
            runnersParent.GetChild(i).localPosition = childPosition;
        }
    }

    private void PlaceCharacters(){ 
    
    }

    private Vector3 GetCharacterLocalPosition(int index) { 
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0 , z);
    }

    public float GetCrowdRadius() { return radius * Mathf.Sqrt(runnersParent.childCount); }

    public void ApplyBonus(BonusType bonusType, int bonusAmount) { 
        switch (bonusType)
        {
            case BonusType.Addition:
                AddRunners(bonusAmount);
                break;
            case BonusType.Product:
                int runnersToAdd = (runnersParent.childCount * bonusAmount) - runnersParent.childCount;
                AddRunners(runnersToAdd);
                break;
            case BonusType.Difference:
                RemoveRunners(bonusAmount);
                break;
            case BonusType.Division:
                int runnersToRemove = runnersParent.childCount - (runnersParent.childCount / bonusAmount); 
                RemoveRunners(runnersToRemove);
                break;
        }
    }
    

    private void AddRunners(int bonusAmount) { 
        for(int i = 0; i < bonusAmount; i++)
        {
            Instantiate(runnerPrefab, runnersParent);
        }
    }

    private void RemoveRunners(int amount) {
        if (amount > runnersParent.childCount) { 
            amount = runnersParent.childCount;
        }
        int runnersAmount = runnersParent.childCount;
        for (int i = runnersAmount - 1; i >= runnersAmount - amount; i--) { 
            Transform runnersToDestroy = runnersParent.GetChild(i);
            runnersToDestroy.SetParent(null);
            Destroy(runnersToDestroy.gameObject);
        }
    }
}
