using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class SaveAudio : MonoBehaviour
{
    public AudioSource source;

    public void SaveAudioClip(AudioClip _clip)
    {
        if(source != null)
        {
            this.source.clip = _clip;
            this.source.Play();
        }
        // 소리 저장
        SavWav.Save("rec", _clip);

        // 저장한 소리를 다시 가져오는 구문

        /*
        FileStream fs = new FileStream(Application.persistentDataPath + "/rec.wav",
            FileMode.Open, FileAccess.Read);
        byte[] filedata = new byte[fs.Length];
        fs.Read(filedata, 0, filedata.Length);
        fs.Close();
        */
    }
}
