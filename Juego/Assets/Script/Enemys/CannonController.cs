using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    GameObject target;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();

    }

    /// <summary>
    /// Hace que mi enemigo vea a mi Player, sin moverse
    /// </summary>
    void LookAtPlayer()
    {
        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);
    }

    public void DestroyCannon()
    {
        Destroy(this.gameObject);
    }
}
