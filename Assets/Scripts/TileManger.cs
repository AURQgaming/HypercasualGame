using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManger : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 50.0f;
    private float titeLengh = 300.0f;
    private int amnTilesOnScreen = 3;
    private float safeZone = 500.0f;
    

    private List<GameObject> roadList;

    // Start is called before the first frame update
    void Start()
    {
        roadList = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpwanTile ();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen *titeLengh))
        {
            SpwanTile ();
            DeleteRoad ();
        }
    }

    private void SpwanTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += titeLengh;
        //
        roadList.Add(go); 
        
    }
    void DeleteRoad()
    {
        Destroy(roadList[0]);
        roadList.RemoveAt(0);
    }
}
