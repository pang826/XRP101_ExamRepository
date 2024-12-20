# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안
- 1. 스택오버플로우가 발생하는 것은 프로퍼티에서 'private set => MoveSpeed = value;' 이 부분이 값을 넣으려고 할 때 자기자신을 호출하는데 
'get => MoveSpeed' 이 부분에서 가져오려 할때도 자기자신을 호출하기 때문에 
set하려고 자신을 호출 => get을 통해 값을 불러내려고 자신을 호출하는 과정에서 문제가 발생하는 것 같습니다.
+ 이동하려고 이동키를 입력하면 get을 통해 자기자신을 무한정으로 호출하면서 스택 오버플로우가 발생하는 것 같습니다.
해결법은 
(1) {get; private set;}을 사용하거나 
(2) private float _moveSpeed 를 통해 현재 람다식 다음의 MoveSpeed를 _moveSpeed로 바꿔서 진행해야 함(+ Init 메서드도 _moveSpeed = 5f로 변경)

- 2. 대각선으로 이동 시 벡터값(1,0과 0,1)이 동시에 적용되면서 (1,1)의 위치로 이동하게 되는데 (1,1)의 경우 피타고라스의 법칙에 의한
대각선의 거리보다 길기 때문에 해당 값만큼의 속도오차가 발생하는 것 같습니다.
해결법은
x벡터값과 z벡터값을 받아오는 Vector3 direction을 정규화(normalized)하면 됨