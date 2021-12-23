using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : MonoBehaviour
{
    [SerializeField] //så vi kan ændre det i inspektoren
    protected Vector2Int startPos = Vector2Int.zero;
    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLenght = 15;
    //[SerializeField]
    //public bool StartEachInterationRandom = true; //Vi bruger nok ikke dette så kan fjernes
    [SerializeField]
    private TileMapGeneration tilemapGenerator;
    public GameObject enemyTemplate; 

    private HashSet<Vector2Int> drawnTilesList = new HashSet<Vector2Int>();


    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPos = RunRandomWalk();
        tilemapGenerator.Clear();
        tilemapGenerator.drawFloorTiles(floorPos);
        WallGenerator.CreateWalls(floorPos, tilemapGenerator);
        drawnTilesList.Clear(); //SKAL MÅSKE FJERENES SENRE ALT EFTER HVORDAN GENERATION MED FLERE RUM VIRKER
        foreach (var position in floorPos)
        {
            Debug.Log(position); //Debug, skal slettes senere
            if (!(drawnTilesList.Contains(position))) {
                drawnTilesList.Add(position);
            }
            
        }
        Vector2Int[] arr = drawnTilesList.ToArray();  //Debug, skal slettes senere
        for (int i = 0; i < drawnTilesList.Count; i++) //Debug, skal slettes senere
        {
            Debug.Log("Drawn:" + arr[i]);
        }
    }
    public void SpawnEnemysRandom() {
        Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
        GameObject enemy = Instantiate(enemyTemplate, new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
        drawnTilesList.Remove(drawnTilePos);
        for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
        {
             drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
             Debug.Log(i); //Debug skal slettes
        }
    }
    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPos = startPos;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = Algorithms.RandomWalk(currentPos, walkLenght);
            floorPos.UnionWith(path); //Adds the floorPos HashSet together with the path HashSet
            /*if (StartEachInterationRandom)  { //Starts each interation at a random point on the floor insted of 0, 0. Has a chance of making larger more "random" rooms.
                currentPos = floorPos.ElementAt(Random.Range(0, floorPos.Count));
            }*/ //Vi skal nok ikke bruge dette så kan evt. fjernes 
        
        }
        return floorPos;
    }
}
