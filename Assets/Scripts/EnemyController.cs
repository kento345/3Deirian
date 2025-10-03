using UnityEngine;
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Length = 10f;

    private Vector3 turnRot = new Vector3(0,90,0);
    private int rand;

    [SerializeField] private LayerMask rigthLayer;
    [SerializeField] private LayerMask leftLayer;
    [SerializeField] private LayerMask rlLayer;

    private void Start()
    {
        rand = Random.Range(1, 11);
        Debug.Log(rand);
    }

    void Update()
    {
            var move = transform.forward * speed * Time.deltaTime;
        //new Vector3(0, 0, 1)
            transform.position += move;
    }

    private void OnTriggerEnter(Collider other)
    {
        int LayerObj = (1 << other.gameObject.layer);
        

        if ((LayerObj & rigthLayer) != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles + turnRot);
        }
        else if((LayerObj & leftLayer) != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles - turnRot);
        }
        else if((LayerObj & rlLayer) != 0)
        {
            
            if(rand >= 1 && rand <= 5)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles + turnRot);
            }
            else if(rand >= 6 && rand <= 11)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles - turnRot);
            }
                ;          
        }
    }


    /*    void Hit()
        {
            var pos = transform.position;
            var offset = new Vector3(pos.x, pos.y + 1, pos.z);
            Ray ray = new Ray(offset, Vector3.forward);
            RaycastHit hit;
            Debug.DrawRay(offset, Vector3.forward * Length, Color.red, 0f);
            if (Physics.Raycast(ray, out hit, Length))
            {
                if (hit.collider.CompareTag("Wall"))
                {

                }
            }
        }*/
}
