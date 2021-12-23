using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapGeneration : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]    
    private TileBase floorTile, wallTile;
    public void drawFloorTiles(IEnumerable<Vector2Int>  floorPos) {
        drawTiles(floorPos, floorTilemap, floorTile);
    }

    internal void DrawWallTiles(Vector2Int pos)
    {
        DrawSingleTile(wallTilemap, wallTile, pos);

    }

    private void drawTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile){
        foreach (var pos in positions)
        {
            DrawSingleTile(tilemap, tile, pos);
        }
    }
    private void DrawSingleTile(Tilemap tilemap, TileBase tile, Vector2Int pos)
    {
       var tilePos = tilemap.WorldToCell((Vector3Int)pos);
       tilemap.SetTile(tilePos, tile);
    }

    public void Clear() {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
