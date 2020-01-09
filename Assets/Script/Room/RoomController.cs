using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    private bool isSolved = false;
    public List<RoomGate> gates;
    public List<BaseEnemy> enemiesInRoom;
    public UnityEvent onSolved;

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

                    enemy.target = FindObjectOfType<Player>();
                }
            });
        }
    }

    public void Solve()
    {
        if (isSolved) return;

        Debug.Log("Solve Room");

        isSolved = true;
        foreach (RoomGate gate in gates)
        {
            gate.gameObject.SetActive(false);
        }
        if (onSolved != null && onSolved.GetPersistentEventCount() > 0)
            onSolved.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolved) return;

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
