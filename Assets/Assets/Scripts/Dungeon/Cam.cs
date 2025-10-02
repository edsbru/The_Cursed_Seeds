using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject cam;
    public string direcion;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CameraFollow");
        player = FindObjectOfType<PlayerStats>().transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float distToCrossDoorsHorizontal = 2f;
        float distToCrossDoorsVertical = 5f;

        if(collision.tag == "Player")
        {
            SoundController.instance.PlaySound(CrossDoorData.instance.sound);
            if (direcion == "up")
            {
                cam.transform.position += new Vector3(0, 12.38f, 0);
                player.transform.position += new Vector3(0, distToCrossDoorsVertical, 0);
            }

            else if (direcion == "down")
            {
                cam.transform.position += new Vector3(0, -12.48f, 0);
                player.transform.position += new Vector3(0, -distToCrossDoorsVertical, 0);
            }

            else if(direcion == "right")
            {
                cam.transform.position += new Vector3(22, 0, 0);
                player.transform.position += new Vector3(distToCrossDoorsHorizontal, 0, 0);
            }

            else if (direcion == "left")
            {
                cam.transform.position += new Vector3(-22f, 0, 0);
                player.transform.position += new Vector3(-distToCrossDoorsHorizontal, 0, 0);
            }
            FixTeleportedPosition();

            AutoConfigMinimapMask.ConfigurarRenderers();

        }

    }

    void FixTeleportedPosition()
    {
        var rooms = FindObjectsOfType<TpManager>();
        var closest = rooms[0];
        float closesDistance = Vector2.Distance(closest.transform.position, cam.transform.position);

        foreach ( var room in rooms )
        {
            float distance = Vector2.Distance(cam.transform.position, room.transform.position);

            if ( distance < closesDistance )
            {
                closesDistance = distance;
                closest = room;
            }
        }

        Vector2 destinyPosition = closest.transform.position;
        cam.transform.position = (Vector3)destinyPosition + Vector3.forward * cam.transform.position.z;


    }

}
