public class GlobalBlackboard : Blackboard
{
    protected static GlobalBlackboard instance;

    public static GlobalBlackboard Instance { get => instance; }

    public override void InitializeBlackboard()
    {
        AddKeyValue("totalNumberOfCharacters", 0);
    }
}
