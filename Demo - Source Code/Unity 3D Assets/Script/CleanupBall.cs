using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupBall : MonoBehaviour {
    private float ballStartTime;


    public float balllifespan = 5.0f;

    // Use this for initialization
    void Start()
    {
     
        // Fixed time is updated in regular intervals (equal to fixedDeltaTime) until time property is reached.
        ballStartTime = Time.fixedTime;

    }

    // Update is called once per frame
    void Update()
    {
        // Clean up after elapsed time... 

        if (Time.fixedTime - ballStartTime > balllifespan)
        {
            Destroy(this.gameObject);
        }
    }
}
