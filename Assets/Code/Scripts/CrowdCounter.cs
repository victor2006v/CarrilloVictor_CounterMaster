using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrowdCounter : MonoBehaviour
{
    private TextMeshPro crowdText;
    [SerializeField] private Transform runnersParent;

    private void Start() {
        crowdText = GetComponentInChildren<TextMeshPro>();
    }

    private void Update() {
        crowdText.text = runnersParent.childCount.ToString();
    }
}
