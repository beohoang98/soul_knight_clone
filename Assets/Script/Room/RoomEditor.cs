using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomController))]
public class RoomEditor : Editor
{
    RoomController controller;

    void Awake()
    {
        controller = (RoomController)target;
    }

    private void OnSceneGUI()
    {
        if (controller.enemySpawns != null)
        {
            foreach (RoomController.EnemySpawnPosition enemySpawn in controller.enemySpawns)
            {
                GameObject enemy = enemySpawn.enemy;
                enemy.transform.position = new Vector2(enemySpawn.X, enemySpawn.Y);
                //GameObject enemyObject = (GameObject)PrefabUtility.InstantiatePrefab(enemy);
            }
        }
    }
}