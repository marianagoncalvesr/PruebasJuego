using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LlegadaManager : MonoBehaviour
{
    [SerializeField] PostProcessVolume process;
    ColorGrading color;
    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
       // process.profile.TryGetSettings(out color);

        //color.postExposure.value = player.GetComponent<PlayerController2>().DiamondsQuantity;

    }
}
