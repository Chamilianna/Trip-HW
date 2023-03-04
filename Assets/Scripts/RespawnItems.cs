using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItems : MonoBehaviour
{
    public GameObject[] item = new GameObject[4];
    
    public int spawnNum = 6;
    
    public float negRange = -1;

    public float posRange = 1;

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        for(int i = 0; i < spawnNum; i++)
        {
            float randomX = Random.Range(negRange, posRange);
            float randomZ = Random.Range(negRange, posRange);
            Vector3 itemPos = new Vector3(this.transform.position.x + randomX,
            this.transform.position.y, this. transform.position.z + randomZ);

            Instantiate(item[Random.Range(0,item.Length)], itemPos,Quaternion.identity);
        }
    }
}
