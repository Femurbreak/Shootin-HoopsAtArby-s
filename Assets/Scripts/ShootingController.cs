using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform Ball;
    public Transform Target;
    public Transform PosStart;

    private bool BallInHands = true;
    private bool IsBallFlying = false;
    private bool BallExists = false;
    private float T = 0;

    // Update is called once per frame
    void Update()
    {
        // Ensures that the ball only exists as a single existence at any time.
        if (Input.GetKey(KeyCode.Space) && BallExists == false)
        {
            Instantiate(Ball, PosStart.position, Quaternion.identity);
            BallInHands = true;
            BallExists = true;

        }
        // The ball is released from the hands and is now on it's way towards the target
        if (BallInHands)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                BallInHands = false;
                IsBallFlying = true;
                T = 0;
            }
        }
        // When the ball is in the air, how long will it take to reach it's target, and where is it aiming for.
        if (IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = PosStart.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            Ball.position = pos;
        }

        // Moment when the ball arrives at the hoop.
        //if (t01 >= 1)
        {
           // IsBallFlying = false;
        }
    }
}
