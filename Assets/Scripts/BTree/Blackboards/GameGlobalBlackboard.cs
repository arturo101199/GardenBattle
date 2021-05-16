public class GameGlobalBlackboard : GlobalBlackboard
{
    protected new static GameGlobalBlackboard instance;

    public new static GameGlobalBlackboard Instance { get => instance; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public override void InitializeBlackboard()
    {
        base.InitializeBlackboard();
        AddKeyValue("baseManager", GetComponent<BaseManager>());
        UpdateValue("totalNumberOfCharacters", 200);
    }
}