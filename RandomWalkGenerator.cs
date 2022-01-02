using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomWalkGenerator : AbstractGeneration
{

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLenght = 15;
        
    public GameObject[] enemyTemplate; 
    public GameObject playerSpawnTemplate;
    public GameObject player; 
    public GameObject chestTemplate; 
    public GameObject barrelTemplate; 
    public GameObject bossDoorTemplate; 
    public GameObject[] plantTemplate;
    public int enemySpawnAmount;
    public int chestSpawnAmount;
    public int barrelSpawnAmount;
    public int plantSpawnAmount;

    private Transform PlayerTransform;
    public static HashSet<Vector2Int> drawnTilesList = new HashSet<Vector2Int>();

    void Start() 
    {
        PlayerTransform = GameObject.Find("Player").transform;
        SpawnObjectsRandom();
    }
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPos = RunRandomWalk(startPos);
        tilemapGenerator.Clear();
        tilemapGenerator.drawFloorTiles(floorPos);
        WallGenerator.CreateWalls(floorPos, tilemapGenerator);
        drawnTilesList.Clear();
        foreach (var position in floorPos)
        {
            if (!(drawnTilesList.Contains(position))) {
                drawnTilesList.Add(position);
            }
            
        }
    }

    public void SpawnObjectsRandom() 
    {
        SpawnPlayerRandom();
        SpawnBossDoorRandom();
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemysRandom();
        }
        for (int i = 0; i < chestSpawnAmount; i++)
        {
            SpawnChestsRandom();
        }
        for (int i = 0; i < barrelSpawnAmount; i++)
        {
            SpawnBarrelsRandom();
        }
        for (int i = 0; i < plantSpawnAmount; i++)
        {
            SpawnPlantsRandom();
        }
    }

    private void SpawnBossDoorRandom()
    {
            Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
            GameObject player = Instantiate(bossDoorTemplate, new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
            drawnTilesList.Remove(drawnTilePos);
            for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
            {
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);   
            }    
    }
    private void SpawnPlantsRandom()
    {
            Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
            GameObject plant = Instantiate(plantTemplate[(Random.Range(0, plantTemplate.Length))], new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
            drawnTilesList.Remove(drawnTilePos);
            for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
            {
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);   
            }    
    }

    private void SpawnPlayerRandom()
    {
            Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
            GameObject player = Instantiate(playerSpawnTemplate, new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
            PlayerTransform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
            drawnTilesList.Remove(drawnTilePos);
            for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
            {
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);
            }       
    }

        public void SpawnEnemysRandom() {
            Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
            GameObject enemy = Instantiate(enemyTemplate[(Random.Range(0, enemyTemplate.Length))], new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
            drawnTilesList.Remove(drawnTilePos);
            for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
            {
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
                drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);
            }
        }

    public void SpawnChestsRandom() {
        Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
        GameObject chest = Instantiate(chestTemplate, new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
        drawnTilesList.Remove(drawnTilePos);
        for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
        {
            drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
            drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);
        }
    }
        public void SpawnBarrelsRandom() {
        Vector2Int drawnTilePos = drawnTilesList.ElementAt(Random.Range(0, drawnTilesList.Count));
        GameObject barrel = Instantiate(barrelTemplate, new Vector3 (drawnTilePos.x, drawnTilePos.y), Quaternion.identity);
        drawnTilesList.Remove(drawnTilePos);
        for (int i = 0; i < Algorithms.Directions.cardinalDirectionsList.Count; i++)
        {
            drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.cardinalDirectionsList[i]);
            drawnTilesList.Remove(drawnTilePos - Algorithms.Directions.intercardinalDirectionsDirectionsList[i]);
        }
    }
    protected HashSet<Vector2Int> RunRandomWalk(Vector2Int pos)
    {
        var currentPos = pos;
        HashSet<Vector2Int> floorPos = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            var path = Algorithms.RandomWalk(pos, walkLenght);
            floorPos.UnionWith(path); 
        }
        return floorPos;
    }
}
