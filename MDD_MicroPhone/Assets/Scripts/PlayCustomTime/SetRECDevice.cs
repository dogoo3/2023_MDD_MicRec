using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetRECDevice : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private ToggleGroup _toggleGroup_micList;
    [SerializeField] private AudioSource _source;
    
    private SaveAudio _csrAPI;
    private Text _buttonText;

    private void Awake()
    {
        this._csrAPI = GetComponent<SaveAudio>();
        this._buttonText = this.gameObject.GetComponentInChildren<Text>();
    }

    private Toggle selectToggle
    {
        get { return this._toggleGroup_micList.ActiveToggles().FirstOrDefault(); } 
        // C#의 구문(LINQ)
        // 활성화된 토글을 검색하면서, 가장 처음으로 활성화된 토글을 반환한다.
        // First와 FirstOrDefault의 차이는, 반환 객체의 존재 유무이다. 
        // First는 반환객체가 없으면 오류가 발생하고, FirstOrDefault는 반환이 없어도 됨.
    }

    public void ShowSelectToggleName()
    {
        if (!Microphone.IsRecording(selectToggle.name)) // 녹음 시작
        {
            this._buttonText.text = "녹음 종료";
            DeviceManager.instance.SetAllToggleInteracable(false); // 녹음을 시작하면 Toggle을 조작할 수 없도록 모든 토글을 비활성화하는 함수를 호출
            this._clip = Microphone.Start(selectToggle.name, true, 15, 44100); // 녹음 시작
        }
        else // 녹음 종료
        {
            this._buttonText.text = "녹음 시작";
            DeviceManager.instance.SetAllToggleInteracable(true); // 녹음을 정지하면 다시 Toggle을 조작할 수 있도록 모든 토글을 활성화하는 함수를 호출
            int t_sIndex = Microphone.GetPosition(selectToggle.name); // 현재까지 녹음된 sample의 index를 반환
            Microphone.End(selectToggle.name); // 녹음 종료
            
            float[] samples = new float[_clip.samples]; // 원래 _clip만큼의 sample 수만큼 배열 공간 할당
            _clip.GetData(samples, 0); // clip의 sample을 가져와서 저장

            float[] cutSamples = new float[t_sIndex]; // 녹음된 index까지만큼의 sample 수만큼 배열 공간 할당
            Array.Copy(samples, cutSamples, cutSamples.Length - 1); // 복사 
            AudioClip _clip2 = AudioClip.Create("rec", cutSamples.Length, 1, 44100, false); // 새로운 AudioClip을 만듬
            _clip2.SetData(cutSamples, 0); // _clip2에 cutSample의 데이터 할당

            _csrAPI.SaveAudioClip(_clip2);
        }
    }
}
