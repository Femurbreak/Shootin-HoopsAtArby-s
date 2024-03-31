using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform Ball;
    public Transform BallClone;
    public Transform Target;
    public Transform PosStart;
    public bool BallExists = false;

    private bool BallInHands = true;
    private bool IsBallFlying = false;
    private float T = 0;
    private float t01;

    // Update is called once per frame
    void Update()
    {
        // Ensures that the ball only exists as a single existence at any time.
        if (Input.GetKeyDown(KeyCode.Space) && BallExists == false)
        {
            var o = Instantiate(Ball, PosStart.position, Quaternion.identity);
            BallClone = o.transform;
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
            float duration = 1.5f;
            t01 = T / duration;

            // How the ball moves from Spawn point to Target point.
            Vector3 A = PosStart.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            // How the ball moves in an arc.
            Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

            BallClone.position = pos + arc;
        }

        // Moment when the ball arrives at the hoop.
        //if (t01 >= 1)
        {
           // IsBallFlying = false;
           // BallClone.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    // Destroys the ball, resets everything so ball can spawn again.
    public void BallDestroyed()
    {
        BallExists = false;
        BallClone = null;
        IsBallFlying = false;
        T = 0;
        t01 = 0;
    }
}
