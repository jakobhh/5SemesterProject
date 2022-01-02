using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Algorithms
{

 public static HashSet<Vector2Int> RandomWalk (Vector2Int startPosition, int walkLenght) 
 {
     HashSet<Vector2Int> path = new HashSet<Vector2Int>();

     path.Add(startPosition);
     var previousPosition = startPosition;

 
 for (int i = 0; i < walkLenght; i++)
 {
     var newPosition = previousPosition + Directions.GetRandomCardinalDirection();
     path.Add(newPosition);
     previousPosition = newPosition;
 }
 return path;
}

public static List<BoundsInt> BSP(BoundsInt space, int minX, int minY) 
{
    Queue<BoundsInt> roomQueue = new Queue<BoundsInt>();
        List<BoundsInt> roomsList = new List<BoundsInt>();
        roomQueue.Enqueue(space);
        while(roomQueue.Count > 0)
        {
            var room = roomQueue.Dequeue();
            if(room.size.y >= minY && room.size.x >= minX)
            {
                if(room.size.y >= minY * 2)
                {
                    SplitSpaceHorizontally(minY, roomQueue, room);
                }
                else if (room.size.x >= minX * 2)
                {
                    SplitSpaceVertically(minX, roomQueue, room);
                }
                else
                {
                    roomsList.Add(room);
                }
            }
        }
    return roomsList;
}

    private static void SplitSpaceVertically(int minX, Queue<BoundsInt> roomQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z),
        new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
        roomQueue.Enqueue(room1);
        roomQueue.Enqueue(room2);
    }

    private static void SplitSpaceHorizontally(int minY, Queue<BoundsInt> roomQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),
        new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
        roomQueue.Enqueue(room1);
        roomQueue.Enqueue(room2);
    }

    public static class Directions {
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int> {
        new Vector2Int(0, 1),   //Op -      0
        new Vector2Int(1, 0),   //Højre -   1
        new Vector2Int(0, -1),  //Ned -     2
        new Vector2Int(-1, 0)   //Venstre - 3
    };

    public static List<Vector2Int> intercardinalDirectionsDirectionsList = new List<Vector2Int> {
        new Vector2Int(1, 1),   //Nord-Øst
        new Vector2Int(1, -1),   //Nord-Vest
        new Vector2Int(-1, -1),  //Syd-Vest
        new Vector2Int(-1, 1)   //Syd-Øst
    };

    public static Vector2Int GetRandomCardinalDirection(){
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)]; //Kunne have været også have skrevet 3.
    }
}
}
