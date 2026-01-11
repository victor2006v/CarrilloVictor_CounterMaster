using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 0)]
public class LevelScriptableObject : ScriptableObject {
    public Chunk[] chunks;
}
