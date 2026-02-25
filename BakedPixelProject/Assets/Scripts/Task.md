Ты — Unity/C# инженер. Работай в существующем проекте (не придумывай новый).
В проекте уже есть базовый UI-слой: IView и IPresenter, а также базовые реализации View и Presenter<TView>.
Твоя задача — привести все экранные пары (View/Presenter) к единому паттерну и вынести создание презентеров в фабрики.

ЦЕЛЬ
1) Для КАЖДОГО конкретного View и Presenter:
    - Должна быть своя абстракция (интерфейс) вида I<Feature><Screen>View : IView и I<Feature><Screen>Presenter : IPresenter.
    - View должен наследоваться от базового View и реализовывать свой интерфейс.
    - Presenter должен наследоваться от Presenter<TView> и реализовывать свой интерфейс.
    - Presenter подписывается/отписывается на события View строго в Activate/Deactivate.
    - View добавляет/удаляет listeners строго в OnActivate/OnDeactivate.

2) Создание ВСЕХ презентеров вынести в фабрики:
    - Каждая фабрика создаёт один презентер или семейство близких презентеров (если так логично по проекту).
    - Фабрики должны находиться строго в папке:
      UI/GameplayMenu/Factories
    - Фабрики должны быть интерфейсами + реализациями (например IAbilityTestPresenterFactory / AbilityTestPresenterFactory).
    - Фабрики используют DI (если проект использует VContainer/контейнер — внедряй зависимости через конструктор и [Inject] где уместно).
    - Презентер создаётся фабрикой, а не напрямую new в игровых MonoBehaviour/инициализаторах.

ПРАВИЛА КАЧЕСТВА
- Не менять публичные контракты поведения UI (события должны продолжать срабатывать как раньше).
- Не добавляй лишние зависимости в View: View содержит только Unity UI элементы и события (event Action/Action<T>), без логики домена/сервисов.
- В Presenter не должно быть ссылок на конкретный MonoBehaviour-класс View, только на интерфейс I...View.
- Имена придерживать по шаблону:
  View: <Feature><Panel/Window/Widget> : View, I<Feature><Panel/Window/Widget>
  Presenter: <Feature><Panel/Window/Widget>Presenter : Presenter<I...>, I...Presenter
- Исправляй очевидные баги подписок:
  В OnDeactivate должны быть RemoveListener (не AddListener).
  Проверяй симметрию подписок/отписок.

ПРИМЕР ЦЕЛЕВОГО РЕЗУЛЬТАТА (ориентир)
- IAbilityTestPanel : IView (события)
- AbilityTestPanel : View, IAbilityTestPanel (Unity элементы + прокидывание событий)
- IAbilityTestPresenter : IPresenter (методы при необходимости)
- AbilityTestPresenter : Presenter<IAbilityTestPanel>, IAbilityTestPresenter (подписки в Activate/Deactivate)
- IAbilityTestPresenterFactory и AbilityTestPresenterFactory в UI/GameplayMenu/Factories

ЧТО НУЖНО СДЕЛАТЬ ПО ПРОЕКТУ
A) Найди все существующие View и Presenter.
B) Для каждой пары внедри описанную выше абстракцию:
- создай интерфейсы I...View и I...Presenter (если их нет),
- обнови классы чтобы они их реализовывали,
- приведи подписки к стандарту Activate/Deactivate и OnActivate/OnDeactivate.
  C) Добавь фабрики для создания презентеров в UI/GameplayMenu/Factories:
- вынеси логику сборки презентера (включая все зависимости) в фабрики,
- обнови места, где презентеры создаются/инициализируются, чтобы они брались из фабрик.
  D) Соблюдай стиль проекта: неймспейсы по папкам, readonly поля, минимальные изменения, без лишних усложнений.
  E) После изменений проект должен компилироваться без ошибок.

ВЫВОД
- Внеси изменения прямо в существующие файлы.
- Добавь новые файлы интерфейсов и фабрик там, где нужно.
- Если находишь несколько мест создания презентеров — все переведи на фабрики.
- Не оставляй “TODO”, сделай законченно.

Начинай выполнение.