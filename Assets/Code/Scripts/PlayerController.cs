using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [Header("Elements")]
    [SerializeField] private CrowdSystem crowdSystem;
    

    [Header("Player Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool canMove;

    [Header("Control")]
    [SerializeField] private float slideSpeed;

    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private float ROAD_WIDTH = 9.5f;

    private AnimatorController animatorController;

    private void Awake() {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {
        animatorController = GetComponent<AnimatorController>();
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy() {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void StartMoving() {
        canMove = true;
        animatorController.Run();
    }

    private void StopMoving() { 
        canMove= false;
        animatorController.Idle();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState) {
        if (gameState == GameManager.GameState.GAME) {
            StartMoving();
        }
    }

    private void Update() {
        if (canMove) {
            MoveForward();
            ManageControl();
        }
    }
    private void MoveForward() {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl() {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if(Input.GetMouseButton(0)){ 
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -ROAD_WIDTH / 2 + crowdSystem.GetCrowdRadius(),
                ROAD_WIDTH / 2 - crowdSystem.GetCrowdRadius());

            transform.position = position;
        }
    }
}
