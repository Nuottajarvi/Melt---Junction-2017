using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TongueController : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float LickPeriod = 0.5f;

    Collider[] hitDrops = new Collider[50];
    BoxCollider tongueCollider;
    Animator animator;

    bool lickAllowed = true;

    void Start()
    {
        tongueCollider = GetComponent<BoxCollider>();
    }

    public void Lick()
    {
        if (lickAllowed)
            StartCoroutine(LickRoutine());
    }

    public IEnumerator LickRoutine()
    {
        lickAllowed = false;
        animator.SetTrigger("Lick");
        var hitCount = Physics.OverlapBoxNonAlloc(tongueCollider.center, tongueCollider.size / 2, hitDrops);

        if (hitCount > 0)
        {
            GameController.instance.score += hitCount;
        }

        for (int i = 0; i < hitCount; i++)
        {
            Destroy(hitDrops[i].gameObject);
        }
        yield return new WaitForSeconds(LickPeriod);
        lickAllowed = true;
    }

    public void SetPos(float pos)
    {
        var foo = transform.localPosition;
		foo.y = Mathf.Clamp(pos, minPos, maxPos);
		transform.localPosition = foo;
    }
}
