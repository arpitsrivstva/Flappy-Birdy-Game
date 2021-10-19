using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightOperator : MonoBehaviour
{
    public Transform player;
    public Transform blockGenerator;

    public FloatVariable darkness;

    int blockNumber;

    public float lightGenerated = .2f;

    public void SetBlockNumberAndSpawn(int _blockNumber, Transform _player, Transform _blockGenerator) //***
    {

    blockNumber = _blockNumber;
    blockGenerator = _blockGenerator;
    player = _player;

    Vector3 pos = transform.position;
    pos.x = player.position.x + 1.75f + blockNumber; // why blocknumber//
    pos.y = UnityEngine.Random.Range(0.40f, 2f);
    transform.position = pos;
    

    }

    void EnableRenderer()
    {
       GetComponent<Renderer>().enabled = true; //
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
    {
        GetComponent<Renderer>().enabled = false;    
        darkness.value -= lightGenerated;
        Invoke("EnableRenderer", 7f); //
    }
        else if(collision.tag == "Cleaner")
        {
            Move();
        }

    }


   void Move()
    {
        Vector3 pos = transform.position;
        pos.x = blockGenerator.position.x; //
        pos.y = UnityEngine.Random.Range(0.4f, 2.0f);
        transform.position = pos;
    }

}
