using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("TempPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y += 30;
        pos.z -=20;
        this.transform.position = pos;
    }
}
