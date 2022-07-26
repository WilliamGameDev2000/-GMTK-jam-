using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMenu : MonoBehaviour
{
    float transition_timings = 1.05f;

    public void RotateFront()
    {
        audiomanager.instance.Play("Roll");
        transform.LeanRotate(new Vector3(90, 0, 0), transition_timings);
    }

    public void RotateBack()
    {
        audiomanager.instance.Play("Roll");
        transform.LeanRotate(new Vector3(90, 0, 180), transition_timings);
    }

    public void RotateRight()
    {
        audiomanager.instance.Play("Roll");
        transform.LeanRotate(new Vector3(90, 0, -90), transition_timings);
    }

    public void RotateBottom()
    {
        audiomanager.instance.Play("Roll");
        transform.LeanRotate(new Vector3(180, 0, 0), transition_timings);
    }
}
