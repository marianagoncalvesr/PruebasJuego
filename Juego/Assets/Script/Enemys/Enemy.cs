using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 5.0f;
    [SerializeField] protected float changeDistance = 0.5f;
    Vector3 temp;
    [SerializeField] public GameObject Particle { get; set; }


    private void Awake()
    {
    }
    public void DestroySpider()
    {
        temp = transform.localScale;
        temp.y -= 0.25f;
        transform.localScale = temp;

        if (temp.y == 0)
        {

            Destroy(this.gameObject);
            GameManager.instance.CurrentStats.Enemies++;

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Particle = GameObject.Find("FX_Explosion");
            var emission = Particle.GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
            Particle.transform.position = other.gameObject.transform.position;
            Particle.GetComponent<ParticleSystem>().Play();

            Destroy(other.gameObject);
        }


    }


}

