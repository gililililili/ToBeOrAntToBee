using UnityEngine;

public class skinStealer : MonoBehaviour
{
    [SerializeField] protected float closeRadius = 2f;
    [SerializeField] protected LayerMask corpseMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] corpseOverlaps = Physics2D.OverlapCircleAll(gameObject.transform.position, closeRadius,corpseMask);
        Collider2D currentCorpse =  findClosest(corpseOverlaps);
        if (currentCorpse != null)
        {
            SpriteRenderer corpseSprite = currentCorpse.GetComponent<SpriteRenderer>();
            corpseSprite.flipY = true;
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Boom!");
                SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
                currentSprite.sprite = corpseSprite.sprite;
                Destroy(currentCorpse.gameObject);
                
            }
        }
        else
        {
            //spr.flipY = false;
        }
    }

    public Collider2D findClosest(Collider2D[] hits)
    {

        float shortestDistance = Mathf.Infinity;
        Collider2D closest = null;

        if (hits == null) return null;
        foreach(Collider2D hit in hits){
            if(hit.gameObject == gameObject) continue;
            
            Vector2 dif = hit.transform.position - transform.position;
            float distance = dif.sqrMagnitude;
            
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closest = hit;
            }
        }
        return closest;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.brown;
        Gizmos.DrawWireSphere(gameObject.transform.position, closeRadius);
    }

}
