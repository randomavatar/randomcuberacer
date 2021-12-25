using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public static float forwardForce = 3000f;
    public static float sidewaysForce = 35f;

    public Joystick joystick;

    // Physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

#else

        JoystickIsBeenUsed(joystick);

        /*
        float middle = Screen.width / 2;

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < middle)
                {
                    PressedLeft();
                }

                if (touch.position.x > middle)
                {
                    PressedRight();
                }
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                if (touch.position.x < middle)
                {
                    PressedLeft();
                }

                if (touch.position.x > middle)
                {
                    PressedRight();
                }
            }
        }
        */

        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (touch.phase == TouchPhase.Stationary)
                {
                    if (touch.position.x < middle)
                    {
                        PressedLeft(touch.pressure);
                    }

                    if (touch.position.x > middle)
                    {
                        PressedRight(touch.pressure);
                    }
                }
            }
        }
        */

#endif

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EngGame();
        }
    }

    public void PressedLeft()
    {
        rb.AddForce(-(sidewaysForce) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void PressedRight()
    {
        rb.AddForce((sidewaysForce) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    public void JoystickIsBeenUsed(Joystick joystick)
    {
        rb.AddForce((joystick.Horizontal * sidewaysForce) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
