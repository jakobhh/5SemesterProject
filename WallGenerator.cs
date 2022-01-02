using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Algorithms;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPos,  TileMapGeneration tilemapGeneration)
    {
        var wallPos = findWallsInDirections(floorPos, Directions.cardinalDirectionsList);
        foreach (var pos in wallPos)
        {
            tilemapGeneration.DrawWallTiles(pos);
        }
    }

    private static HashSet<Vector2Int> findWallsInDirections(HashSet<Vector2Int> floorPos, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPos = new HashSet<Vector2Int>();
        foreach (var pos in floorPos)
        {
            foreach (var direction in directionList)
            {
                var neighbourPos = pos + direction;
                if (!floorPos.Contains(neighbourPos))
                {
                    wallPos.Add(neighbourPos);
                }
            }
        }
        return wallPos;
    }
}
