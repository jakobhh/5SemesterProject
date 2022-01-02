using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BSPGenerator : RandomWalkGenerator
{
[SerializeField] private int minRoomX;
[SerializeField] private int minRoomY;
[SerializeField] private int dungeonSizeX;
[SerializeField] private int dungeonSizeY;
[SerializeField] [Range (0,10)] private int offset = 1;

void Start() 
{
    RunProceduralGeneration();
}
protected override void RunProceduralGeneration()
{
    CreateRooms();
}

    private void CreateRooms()
    {
        var roomList = Algorithms.BSP(new BoundsInt((Vector3Int)startPos, new Vector3Int(dungeonSizeX, dungeonSizeY, 0)), minRoomX, minRoomY);

        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        floor = CreateRoom(roomList);

        List<Vector2Int> roomCenter = new List<Vector2Int>();
        foreach (var room in roomList)
        {
            roomCenter.Add((Vector2Int)Vector3Int.RoundToInt(room.center));
        }

        HashSet<Vector2Int> corridors = ConnectRooms(roomCenter);
        floor.UnionWith(corridors);

        tilemapGenerator.drawFloorTiles(floor);
        WallGenerator.CreateWalls(floor, tilemapGenerator);
    }

    private HashSet<Vector2Int> ConnectRooms(List<Vector2Int> roomCenter)
    {
        HashSet<Vector2Int> corridors = new HashSet<Vector2Int>();
        var curRoomCenter = roomCenter[Random.Range(0, roomCenter.Count)];
        roomCenter.Remove(curRoomCenter);

        while(roomCenter.Count > 0)
        {
            Vector2Int closest = FindClosestPoint(curRoomCenter, roomCenter);
            roomCenter.Remove(closest);
            HashSet<Vector2Int> newCorridor = CreateCorridor(curRoomCenter, closest);
            curRoomCenter = closest;
            corridors.UnionWith(newCorridor);
        }
        return corridors;
    }

    private HashSet<Vector2Int> CreateCorridor(Vector2Int curRoomCenter, Vector2Int destination)
    {
        HashSet<Vector2Int> corridor = new HashSet<Vector2Int>();
        var pos = curRoomCenter;
        corridor.Add(pos);
        while (pos.y != destination.y)
        {
            if(destination.y > pos.y)
            {
                pos += Vector2Int.up;
            }
            else if(destination.y < pos.y)
            {
                pos += Vector2Int.down;
            }
            corridor.Add(pos);
        }
        while (pos.x != destination.x)
        {
            if (destination.x > pos.x)
            {
                pos += Vector2Int.right;
            }else if(destination.x < pos.x)
            {
                pos += Vector2Int.left;
            }
            corridor.Add(pos);
        }
        return corridor;
    }

    private Vector2Int FindClosestPoint(Vector2Int curRoomCenter, List<Vector2Int> roomCenter)
    {
        Vector2Int closest = Vector2Int.zero;
        float distance = float.MaxValue;
        foreach (var pos in roomCenter)
        {
            float curDis = Vector2.Distance(pos, curRoomCenter);
            if (curDis < distance)
            {
                distance = curDis;
                closest = pos;
            }
        }
        return closest;
    }

    /*private HashSet<Vector2Int> CreateRoom(List<BoundsInt> roomList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        foreach (var room in roomList)
        {
            for (int iX = offset; iX < room.size.x - offset; iX++)
            {
                for (int iY = offset; iY < room.size.y; iY++)
                {
                    Vector2Int pos = (Vector2Int)room.min + new Vector2Int(iX, iY);
                    floor.Add(pos);
                }
            }
            
        }
        return floor;   
    }*/
    private HashSet<Vector2Int> CreateRoom(List<BoundsInt> roomList)
    {
        HashSet<Vector2Int> floor = new HashSet<Vector2Int>();
        for (int i = 0; i < roomList.Count; i++)
        {
            var roomBounds = roomList[i];
            var roomCenter = new Vector2Int(Mathf.RoundToInt(roomBounds.center.x), Mathf.RoundToInt(roomBounds.center.y));
            var roomFloor = RunRandomWalk(roomCenter);
            foreach (var pos in roomFloor)
            {
                if(pos.x >= (roomBounds.xMin + offset) && pos.x <= (roomBounds.xMax - offset) && pos.y >= (roomBounds.yMin - offset) && pos.y <= (roomBounds.yMax - offset))
                {
                    floor.Add(pos);
                    RandomWalkGenerator.drawnTilesList.Add(pos);
                }
            }
        }
        return floor;
    }
}
