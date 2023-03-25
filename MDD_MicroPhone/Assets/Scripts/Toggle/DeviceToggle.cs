using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Toggle 자체에 관련한 함수
public class DeviceToggle : MonoBehaviour
{
    private Toggle _toggle;
    private Text _text;

    private void Awake()
    {
        this._toggle = GetComponent<Toggle>();
        this._text = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        this._toggle.group = GetComponentInParent<ToggleGroup>();
    }

    public void SetToggleName(string name) // 토글의 텍스트 이름을 장치 이름으로 변경해주는 함수
    {
        this._text.text = name;
    }

    public void SetToggleInteracable(bool flag) // 토글의 선택 가능 여부를 설정하는 함수. true면 변경이 가능하고 false면 변경이 불가능함.
    {
        this._toggle.interactable = flag;
    }
}
