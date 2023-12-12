using UnityEngine.Audio;
using UnityEngine;
using System;

public class audiomanager : MonoBehaviour
{
	public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds){
        	s.source = gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;

        	s.source.volume = s.volume;
        	s.source.pitch = s.pitch;
        	s.source.loop = s.loop;
        }
    }

    void Start(){
    	Play("bgmusic");
    }

    public void turnOffMusic(){
    	sounds[3].source.volume = 0f;
    }

    public void turnOnMusic(){
    	sounds[3].source.volume = sounds[3].volume;
    }

    public void toggleMute(){
    	if(sounds[3].source.volume == 0f){
    		turnOnMusic();
    	}
    	else{
    		turnOffMusic();
    	}
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
        	Debug.LogError("Sound: " + name + " not found!");
        	return;
        }
        s.source.Play();
    }
}
