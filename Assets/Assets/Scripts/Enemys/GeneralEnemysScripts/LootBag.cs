using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject dropedSeedPrefab;
    public List<Wseed> WseedsList = new List<Wseed>();



    // Start is called before the first frame update
    Wseed GetDroppedSeed()
    {

        if(Random.Range(0,101) < 10)
        {
            // Spawn life;
            var obj = Instantiate(CollectSeeds.instace.lifePrefab, transform.position, Quaternion.identity);
            obj.AddComponent<DeleteDropeableByTyme>();
            return null;
        }

       int randmomNumber = Random.Range(1, 101);
       List<Wseed> possibleSeeds = new List<Wseed>();

        foreach(Wseed wseed in WseedsList)
        {
            if (randmomNumber <= wseed.dropChance)
            {
                possibleSeeds.Add(wseed);
            }
        }

        if (possibleSeeds.Count > 0)
        {
            Wseed dropedSeed = possibleSeeds[Random.Range(0, possibleSeeds.Count)];
            return dropedSeed;
        }
        Debug.Log("No loot droped");
        return null;
    }

    public void InstatianteWseed(Vector3 spawnPosition)
    {
        Wseed dropedSeed = GetDroppedSeed();
        if (dropedSeed != null)
        {
            GameObject WseedGameObject = Instantiate(dropedSeedPrefab, spawnPosition, Quaternion.identity);
            WseedGameObject.GetComponent<SpriteRenderer>().sprite = dropedSeed.seedSprite;
            WseedGameObject.GetComponent<Reference>().ws = dropedSeed;
            float dropForce = 2f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
            WseedGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            GameObject bubble = Instantiate(CollectSeeds.instace.bubble, spawnPosition, Quaternion.identity);
            bubble.transform.SetParent(WseedGameObject.transform);
            var c = WseedGameObject.AddComponent<PropagateBubbleExplosion>();
            c.bubble = bubble.GetComponent<BubbgleScript>();
            var a = WseedGameObject.AddComponent<AnimacionInteraccion>();
            a.offset = 0.1f;

            WseedGameObject.GetComponent<CircleCollider2D>().radius *= 3.5f;
            WseedGameObject.AddComponent<DeleteDropeableByTyme>();
            bubble.AddComponent<DeleteDropeableByTyme>();

        }
    }
}
