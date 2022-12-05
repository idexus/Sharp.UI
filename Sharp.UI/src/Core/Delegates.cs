namespace Sharp.UI
{
    public delegate void OnEventAction<TObj,TArgs>(TObj sender, TArgs args);
    public delegate void OnEventAction<TObj>(TObj sender);
}
