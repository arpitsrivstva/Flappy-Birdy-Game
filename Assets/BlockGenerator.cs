using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour
{
    public GameObject light;
    public Transform player;
    public List<GameObject> smallBlocks; //
    public List<GameObject> largeBlocks;
    
    public List<GameObject> clouds;

    public int blocksToGenerate = 12;
    public int cloudsToGenerate = 20;

    int blockNumber = 1;
    int lightNumber = 1;
    

    System.Random rand = new System.Random();

    private void Awake() 
    {
        for(int i=0; i<blocksToGenerate; i++)
        {
            int smallBlocksToGenerate = rand.Next(0, smallBlocks.Count);
            GameObject smallBlock = GameObject.Instantiate(smallBlocks[smallBlocksToGenerate]); //brackets are blowing my mind
            smallBlock.GetComponent<Block>().SetBlockNumberAndSpawn(blockNumber, transform, true); //
            
            int largeBlocksToGenerate = rand.Next(0, largeBlocks.Count);
            GameObject largeBlock = GameObject.Instantiate(largeBlocks[largeBlocksToGenerate]);
            largeBlock.GetComponent<Block>().SetBlockNumberAndSpawn(blockNumber, transform, false); //

            blockNumber++;

            GameObject lightGO = GameObject.Instantiate(light);
            light.GetComponent<LightOperator>().SetBlockNumberAndSpawn(lightNumber, player, transform);
            lightNumber++;

        } 

        for(int i = 0 ; i < cloudsToGenerate ; i++)
        {
            int cloudToGenerate = rand.Next(0,clouds.Count);
            GameObject cloud = GameObject.Instantiate(clouds[cloudToGenerate]);

            float cloudHeight = Random.Range(1.8f, 2.4f);
            float cloudDistance = Random.Range(3.35f, 15f);

            cloud.transform.position = new Vector3(cloudDistance, cloudHeight, 0);

            cloud.GetComponent<CloudMover>().SpawnCloud(transform);

        }  
    }
}
