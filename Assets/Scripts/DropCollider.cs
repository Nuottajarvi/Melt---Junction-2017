using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollider : MonoBehaviour
{

    void Update()
    {
        transform.Translate(new Vector3(0, Input.GetAxis("Mouse Y") * 0.1f, 0));
    }

    public void DeleteDrops()
    {
        // GetComponent<Animator>().SetTrigger("Lick");

        // Debug.Log(drops.Count);

        // Physics.BoxCastNonAlloc()

        // for (int i = drops.Count - 1; i >= 0; i--)
        // {
        //     Destroy(drops[i]);
        //     drops.RemoveAt(i);
        //     GameController.instance.score++;
        // }
    }
}
