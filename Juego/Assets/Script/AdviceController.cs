using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceController : MonoBehaviour
{
   [SerializeField] private int distance = 40;

    [SerializeField] GameObject warning;
    [SerializeField] GameObject direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Warning();
    
    }


    private IEnumerator EnableWarning()
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(3);
        warning.SetActive(false);

    }

    private void Warning()
    {
        RaycastHit hit;
        if (Physics.Raycast(direction.transform.position, direction.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Necesitas 3 llaves para abrir la puerta");
                StartCoroutine(EnableWarning());

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(direction.transform.position, direction.transform.TransformDirection(Vector3.forward) * distance);
    }
}
