using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Chunk [] chunkPrefabs;
    private int TOTAL_CHUNKS = 5;

    private void Start() {
        
    }

    private void CreateOrderedLevel() { 
    
    }

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
}
