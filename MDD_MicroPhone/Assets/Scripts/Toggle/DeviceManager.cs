using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceManager : MonoBehaviour
{
    public static DeviceManager instance; // Design Pattern 중 Singleton Pattern의 사용 예시, static 변수로 자기 자신을 가지기 때문에 오직 하나만 존재하고, 어디서든 접근할 수 있음.

    [Header("Toggle Prefab")]
    [SerializeField] private DeviceToggle _toggle;
    [SerializeField] private RectTransform _contents; // RectTransform : UI 오브젝트의 transform

    private DeviceToggle[] _devices;

    private void Awake()
    {
        instance = this;
        this._devices = new DeviceToggle[Microphone.devices.Length]; // 이 시스템의 녹음 장치 개수만큼의 DeviceToggle Type의 배열을 선언함.
    }

    private void Start()
    {
        for(int i=0;i<Microphone.devices.Length;i++)
        {
            DeviceToggle t_toggle = Instantiate(_toggle, Vector3.zero, Quaternion.identity); // 토글 오브젝트를 생성함
            t_toggle.transform.SetParent(_contents, false); // 모든 토글은 _contents GameObject의 자식으로 있어야 하기 때문에, 생성한 오브젝트의 부모 설정을 해 줌
            t_toggle.SetToggleName(Microphone.devices[i]); // 토글의 텍스트를 장치 이름으로 변경
            t_toggle.name = Microphone.devices[i]; // 토글의 gameObject의 이름을 변경(나중에 어떤 토글이 선택되었는지를 gameObject의 이름으로 가져올 것이기 때문)
            this._devices[i] = t_toggle;
        }
    }

    public void SetAllToggleInteracable(bool flag) // 모든 토글의 선택 가능 여부를 조정
    {
        for (int i = 0; i < _devices.Length; i++)
            this._devices[i].SetToggleInteracable(flag);
    }
}
