using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectorSpwaner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
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
            int rand = Random.Range(0, objectPrefabs.Length);

            GameObject obs = Instantiate(objectPrefabs[rand]);
            obs.transform.position = transform.position + new Vector3(Random.Range(-4, 4), groundPoint, Random.Range(-4, 250 ));
            Destroy(obs, 30);
            timer = 0;
        }        

        timer += Time.deltaTime;
        
    }
}
