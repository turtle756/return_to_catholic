# VoiceLive Play 예배 세팅

교회 예배 보컬용. 현재 확정된 세팅만 적는다.

## 장비

| 항목 | 내용 |
|---|---|
| 이펙터 | TC-Helicon VoiceLive Play |
| 마이크 | Shure 유선 보컬 마이크 (다이나믹, Beta 58A 계열로 보임) |
| 케이블 | 카나레 XLR 2m 1조: 마이크 → MIC IN, LEFT 출력 → 믹서 |
| 교회 믹서 | 보컬 리버브 따로 안 씀. 공간감은 페달이 전부 |

## 기본 설정 (초기화 후 한 번)

| 메뉴 | 값 | 메모 |
|---|---|---|
| Mic Gain 노브 (본체 왼쪽 옆면) | 후렴을 크게 부를 때 윗면 LED 초록, 가끔 주황 | 빨강 금지. 마이크를 쳐서 맞추지 말고 노래로 맞춘다 |
| SETUP → INPUT → Mic Type | DYNAMIC MIC | |
| SETUP → INPUT → Room Sense | AMBIENT/AUTO | 화음 자동 키 인식용 |
| SETUP → INPUT → Tone Style | NORMAL | 잔잔한 부분이 끊기면 NORM NO GATE |
| SETUP → OUTPUT → Output | DUAL MONO | 케이블 하나로 원음+효과 모두 LEFT로 |
| SETUP → GLOBAL → Global Key | OFF | |
| SETUP → SYSTEM → UP/DN Function | SET KEY | ▲▼ 동시에 누르면 키 선택 (루프 대신) |

## 페이버릿 (확정 대기)

| 번호 | 용도 | 상태 |
|---|---|---|
| **01** CHURCH | 장엄한 느린 곡 + HIT 화음 | 직접 만듦 (아래 레시피) |
| **7** GORGEOUS HALL | 느린 곡 | 실제 설정 확인 필요 |
| **160** PLATE VERB+DBL | 내가 화음 파트를 부를 때 | Harmony가 OFF인지 확인 필요 |
| **161** PRACTICE ROOM | 빠른 곡 | 실제 설정 확인 필요. 빠른 곡을 거의 안 부르면 뺀다 |
| **164** BRIGHT VERB | 대부분의 찬양 | 실제 설정 확인 필요 |

- 멘트·기도: HIT 길게 누르기 (TALK 모드). 한 번 더 누르면 복귀
- 예배 전에 GENRE → FAV 선택해 두기. 그래야 ▲▼가 페이버릿 안에서만 움직인다
- 직접 만드는 프리셋은 최대 3개까지만 (외우기 헷갈림 방지). 현재 1개

## 01 CHURCH 레시피

공장 7번을 화면에 띄우고 효과 7페이지를 전부 아래처럼 바꾼 뒤, STORE → 오른쪽 버튼으로 번호 01 → 왼쪽 버튼으로 이름 CHURCH → STORE. 공장 7번은 그대로 남는다.

| 페이지 | Control | Style | 값 |
|---|---|---|---|
| µMod | OFF | | |
| Delay | OFF | | |
| Reverb | ON | ST. JOSEPH CHURCH | Level −13dB, Decay 그대로 |
| Harmony | HIT | LOW & HIGH (펌웨어 2.x는 HIGH & LOW로 보일 수 있음) | Level −12dB, Key ROOMSENSE |
| Double | OFF | | |
| HardTune | OFF | | |
| Transducer | OFF | | |

- 화음 자동 키(ROOMSENSE)는 페달 안 마이크가 건반·기타 소리를 듣고 키를 찾는다. 내 목소리로 찾는 게 아니다
- 리허설 때 HIT로 화음이 맞는지 꼭 확인. 틀리면 ▲▼ 동시에 눌러 키를 직접 지정하거나, 01의 Harmony를 OFF로 바꿔 저장

## 취향 메모

좋아하는 곡: 당신은 영광의 왕, 그 사랑, 예배합니다, 말씀 앞에서, 문들아 머리 들어라, 주님 큰 영광 받으소서, 위대하신 주, 시편 8편, 비 준비하시니, 예수 우리 왕이여(느린 버전)

좋아하는 팀: 아이자야 씩스티원(특히), 어노인팅, 피아워십, 제이어스

공통점: 하나님께 올려드리는 장엄한 선포형 경배곡. 대부분 느린 곡(체감 60~70 BPM)이고, 조용히 시작해 후렴과 마지막 반복에서 크게 터진다. 소리는 장엄한 홀·성당 계열이 맞다.

## 다음 할 일

- [ ] 집에서 공장 초기화 후 7, 160, 161, 164(여유 있으면 9, 162, 165, 181, 203, 206)의 실제 설정을 [`factory-check.md`](factory-check.md) 양식대로 기록
- [ ] 기록을 보고 페이버릿 최종 확정
- [ ] 01 CHURCH 만들고 리허설에서 화음 자동 키 확인

## 참고

- 메인 자료: [VoiceLive Play 매뉴얼 v1.0](https://www.fullcompass.com/common/files/16302-TCHeliconVoiceLivePlayUserManual.pdf)
- 공장 초기화: 전원을 끄고 BACK + STORE를 누른 채 전원을 켠다 (저장한 것 전부 지워짐)
- PC 프로그램 VoiceSupport 2는 Windows 11 미지원으로 알려져 있음. 지원 안 되는 OS에서 펌웨어 업데이트 금지
- 공장 프리셋 전체 목록: [`factory-presets.md`](factory-presets.md)
