using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class RoomController : MonoBehaviour
{
    public List<RoomGate> gates;
    public List<BaseEnemy> enemiesInRoom;

    // Use this for initialization
    void Start()
    {
        foreach (RoomGate gate in gates) {
            gate.onEnter(() => {
                gate.gameObject.SetActive(false);
                foreach (BaseEnemy enemy in enemiesInRoom)
                {
                    AIDestinationSetter setter = enemy.GetComponent<AIDestinationSetter>();
                    if (setter != null)
                    {
                        setter.target = GameObject.Find("Player")?.transform;
                    }
                }
            });
        }
    }

    public void Solve()
    {
        Debug.Log("Solve Room");
        foreach (RoomGate gate in gates)
        {
            gate.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gates.Count > 0)
        {
            List<RoomGate> gatesFiltered = new List<RoomGate>(); 
            foreach (RoomGate gate in gates)
            {
                if (gate.gameObject.active)
                {
                    gatesFiltered.Add(gate);
                }
            }
            gates = gatesFiltered;
        }

        List<BaseEnemy> enemiesFilterd = new List<BaseEnemy>();
        for (int i = 0; i < enemiesInRoom.Count; ++i)
        {
            if (enemiesInRoom[i] != null && enemiesInRoom[i].gameObject != null)
            {
                enemiesFilterd.Add(enemiesInRoom[i]);
            }
        }
        enemiesInRoom = enemiesFilterd;

        if (enemiesInRoom.Count == 0)
        {
            this.Solve();
        }
    }
}
