using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSystem : MonoBehaviour
{
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
}
