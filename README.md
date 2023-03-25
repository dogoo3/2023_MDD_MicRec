# 2023_MDD_MicRec
2023년도 1학기 메타버스:설계 및 개발 Unity MicroPhone System 예제 구현 코드

모든 Windows PC에서 사용이 가능하도록 구현된 MicroPhone System 예제 구현 코드입니다.

예제의 종류는 다음과 같습니다.

1. PlayCollectTimeScene : 일정 시간까지 소리를 녹음한 뒤, 일정 시간이 경과되면 녹음된 소리를 AudioSource를 통해 출력하는 코드  
2. PlayCustomTimeScene : 사용자가 직접 소리를 녹음한 뒤, 녹음을 종료하면 AudioSource를 통해 출력하고 저장하는 코드  
3. PlayRealTimeScene : 매 프레임 시간 단위로 소리를 녹음한 뒤, 녹음된 소리를 바로바로 AudioSource를 통해 출력하는 코드

Scroll View 및 Toggle에 대해서는 아래 블로그의 설명을 참고하시기 바랍니다.  
Scroll View : https://kumgo1d.tistory.com/14  
Toggle : https://scvtwo.tistory.com/34  
ToggleGroup : https://undercode.tistory.com/13

DeviceManager 스크립트에 적용된 Singleton Pattern에 대하여 :  
https://ssapo.tistory.com/33

파일 저장 경로에 대한 설명 :  
https://3dmpengines.tistory.com/1745  
(공식문서) https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html  

각 Scene에서의 주요 스크립트는 Canvas -> Scroll View -> RecordButton 오브젝트에 적용되어 있으며, DeviceManager 스크립트는 Scroll View 오브젝트에 적용되어 있습니다.

이 프로젝트는 2021.3.6f1 버전에서 제작되었습니다.

도움 주신 분 : 김기락 조교님
