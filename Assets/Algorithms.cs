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

public static class Directions {
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int> {
        new Vector2Int(0, 1),   //Op -      0
        new Vector2Int(1, 0),   //Højre -   1
        new Vector2Int(0, -1),  //Ned -     2
        new Vector2Int(-1, 0)   //Venstre - 3
    };

    public static Vector2Int GetRandomCardinalDirection(){
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)]; //Kunne have været også have skrevet 3.
    }
}
}
