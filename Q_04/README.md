# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 1. Attack 메서드에서 damageble이 IDamagable을 상속받지 않는 오브젝트들을 인식하지 못해서 상속받지 않는 오브젝트들에게도 TakeHit메서드를 실행시키려 하니 참조오류가 발생.
=> if(!col.TryGetComponent(out damageble)) return; 을 통해 IDamagable을 상속받지 않았을 경우 넘어가도록 수정

- 2. 공격을 하고 난뒤에 스택오버플로우에 빠지면서 상태가 전환되지 않는 문제가 발생
=> 코드를 보니 attackstate의 Exit부분에서 ChangeState 메서드를 호출하게 되는데 ChangeState 메서드 내에 현재 state의 Exit를 호출하는 부분이 있음.
=> 이로 인해 Exit를 무한히 반복하는 스택오버플로우 발생하면서 상태가 전환되지 않게되어서 Machine.ChangeState(StateType.Idle)을 DelayRoutine 코루틴 내의 Exit()를 지우고 해당위치에 넣음