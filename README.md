# Cash Calculator

Unity로 제작한 안드로이드용 현금 합계 계산기입니다.

## 주요 기능

- 50,000원부터 10원까지 권종별 수량 입력
- `+` / `-` 버튼을 통한 수량 조절
- 전체 금액 실시간 계산
- 300,000원 도달 및 초과 금액 표시
- 모든 입력값을 초기화하는 Reset 버튼
- 세로 화면 안드로이드 빌드 지원

## 프로젝트 열기

Unity Hub에서 이 저장소 폴더를 프로젝트로 추가한 뒤 열면 됩니다. 필요한 패키지는 `Packages/manifest.json`을 기준으로 Unity가 자동으로 설치합니다.

## 주요 스크립트

- `Assets/Script/MoneyRow.cs`: 권종별 수량과 부분 합계 관리
- `Assets/Script/CashCalculatorManager.cs`: 전체 합계, 30만 원 기준 알림 및 초기화 관리
