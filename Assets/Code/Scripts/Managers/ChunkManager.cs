using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    public static ChunkManager Instance { get; private set; }

    [Header("Elements")]
    [SerializeField] private LevelScriptableObject[] levels;
    private GameObject finishLine;
    private int TOTAL_CHUNKS = 5;

    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }


    private void Start() {
        GenerateLevel();
        finishLine = GameObject.FindGameObjectWithTag("Finish");
    }

    private void GenerateLevel() { 
        int currentLevel = GetCurrentLevel();

        currentLevel = currentLevel % levels.Length;

        LevelScriptableObject level = levels[currentLevel];

        CreateLevel(level.chunks);
    }
    
    private void CreateLevel(Chunk[] levelChunks) {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < levelChunks.Length; i++) {

            Chunk chunkToCreate = levelChunks[i];

            if (i > 0) {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2;

        }
    }
    /*
    private void CreateRandomLevel() {
        Vector3 chunkPosition = Vector3.zero;
        for (int i = 0; i < TOTAL_CHUNKS; i++) {

            Chunk chunkToCreate = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

            if (i > 0) {
                chunkPosition.z += chunkToCreate.GetLength() / 2;
            }

            Chunk chunkInstance = Instantiate(chunkToCreate, chunkPosition, Quaternion.identity, transform);
            chunkPosition.z += chunkInstance.GetLength() / 2;

        }
    }
    */
    public float GetFinishLineZ(){
        return finishLine.transform.position.z;
    }

    public int GetCurrentLevel() {
        return PlayerPrefs.GetInt("level", 0);
    }
}
