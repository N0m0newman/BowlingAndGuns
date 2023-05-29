using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class GlideLocomotion : MonoBehaviour
{
    [SerializeField]
    Transform root;
    [SerializeField]
    Transform tracked;
    [SerializeField]
    float velocity = 2.0f;
    [SerializeField]
    float rotationSpeed = 100f;


    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("XRI_Left_Primary2DAxis_Vertical");
        if(forward != 0.0f)
        {
            Vector3 moveDirection = Vector3.forward;
            if(tracked != null)
            {
                moveDirection = tracked.forward;
                moveDirection.y = 0;
            }
            moveDirection *= -forward * velocity * Time.deltaTime;
            root.Translate(moveDirection);
        }
        float sideways = Input.GetAxis("XRI_Left_Primary2DAxis_Horizontal");
        if(sideways != 0.0f)
        {
            if(sideways < 0.0f)
            {
                Vector3 moveDirection = -tracked.right;
                moveDirection.y = 0;
                moveDirection *= -sideways * velocity * Time.deltaTime;
                root.Translate(moveDirection);
            }
            else
            {
                Vector3 moveDirection = tracked.right;
                moveDirection.y = 0;
                moveDirection *= sideways * velocity * Time.deltaTime;
                root.Translate(moveDirection);
            }
        }
        if(tracked == null)
        {
            float rotate = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");
            if (rotate != 0.0f)
            {
                float rotation = rotate * rotationSpeed * Time.deltaTime;
                root.Rotate(0, rotation, 0);
            }
        }
    }
}
