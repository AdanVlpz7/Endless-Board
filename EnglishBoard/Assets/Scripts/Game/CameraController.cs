using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int offset;
    public int xOffset;
    public Transform target;
    public Transform bg1;
    public Transform bg2;
    private float size;

    private Vector3 cameraTargetPos = new Vector3();
    private Vector3 bg1TargetPos = new Vector3();
    private Vector3 bg2TargetPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        size = 1600f;
    }
    private void OnEnable()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        size = 1600f;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.GameFinished)
            target = null;
        Vector3 targetPos = SetPos(cameraTargetPos, this.transform.position.x,target.position.y + offset,target.position.z);
        transform.position = Vector3.Lerp(transform.position,targetPos,0.2f);

        if(transform.position.y >= bg2.position.y)
        {
            bg1.position = SetPos(bg1TargetPos, bg1.position.x, bg2.position.y + size - 100, bg1.position.z);
            Switching();
        }
        if(transform.position.y <= bg1.position.y)
        {
            bg2.position = SetPos(bg2TargetPos, bg2.position.x, bg1.position.y - size + 100, bg2.position.z);
            Switching();
        }
    }
    private void Switching()
    {
        Transform temp;
        temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    private Vector3 SetPos(Vector3 pos, float x, float y, float z)
    {
        pos.x = x;
        pos.y = y;
        pos.z = z;
        return pos;
    }
}
