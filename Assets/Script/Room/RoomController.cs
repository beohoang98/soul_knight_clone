using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnPosition
    {
        public float X;
        public float Y;
        public GameObject enemy;
    }

    public List<EnemySpawnPosition> enemySpawns;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
