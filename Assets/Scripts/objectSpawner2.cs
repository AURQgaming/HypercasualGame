 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner2 : MonoBehaviour
{
    public GameObject loadPrefab;
    public float spanTime = 1;
    public float timer = 0;
    public float groundPoint = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spanTime)
        {
            Vector3 randonSpawnPosition = new Vector3(Random.Range(-4, 4), groundPoint, Random.Range(-4, 250 ));
            Instantiate(loadPrefab,randonSpawnPosition,Quaternion.identity);
            
            
        }
        timer += Time.deltaTime;
    }    
}
