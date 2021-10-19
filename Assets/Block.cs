using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockNumber;
    Transform blockGenerator;
    bool smallBlock;
    public bool isTrigger;

    public void SetBlockNumberAndSpawn(int _blockNumber, Transform _blockGenerator, bool _smallblock)
  {
//except this.blockNumber ->
    blockNumber = _blockNumber;
    blockGenerator = _blockGenerator;
    smallBlock = _smallblock;

    Vector3 pos = Vector3.zero; //

    pos.x = Camera.main.transform.position.x + 1.75f + blockNumber*1.25f; //

    PlaceBlock(pos);   
}

private void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.tag == "Cleaner")
    {
        Move();
    }
}

private void Move()
{
   Vector3 pos = transform.position;
   pos.x = blockGenerator.position.x;
   PlaceBlock(pos);
}

private void PlaceBlock(Vector3 pos)
{
   if(smallBlock)
    {
        if(blockNumber % 2 == 0) //
        {
            pos.y = UnityEngine.Random.Range(0.4f , 0.9f); //two variables
        }
        else
        {
            pos.y = UnityEngine.Random.Range(1.7f , 2.25f);
        }
    }
    else
    {
        if(blockNumber % 2 != 0)
        {
            pos.y = UnityEngine.Random.Range(0.4f , 0.9f);
        }
        else
        {
            pos.y = UnityEngine.Random.Range(1.7f , 2.25f);
        }
    }
    transform.position = pos;
}

}
