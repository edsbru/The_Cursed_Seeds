using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SlimeManager : MonoBehaviour
{

    public GameObject fsPrefab;

    [SerializeField] public AudioClip footstep;
    public static SlimeManager instance;
    public GameObject[] slimes;

    private void Start()
    {
        instance = this;
        int[] indexes = new int[transform.childCount];
        for (int i = 0; i < indexes.Length; i++)
        {
            indexes[i] = i;
        }


        for (int i = 0; i < indexes.Length; i++)
        {
            int temp = indexes[i];
            int randomIndex = Random.Range(i, indexes.Length);
            indexes[i] = indexes[randomIndex];
            indexes[randomIndex] = temp;
        }

        List<int> spawned = new List<int>();
        for(int i = 0;i < indexes.Length; i++)
        {
            int index = indexes[i];
            var slime = transform.GetChild(index).GetComponent<Slime>();
            bool spawn = Random.Range(0, 100) < 30;
            if(spawn && !ListIntersection(spawned, slime.incompatibles))
            {
                spawned.Add(index);
                slime.gameObject.SetActive(true);
            }
        }

    }

    bool ListIntersection(List<int> l1, int[] l2)
    {
        foreach (var v in l2)
        {
            if(ListContains(l1, v))
            {
                return true;
            }
        }
        return false;
    }

    bool ListContains(List<int> list, int item) 
    {
        foreach (var item1 in list)
        {
            if(item1 == item) return true;
        }

        return false;

    }

}
