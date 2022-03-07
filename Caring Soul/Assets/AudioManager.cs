using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static readonly string FirstPlay = "FirstPlay";
    public static readonly string VolumePref = "VolumePref";
    public static readonly string GraphicPref = "GraphicPref";
    private int firstPlayInt;
    public Slider volumeslider, graphicslider;
    private float volumefloat, graphicfloat;
    public AudioSource volumeAudio;
    public AudioSource[] graphicAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            volumefloat = 0.25f;
            graphicfloat = 0.75f;
            volumeslider.value = volumefloat;
            graphicslider.value = graphicfloat;
            PlayerPrefs.SetFloat(VolumePref, volumefloat);
            PlayerPrefs.SetFloat(GraphicPref, graphicfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            volumefloat = PlayerPrefs.GetFloat(VolumePref);
            volumeslider.value = volumefloat;
            graphicfloat = PlayerPrefs.GetFloat(GraphicPref);
            graphicslider.value = graphicfloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(VolumePref, volumeslider.value);
        PlayerPrefs.SetFloat(GraphicPref, graphicslider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        volumeAudio.volume = volumeslider.value;

        for(int i = 0; i < graphicAudio.Length; i++)
        {
            graphicAudio[i].volume = graphicslider.value;
        }
    }
}
