using UnityEngine;

public class Flash : MonoBehaviour
{
    private int time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;
        if (time>1)
        {
            Destroy(this.gameObject);
        }
    }
}
