using System;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spr;
    [SerializeField] protected float closeRadius = 0.2f;
    [SerializeField] protected LayerMask playermask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (checkClose())
        {
            spr.flipY = true;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Boom!");
                Destroy(gameObject);
                
            }
        }
        else
        {
            spr.flipY = false;
        }
    }

    public bool checkClose()
    {
        return Physics2D.OverlapCircle(gameObject.transform.position, closeRadius,playermask);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gameObject.transform.position, closeRadius);
    }
}
