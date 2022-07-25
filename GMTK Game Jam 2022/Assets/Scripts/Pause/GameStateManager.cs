public class GameStateManager
{
    private static GameStateManager _instance;

    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
    }

    public State CurrentState { get; private set; }

    public delegate void GameStateChanger(State game_state);
    public event GameStateChanger OnStateChange;

    private GameStateManager()
    {

    }

    public void SetState(State NewState)
    {
        if (NewState == CurrentState)
            return;

        CurrentState = NewState;
        OnStateChange?.Invoke(NewState);
    }
}
