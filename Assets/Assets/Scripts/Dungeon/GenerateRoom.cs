using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GenerateRoom : MonoBehaviour
{
    public int roomCount = 0;
    public GameObject tp;
    public GameObject[] rooms;

    public const int MAX_ROOMS = 8;

    public Vector2 offset;

    float timeToFixPosition = 1f;
    bool fixedPosition = false;
    GameObject generatedRoom;

    bool ListContains(List<int> list, int item)
    {
        foreach (var item1 in list)
        {
            if (item1 == item) return true;
        }

        return false;

    }

    // Start is called before the first frame update
    void Start()
    {
        bool roomCreatedInThisPosition = DungeonManager.instance.currentRoomsPositions.Contains(transform.position);
        int roomsAmount = DungeonManager.instance.currentRoomsPositions.Count;
        bool roomGenerationLimitExceeded = roomsAmount > MAX_ROOMS;
        bool canGenerate = !roomCreatedInThisPosition && !roomGenerationLimitExceeded;
        bool willGenerate = Random.Range(0f, 100f) > 50f || roomsAmount == 0;


        if (canGenerate && willGenerate)
        {
            
            int selectedPrefabIndex = Random.Range(0, DungeonManager.instance.roomPrefabs.Length);

            if(DungeonManager.instance.spawnedRoomsIndexes.Count != 0)
            {
                selectedPrefabIndex = DungeonManager.instance.spawnedRoomsIndexes[0];
                DungeonManager.instance.spawnedRoomsIndexes.RemoveAt(0);
            }

            generatedRoom = Instantiate(DungeonManager.instance.roomPrefabs[selectedPrefabIndex], transform.position, Quaternion.identity);
            generatedRoom.name = "Room " + DungeonManager.instance.RoomsObjecs.Count;
            DungeonManager.instance.RoomsObjecs.Add(generatedRoom);
            DungeonManager.instance.currentRoomsPositions.Add(transform.position);

            generatedRoom.transform.position = generatedRoom.transform.position + (Vector3)offset;


            if (DungeonManager.instance.currentRoomsPositions.Count <= GenerateRoom.MAX_ROOMS)
            {
                gameObject.SetActive(false);
            }

        }
        else
        { 
            enabled = false;
        }
        
    }

    void Update()
    {
        timeToFixPosition -= Time.deltaTime;
        if (timeToFixPosition <= 0)
        {
            if (!fixedPosition)
            {
                fixedPosition = true;
                generatedRoom.transform.position = generatedRoom.transform.position + (Vector3)offset;
            }

        }
    }

}
