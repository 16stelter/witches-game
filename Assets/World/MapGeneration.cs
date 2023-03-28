using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class MapGeneration : MonoBehaviour
{
    int min_rooms = 10;
    int max_rooms = 20;

    public GameObject roomObject;

    List<Vector2Int> untested;
    List<Vector2Int> rooms;
    System.Random rnd;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("generating level...");
        untested = new List<Vector2Int> {new Vector2Int(0, 0)};
        rooms = new List<Vector2Int> {new Vector2Int(0, 0)};
        rnd = new System.Random();
        while(untested.Any()) {
            CreateRoomNeighbours(untested[0][0], untested[0][1]);
            untested.RemoveAt(0);
        }
        SpawnRooms();
        Debug.Log(rooms.Count);
    }

    void CreateRoomNeighbours(int x, int y)
    {
        foreach (int i in Enumerable.Range(0, 4))
        {
            if (rooms.Count() < max_rooms && rnd.Next(4) > 2)
            { //todo: check if room already exists
                if(i == 0 && !rooms.Contains(new Vector2Int(x+20, y))) 
                {
                    untested.Add(new Vector2Int(x+21, y));
                    rooms.Add(new Vector2Int(x+21, y));
                }
                else if(i == 1 && !rooms.Contains(new Vector2Int(x, y+10)))
                {
                    untested.Add(new Vector2Int(x, y+10));
                    rooms.Add(new Vector2Int(x, y+10));

                }
                else if(i == 2 && !rooms.Contains(new Vector2Int(x-20, y))) {
                    untested.Add(new Vector2Int(x-21, y));
                    rooms.Add(new Vector2Int(x-21, y));

                }
                else if(i == 3 && !rooms.Contains(new Vector2Int(x, y-10)))
                {
                    untested.Add(new Vector2Int(x, y-10));
                    rooms.Add(new Vector2Int(x, y-10));
                }
            }
            if (rooms.Count() < min_rooms && untested.Count == 1 && i == 3)
            {
                untested.Add(new Vector2Int(x, y));
            }
        }
    }

    void SpawnRooms()
    {
        foreach (Vector2Int r in rooms)
        {
            Vector3 pos = new Vector3(r[0], r[1], 0);
            Quaternion rot = new Quaternion();
            Instantiate(roomObject, pos, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //nothing for now...
    }
}
