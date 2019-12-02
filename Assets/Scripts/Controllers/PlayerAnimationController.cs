using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animation anim;

    public void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    public void walk()
    { 
    }

    public void idle()
    {

    }
}
