using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TongueController : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public float LickPeriod = 0.5f;

    public LayerMask CollideWith;

    Collider[] hitDrops = new Collider[50];
    BoxCollider tongueCollider;
    private Camera UICamera;
    private Transform tr;
    Animator animator;

    bool lickAllowed = true;

    void Start()
    {
        this.tr = transform;
        animator = GetComponent<Animator>();
        tongueCollider = GetComponent<BoxCollider>();
        UICamera = GameObject.FindGameObjectWithTag("UICamera").GetComponent<Camera>();
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
        yield return new WaitForFixedUpdate();
        // var hitCount = Physics.OverlapBoxNonAlloc(transform.position,
        //                                         tongueCollider.size * transform.localScale.x / 2, hitDrops,
        //                                         this.transform.rotation, CollideWith, QueryTriggerInteraction.UseGlobal);
        // Debug.Log("hits " + hitCount);
        // if (hitCount > 0)
        // {
        //     GameController.instance.score += hitCount;
        // }

        // for (int i = 0; i < hitCount; i++)
        // {
        //     Destroy(hitDrops[i].gameObject);
        // }

        foreach (var item in drops)
        {
            Destroy(item);
        }
        drops.Clear();
        yield return new WaitForSeconds(LickPeriod);
        lickAllowed = true;
    }

    public void SetPos(Vector2 pos)
    {
        var lala = UICamera.ScreenToWorldPoint(pos);
        transform.position = new Vector3(tr.position.x, lala.y, tr.position.z);
    }

    HashSet<GameObject> drops = new HashSet<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("dsfad");
        drops.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        drops.Remove(other.gameObject);
    }
}
