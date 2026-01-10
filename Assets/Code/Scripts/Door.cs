using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BonusType { Addition, Difference, Product, Division }
public class Door : MonoBehaviour
{


    [Header("Elements")]
    [SerializeField] private SpriteRenderer rightDoorRenderer;
    [SerializeField] private SpriteRenderer leftDoorRenderer;

    [Header("Text components")]
    [SerializeField] private TextMeshPro rightDoorText;
    [SerializeField] private TextMeshPro leftDoorText;

    [Header("Settings")]
    [SerializeField] private BonusType rightDoorBonusType;
    [SerializeField] private int rightDoorBonusAmount;
    
    [SerializeField] private BonusType leftDoorBonusType;
    [SerializeField] private int leftDoorBonusAmount;

    [SerializeField] private Color bonusColor;
    [SerializeField] private Color negativeColor;

    private void Start()
    {
        ConfigureDoor(
            rightDoorRenderer,
            rightDoorText,
            rightDoorBonusType,
            rightDoorBonusAmount
        );

        ConfigureDoor(
            leftDoorRenderer,
            leftDoorText,
            leftDoorBonusType,
            leftDoorBonusAmount
        );
    }
    private void ConfigureDoor(
        SpriteRenderer renderer,
        TextMeshPro text,
        BonusType bonusType,
        int amount
    )
    {
        switch (bonusType)
        {
            case BonusType.Addition:
                renderer.color = bonusColor;
                text.text = "+" + amount;
                break;

            case BonusType.Difference:
                renderer.color = negativeColor;
                text.text = "-" + amount;
                break;

            case BonusType.Product:
                renderer.color = bonusColor;
                text.text = "x" + amount;
                break;

            case BonusType.Division:
                renderer.color = negativeColor;
                text.text = "/" + amount;
                break;
        }
    }

    private void ConfigureDoors() {

        switch (rightDoorBonusType) { 
            case BonusType.Addition:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "+" + rightDoorBonusAmount;
                break; 
            case BonusType.Difference:
                rightDoorRenderer.color = negativeColor;
                rightDoorText.text = "-" + rightDoorBonusAmount;
                break; 
            case BonusType.Product:
                rightDoorRenderer.color = bonusColor;
                rightDoorText.text = "x" + rightDoorBonusAmount;
                break;
            case BonusType.Division:
                rightDoorRenderer.color = negativeColor;
                rightDoorText.text = "/" + rightDoorBonusAmount;
                break;
        }

        switch (leftDoorBonusType)
        {
            case BonusType.Addition:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "+" + leftDoorBonusAmount;
                break;
            case BonusType.Difference:
                leftDoorRenderer.color = negativeColor;
                leftDoorText.text = "-" + leftDoorBonusAmount;
                break;
            case BonusType.Product:
                leftDoorRenderer.color = bonusColor;
                leftDoorText.text = "x" + leftDoorBonusAmount;
                break;
            case BonusType.Division:
                leftDoorRenderer.color = negativeColor;
                leftDoorText.text = "/" + leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float xPosition) {
        if (xPosition > 0) {
            return rightDoorBonusAmount;
        }
        else {
            return leftDoorBonusAmount;
        }
    }

    public BonusType GetBonusType(float xPosition){
        if (xPosition > 0)
        {
            return rightDoorBonusType;
        }
        else
        {
            return leftDoorBonusType;
        }
    }
}
