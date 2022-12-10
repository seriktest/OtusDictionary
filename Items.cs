namespace OtusDictionary;
/// <summary>
/// Наш элемент для хранения пары ключ значение
/// </summary>
public class Items
{
    public string Value { get; private set; }
    public int Key { get; private set; }

    public Items(int key, string value)
    {
        Key = key;
        Value = value;
    }
    
}