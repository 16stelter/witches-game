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
    public GameObject wallObject;

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
        Debug.Log(rooms);
        SpawnRooms();
        Debug.Log(rooms.Count);
    }

    void CreateRoomNeighbours(int x, int y)
    {
        foreach (int i in Enumerable.Range(0, 4))
        {
            if (rooms.Count() < max_rooms)
            { 
                if(i == 0  && !rooms.Contains(new Vector2Int(x+20, y)))
                {
                    if(rnd.Next(4) > 2) 
                    {
                        untested.Add(new Vector2Int(x+20, y));
                        rooms.Add(new Vector2Int(x+20, y));
                    }
                    else
                    {
                        Instantiate(wallObject, new Vector3(x+10, y, 0), new Quaternion());
                    }
                }
                else if(i == 1 && !rooms.Contains(new Vector2Int(x, y+9)))
                {
                    if(rnd.Next(4) > 2)
                    {
                        untested.Add(new Vector2Int(x, y+9));
                        rooms.Add(new Vector2Int(x, y+9));
                    }
                    else
                    {
                        Instantiate(wallObject, new Vector3(x, y+4, 0), new Quaternion(0.7076f, 0.7076f, 0.0f, 0.0f));
                    }
                }
                else if(i == 2 && !rooms.Contains(new Vector2Int(x-20, y))) 
                {
                    if(rnd.Next(4) > 2)
                    {
                        untested.Add(new Vector2Int(x-20, y));
                        rooms.Add(new Vector2Int(x-20, y));
                    }
                    else
                    {
                        Instantiate(wallObject, new Vector3(x-10, y, 0), new Quaternion());
                    }
                }
                else if(i == 3 && !rooms.Contains(new Vector2Int(x, y-9)))
                {
                    if(rnd.Next(4) > 2 || rooms.Count < min_rooms)
                    {
                        untested.Add(new Vector2Int(x, y-9));
                        rooms.Add(new Vector2Int(x, y-9));
                    }
                    else
                    {
                        Instantiate(wallObject, new Vector3(x, y-5, 0), new Quaternion(0.7076f, 0.7076f, 0.0f, 0.0f));
                    }
                }
            }
            else
            {
                if(!rooms.Contains(new Vector2Int(x+20, y)))
                {
                    Instantiate(wallObject, new Vector3(x+10, y, 0), new Quaternion());
                }
                if(!rooms.Contains(new Vector2Int(x-20, y)))
                {
                    Instantiate(wallObject, new Vector3(x-10, y, 0), new Quaternion());
                }
                if(!rooms.Contains(new Vector2Int(x, y+9)))
                {
                    Instantiate(wallObject, new Vector3(x, y+4, 0), new Quaternion(0.7076f, 0.7076f, 0.0f, 0.0f));
                }
                if(!rooms.Contains(new Vector2Int(x, y-9)))
                {
                    Instantiate(wallObject, new Vector3(x, y-5, 0), new Quaternion(0.7076f, 0.7076f, 0.0f, 0.0f));
                }
            }
        }
    }

    void SpawnRooms()
    {
        bool first = true;
        foreach (Vector2Int r in rooms)
        {
            Vector3 pos = new Vector3(r[0], r[1], 0);
            Quaternion rot = new Quaternion();
            GameObject instance = Instantiate(roomObject, pos, rot);
            if(first)
            {
                instance.GetComponent<RoomLogic>().isCleared = true;
                first = false;
            }
            else
            {
                instance.GetComponent<RoomLogic>().isCleared = false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //nothing for now...
    }
}
