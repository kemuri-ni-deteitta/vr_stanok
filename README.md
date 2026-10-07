<div align="center">

# VR Stanok

### Учебный Unity-проект для моделирования интерактивной виртуальной сцены

Прототип виртуальной среды на Unity с использованием 3D-сцены, физического движка, коллизий и отображения состояния взаимодействия через TextMesh Pro.

![Unity](https://img.shields.io/badge/Unity-2022.3.9f1-000000?logo=unity&logoColor=white)
![CSharp](https://img.shields.io/badge/C%23-Unity-512BD4?logo=csharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-3D%20%2F%20VR-555555)
![Physics](https://img.shields.io/badge/Unity-Physics-000000?logo=unity&logoColor=white)

</div>

---

## О проекте

`vr_stanok` — учебный проект, разработанный в **Unity** как прототип интерактивной трёхмерной среды, связанной с моделированием виртуального пространства и взаимодействием объектов.

Проект демонстрирует базовые механизмы, которые используются при разработке виртуальных тренажёров и VR-сцен:

- создание трёхмерной сцены;
- работа с объектами Unity;
- использование физического движка;
- настройка `Rigidbody`;
- использование различных типов `Collider`;
- обработка столкновений;
- работа с тегами объектов;
- отображение информации непосредственно внутри 3D-сцены;
- использование TextMesh Pro;
- подготовка Unity-проекта к дальнейшему развитию в направлении VR.

---

# Основная идея

В основе проекта лежит взаимодействие физических объектов Unity.

Общий принцип работы:

```text
3D Scene
    │
    ▼
Physical Objects
    │
    ├── Rigidbody
    │
    └── Collider
    │
    ▼
Collision
    │
    ▼
OnCollisionEnter()
    │
    ▼
Tag validation
    │
    ▼
Collision counter
    │
    ▼
TextMesh Pro
```

При столкновении определённых объектов срабатывает пользовательский C#-скрипт.

Если второй объект имеет необходимый тег, количество столкновений увеличивается, а результат сразу отображается внутри сцены.

---

# Технологический стек

| Технология | Назначение |
|---|---|
| **Unity 2022.3.9f1** | игровой движок и редактор 3D-сцены |
| **C#** | программирование поведения объектов |
| **Unity Physics** | обработка физических взаимодействий |
| **Rigidbody** | физическое поведение объектов |
| **Collider** | обнаружение столкновений |
| **TextMesh Pro** | отображение текста внутри сцены |
| **Terrain** | создание поверхности виртуальной среды |
| **Unity XR modules** | базовые модули Unity для XR |
| **Visual Scripting** | дополнительный Unity package |
| **Timeline** | работа с временными последовательностями |

---

# Версия Unity

Проект создан в:

```text
Unity 2022.3.9f1
```

Файл версии:

```text
ProjectSettings/ProjectVersion.txt
```

Для корректного открытия проекта рекомендуется использовать именно эту или совместимую версию Unity 2022 LTS.

---

# Структура сцены

Основная сцена проекта:

```text
Assets/Scenes/SampleScene.unity
```

В текущей версии в ней присутствуют следующие основные объекты:

```text
SampleScene
│
├── Main Camera
├── Directional Light
├── Terrain
├── Cube
├── Capsule
└── Text (TMP)
```

Каждый объект выполняет отдельную роль в демонстрации.

---

# Main Camera

Стандартная камера Unity отвечает за отображение сцены.

```text
Main Camera
    │
    ▼
Rendering
    │
    ▼
Game View
```

Камера работает в перспективном режиме и используется для просмотра виртуального пространства.

В текущей версии проекта используется стандартная `Main Camera`.

---

# Directional Light

Для освещения сцены используется:

```text
Directional Light
```

Он имитирует удалённый источник света и обеспечивает освещение объектов и Terrain.

---

# Terrain

В проекте присутствует Unity Terrain:

```text
Assets/New Terrain.asset
```

Он используется в качестве основы виртуального окружения.

На объекте Terrain настроен:

```text
TerrainCollider
```

благодаря чему физические объекты могут взаимодействовать с поверхностью.

---

# Физические объекты

В сцене используются два основных объекта для демонстрации физики:

```text
Cube
Capsule
```

Они взаимодействуют при помощи стандартного физического движка Unity.

---

## Cube

Для `Cube` используются:

```text
Rigidbody
BoxCollider
MeshRenderer
MeshFilter
```

На объект назначен специальный tag:

```text
OtherObjectTag
```

Именно этот тег используется скриптом для определения нужного типа столкновения.

---

## Capsule

Для `Capsule` используются:

```text
Rigidbody
CapsuleCollider
MeshRenderer
MeshFilter
```

Кроме стандартных компонентов Unity, к объекту подключён пользовательский C#-скрипт:

```text
TextMeshProCollisionCounter
```

Именно он отвечает за регистрацию столкновений.

---

# Обработка столкновений

Пользовательская логика находится в файле:

```text
Assets/col.cs
```

Главный класс:

```csharp
public class TextMeshProCollisionCounter : MonoBehaviour
```

Он наследуется от:

```csharp
MonoBehaviour
```

и поэтому может быть прикреплён к GameObject в Unity.

---

# Алгоритм работы Collision Counter

Сценарий можно представить следующим образом:

```text
Capsule
   │
   │ Collision
   ▼
Cube
   │
   ▼
OnCollisionEnter()
   │
   ▼
CompareTag("OtherObjectTag")
   │
   ├── false → ничего не происходит
   │
   └── true
        │
        ▼
   counter++
        │
        ▼
   UpdateText()
        │
        ▼
   TextMesh Pro
```

---

# `OnCollisionEnter`

Для обработки столкновения используется стандартный Unity callback:

```csharp
private void OnCollisionEnter(Collision collision)
```

Unity автоматически вызывает этот метод при физическом столкновении объектов.

После этого выполняется проверка:

```csharp
if (collision.gameObject.CompareTag("OtherObjectTag"))
```

Таким образом учитываются только столкновения с объектами, имеющими нужный tag.

---

# Счётчик столкновений

В классе хранится:

```csharp
private int counter = 0;
```

При обнаружении подходящего столкновения:

```csharp
counter++;
```

После чего текст обновляется:

```csharp
UpdateText();
```

---

# Отображение результата

Для отображения количества столкновений используется:

```text
TextMesh Pro
```

Ссылка на компонент хранится:

```csharp
public TextMeshPro textMeshPro;
```

Текст обновляется следующим образом:

```csharp
textMeshPro.text = "Count: " + counter;
```

На экране получается значение вида:

```text
Count: 0
```

после первого столкновения:

```text
Count: 1
```

затем:

```text
Count: 2
```

и так далее.

---

# Полная логика скрипта

Основной алгоритм пользовательской части проекта:

```csharp
private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("OtherObjectTag"))
    {
        counter++;

        UpdateText();

        Debug.Log(
            "Collision occurred with object tagged as OtherObjectTag"
        );
    }
}
```

Такое разделение позволяет использовать стандартный событийный механизм Unity вместо ручной проверки пересечений объектов каждый кадр.

---

# Использование тегов

Для идентификации объекта используется Unity Tag System.

В сцене объект:

```text
Cube
```

имеет тег:

```text
OtherObjectTag
```

Скрипт не зависит от конкретного имени объекта:

```csharp
collision.gameObject.name
```

вместо этого используется:

```csharp
CompareTag("OtherObjectTag")
```

Это позволяет привязать одну и ту же логику сразу к нескольким объектам.

Например:

```text
Object A ──┐
Object B ──┼── OtherObjectTag
Object C ──┘
```

Все они смогут участвовать в одной логике столкновений.

---

# Unity Physics

Для возникновения события:

```csharp
OnCollisionEnter()
```

объекты должны иметь корректно настроенные физические компоненты.

В текущей сцене используются:

```text
Cube
├── BoxCollider
└── Rigidbody

Capsule
├── CapsuleCollider
└── Rigidbody
```

Unity Physics определяет пересечение Collider-компонентов и передаёт информацию о столкновении в:

```csharp
Collision collision
```

---

# Rigidbody

`Rigidbody` подключает GameObject к физическому движку Unity.

Он позволяет учитывать:

- массу;
- скорость;
- ускорение;
- гравитацию;
- физические столкновения;
- вращение;
- импульсы.

Например, у `Cube` включена:

```text
Use Gravity = true
```

поэтому объект подчиняется гравитации.

---

# Collider

Collider задаёт физическую форму объекта.

Используются:

```text
Cube
    ↓
BoxCollider
```

и:

```text
Capsule
    ↓
CapsuleCollider
```

Collider может отличаться от визуальной геометрии объекта и используется непосредственно физическим движком.

---

# TextMesh Pro

TextMesh Pro используется для вывода информации прямо в виртуальном пространстве.

Объект:

```text
Text (TMP)
```

связан со скриптом:

```text
TextMeshProCollisionCounter
```

через публичное поле:

```csharp
public TextMeshPro textMeshPro;
```

Связь выглядит так:

```text
Capsule
│
└── TextMeshProCollisionCounter
          │
          ▼
      Text (TMP)
          │
          ▼
       Count: N
```

---

# Архитектура взаимодействия

Общая структура реализованной механики:

```text
             Unity Scene
                 │
       ┌─────────┴─────────┐
       │                   │
       ▼                   ▼
    Capsule               Cube
       │                   │
Rigidbody             Rigidbody
       │                   │
CapsuleCollider       BoxCollider
       │                   │
       └─────────┬─────────┘
                 │
             Collision
                 │
                 ▼
     TextMeshProCollisionCounter
                 │
                 ▼
            counter++
                 │
                 ▼
            TextMesh Pro
                 │
                 ▼
             Count: N
```

---

# Структура проекта

Основные файлы и директории:

```text
vr_stanok/
│
├── Assets/
│   ├── Scenes/
│   │   └── SampleScene.unity
│   │
│   ├── TextMesh Pro/
│   ├── New Terrain.asset
│   └── col.cs
│
├── Packages/
│   └── manifest.json
│
├── ProjectSettings/
│   ├── ProjectSettings.asset
│   └── ProjectVersion.txt
│
├── UserSettings/
├── Library/
├── Logs/
│
├── Assembly-CSharp.csproj
├── My project.sln
└── my_archive.zip
```

---

# Основные файлы

## `Assets/Scenes/SampleScene.unity`

Основная Unity-сцена проекта.

Содержит:

- камеру;
- освещение;
- Terrain;
- физические объекты;
- TextMesh Pro;
- пользовательский компонент обработки столкновений.

---

## `Assets/col.cs`

Основной пользовательский C#-скрипт проекта.

Отвечает за:

```text
обнаружение столкновения
        ↓
проверку тега
        ↓
увеличение счётчика
        ↓
обновление текста
```

---

## `Assets/New Terrain.asset`

Данные Unity Terrain, используемого в качестве виртуальной поверхности сцены.

---

## `Packages/manifest.json`

Содержит список Unity packages, используемых проектом.

Среди них:

```text
TextMesh Pro
Timeline
Visual Scripting
UGUI
Unity Physics modules
Terrain
VR module
XR module
```

---

# VR / XR

В проекте присутствуют стандартные Unity-модули:

```text
com.unity.modules.vr
com.unity.modules.xr
```

Это означает наличие базовой поддержки VR/XR со стороны Unity Engine.

При этом в текущем состоянии основной сцены не настроены отдельные компоненты вроде:

```text
XR Origin
XR Controller
XR Interaction Manager
XR Ray Interactor
```

и не подключён отдельный `XR Interaction Toolkit`.

Поэтому текущую версию проекта корректнее рассматривать как **3D-прототип и основу для дальнейшего VR-тренажёра**, а не как завершённое VR-приложение.

---

# Запуск проекта

## Требования

Рекомендуемая версия:

```text
Unity 2022.3.9f1
```

Также потребуется:

```text
Unity Hub
```

---

## Клонирование репозитория

```bash
git clone https://github.com/kemuri-ni-deteitta/vr_stanok.git
```

Перейти в директорию:

```bash
cd vr_stanok
```

---

# Открытие через Unity Hub

В Unity Hub:

```text
Projects
    ↓
Add / Open
    ↓
выбрать папку vr_stanok
```

Для открытия желательно использовать:

```text
Unity 2022.3.9f1
```

После импорта проекта открыть:

```text
Assets/Scenes/SampleScene.unity
```

---

# Запуск сцены

После открытия `SampleScene`:

```text
Unity Editor
    ↓
SampleScene
    ↓
Play
```

Unity запустит симуляцию физики.

Во время столкновения `Capsule` с объектом, имеющим тег:

```text
OtherObjectTag
```

значение TextMesh Pro будет увеличиваться:

```text
Count: 0
    ↓
Count: 1
    ↓
Count: 2
    ↓
...
```

---

# Debug Logging

При успешном столкновении скрипт также выводит сообщение в Unity Console:

```text
Collision occurred with object tagged as OtherObjectTag
```

Это позволяет одновременно контролировать событие:

```text
визуально через TextMesh Pro
```

и:

```text
через Unity Console
```

---

# Развитие проекта

Текущая архитектура может использоваться как основа для дальнейшего развития виртуального тренажёра.

Например:

```text
Current 3D Prototype
        │
        ▼
XR Interaction Toolkit
        │
        ▼
XR Origin
        │
        ├── Headset
        ├── Left Controller
        └── Right Controller
        │
        ▼
Interactive Machine
        │
        ├── Buttons
        ├── Levers
        ├── Machine parts
        └── Tools
        │
        ▼
Training Scenario
```

В дальнейшем можно реализовать:

- взаимодействие с деталями станка;
- VR-контроллеры;
- захват предметов;
- кнопки и рычаги;
- последовательность выполнения технологической операции;
- проверку правильности действий пользователя;
- счётчик ошибок;
- систему подсказок;
- виртуальную панель управления;
- сценарии обучения;
- систему оценки результата.

---

# Что демонстрирует проект

С технической точки зрения проект показывает работу со следующими механизмами Unity:

```text
GameObjects
Components
MonoBehaviour
Rigidbody
Collider
Collision Events
Tags
Terrain
TextMesh Pro
3D Scene
C# Scripts
```

Главная пользовательская механика построена вокруг событийного взаимодействия физических объектов:

```text
Physical interaction
        │
        ▼
Collision Event
        │
        ▼
Application Logic
        │
        ▼
State Change
        │
        ▼
Visual Feedback
```

Такой принцип является базовым для большого количества интерактивных систем, включая виртуальные тренажёры.

---

# Текущее состояние

| Возможность | Состояние |
|---|---|
| Unity 3D-сцена | Реализовано |
| Terrain | Реализовано |
| Физические объекты | Реализовано |
| Rigidbody | Реализовано |
| Collider interaction | Реализовано |
| Collision event handling | Реализовано |
| Collision counter | Реализовано |
| TextMesh Pro output | Реализовано |
| Tag-based interaction | Реализовано |
| XR modules | Присутствуют |
| XR Interaction Toolkit | Не настроен |
| XR Origin | Не настроен в текущей сцене |
| VR-контроллеры | Не реализованы в текущей сцене |
| Полный тренажёр станка | Основа для дальнейшего развития |

---

# Примечание о структуре репозитория

В репозитории также находятся:

```text
Library/
Logs/
UserSettings/
my_archive.zip
```

`Library`, `Logs` и большая часть `UserSettings` являются автоматически создаваемыми Unity файлами и обычно не требуются для хранения исходного проекта в Git.

Для Unity-проекта основными переносимыми директориями являются:

```text
Assets/
Packages/
ProjectSettings/
```

При дальнейшем развитии проекта рекомендуется использовать стандартный Unity `.gitignore` и не хранить автоматически генерируемую директорию:

```text
Library/
```

Это значительно уменьшает размер репозитория и упрощает работу с Git.

---

# Основная идея проекта

Проект демонстрирует создание интерактивной трёхмерной среды в Unity, где физическое взаимодействие объектов становится событием для прикладной логики.

```text
3D Environment
      │
      ▼
Physics Simulation
      │
      ▼
Object Interaction
      │
      ▼
Collision Detection
      │
      ▼
C# Logic
      │
      ▼
Visual Feedback
```

Такая архитектура может использоваться как основа для разработки более сложной виртуальной среды или учебного VR-тренажёра для взаимодействия с промышленным оборудованием.

---

<div align="center">

### Unity Interactive 3D Prototype

**Unity · C# · Physics · Colliders · TextMesh Pro · VR/XR Foundation**

</div>
