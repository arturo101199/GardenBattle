public class GameGlobalBlackboard : GlobalBlackboard
{
    protected new static GameGlobalBlackboard instance;

    public new static GameGlobalBlackboard Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    protected override void initializeBlackboard()
    {
        base.initializeBlackboard();
        AddKeyValue("baseManager", GetComponent<BaseManager>());
        UpdateValue("totalNumberOfCharacters", 150);
    }
}