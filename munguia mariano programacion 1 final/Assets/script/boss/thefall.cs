using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thefall : MonoBehaviour
{
    public float speed;
    public Transform fireballT;

    public void Start()
    {
        fireballT=this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballT.position = new Vector3(fireballT.position.x,fireballT.position.y-speed,fireballT.position.z);

    }
}
