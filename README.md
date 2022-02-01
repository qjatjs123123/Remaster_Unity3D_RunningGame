# Remaster_Unity3D_RunningGame

## 게임 소개
----------
1인 프로젝트로서, 기존 개발했던 장애물 달리기 게임인 'Unity3D_RunningGame(SHOTGUN)'의 게임의 그래픽요소, 트랩 등을 개선하였다. 개발 플랫폼은 PC Window이며 개발환경은 "Unity3d 2020.3.8f1"버전을 사용하였다. 예능 프로그램 '출발, 드림팀'과 'ALT F4'게임을 모티브로 하여 플레이어가 맵에 배치된 여러 장애물들을 통과하여 골인지점에 도착하는 게임이다.

## 스토리
----------
게임의 주인공인 'Bandit'은 트레저헌터이다. 그는 어느날 숲속에 숨겨진 유적지에 엄청난 보물이 있다는 소식을 듣게 된다. 그는 보물을 찾기 위해 거대한 숲으로 들어갔다. 
숲속에는 누군가 설치한 온갖 함정들이 존재하였는데, 그는 이러한 함정들을 헤쳐나가며, 보물을 찾기 위해 노력한다.

## 조작 방법
----------
W:위, S:아래, A:왼쪽, D:오른쪽, SPACEBAR:점프, SHIFT:달리기, ESC:메뉴바

## 프로젝트 추진 일정
----------
![추진일정](https://user-images.githubusercontent.com/74814641/151950918-aec479ea-88c5-424d-b7ee-0deb8b0dd595.JPG)
프로젝트 개발기간은 총 14일이다.


## 기존 Unity3D_RunningGame과의 변경사항
### 1. 트랩추가
#### 1_1 .암산을 요구하는 장애물
![트랩0](https://user-images.githubusercontent.com/74814641/151953977-203eb8d8-01a1-4996-b0f4-f538cae70d26.gif)
트랩에 있는 식과 맞지 않는 문으로 가게 될 경우 죽게 된다.

----------
#### 1_2. 캐릭터 거리에 따라 움직이는 창 트랩
![트랩1](https://user-images.githubusercontent.com/74814641/151955201-cb29f2b6-1455-4112-ac4a-a96c32a9bb6e.gif)
캐릭터에 거리에 맞게 트랩이 움직인다. 트랩에서 발사된 창에 맞게 될 경우 죽게 된다.

----------
#### 1_3. 톱 트랩
![트랩2](https://user-images.githubusercontent.com/74814641/151955914-c034e9f9-10f0-40ce-8590-04ccf4ab2e8b.gif)
왕복 운동하는 톱 트랩에 맞게 될 경우 캐릭터는 죽게 된다.

----------
#### 1_4. 식인 고래
![트랩3](https://user-images.githubusercontent.com/74814641/151956632-b26847ad-2ebc-45c8-936e-a3531776605b.gif)
캐릭터가 특정 위치에 통과하면 식인 고래가 나타난다. 캐릭터가 식인 고래에 맞게 되면 죽게된다.

----------
#### 1_5. 움직이는 대포
![트랩4](https://user-images.githubusercontent.com/74814641/151957440-ff1da502-2ad1-4735-9a26-3cd63de26931.gif)
일정거리 왕복 운동하는 대포에서 대포알이 발사 된다. 대포알에 맞게 되면 캐릭터는 죽게 된다.

----------
#### 1_6. 창 트랩
![트랩5](https://user-images.githubusercontent.com/74814641/151960737-72b50dba-a6d3-408f-b64b-45a9d097aac4.gif)
창 트랩에 맞게 되면 죽게 된다.

----------
### 2. 트랩 디자인 변경
#### 2_1 통돌이 트랩 디자인
![통돌이](https://user-images.githubusercontent.com/74814641/151961995-3bac12af-66f6-46cf-a300-744990d69acb.gif)기존  ->   변경![트랩6](https://user-images.githubusercontent.com/74814641/151962445-bfee6ffc-ac00-475b-9dde-ac271410f5e1.gif)

----------
### 3. 맵 디자인 변경
#### 3_1. 타이틀 화면
![타이틀](https://user-images.githubusercontent.com/74814641/151963711-60a5b75b-5d45-4bf3-8535-dbd97fc5c7d0.png)

#### 3_2. 리스폰 지역
![리스폰 지역](https://user-images.githubusercontent.com/74814641/151964282-3e7fa90a-dfab-4899-b322-a7a6a007e9fd.png)

#### 3_3. 다리 지역
![다리](https://user-images.githubusercontent.com/74814641/151964505-5f4f5216-bb34-4753-9bb9-29a0b3cde6e3.png)

#### 3_4. 평지 지역
![평지](https://user-images.githubusercontent.com/74814641/151964625-ae455d9b-b0bf-42f0-aab5-297a66c3177b.png)

#### 3_5. 성 지역
![성](https://user-images.githubusercontent.com/74814641/151964818-9f0b7d5a-000d-4d58-a22e-2572fb90963d.png)

#### 3_6. 유적지 지역
![유적지](https://user-images.githubusercontent.com/74814641/151965010-fce55580-c1ee-4e96-ae76-6fa43934f8b8.png)



