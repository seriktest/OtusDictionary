namespace OtusDictionary;

public class Map
{
    /// <summary>
    /// Изначальный массив элементов
    /// </summary>
    /// 
    private  Items[] _array;
    
    /// <summary>
    /// Размерность по умолчанию
    /// </summary>
    /// 
    private int _size = 32;

    public Map() => _array = new Items[_size];

    /// <summary>
    /// Индексатор работающий на методах добавления и получения элемента
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public string this[int i]
    {
        get => Get(i);
        set => Add(i, value);
    }

    /// <summary>
    /// Добавляем элемент и при коллизии увеличиваем массив в 2 раза с пересчетом хешей
    /// для вставки в новый массив
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <param name="value">Значение</param>
    public void Add(int key, string value)
    {
        if(value == null)
            return;
        
        if (_array[Hash(key)] != null)
        {
            var newArray = Resize(2 * _size);
            foreach (var items in _array)
            {
                if (items != null)
                {
                    newArray[Hash(items.Key)] = items;
                }
            }
            _array = newArray;
        }else
            _array[Hash(key)] = new Items(key, value);

    }

    /// <summary>
    /// Возвращаем значение элемента из массива
    /// </summary>
    /// <param name="key">Ключ</param>
    /// <returns></returns>
    public string Get(int key)
    {
        var item = _array[Hash(key)];
        return item.Value;
    }

    /// <summary>
    /// Возвращает массив удвоенной длины
    /// </summary>
    /// <param name="size">новый размер</param>
    /// <returns></returns>
    private Items[] Resize(int size)
    {
        var newArray = new Items[size];
        _size = size;
        return newArray;
    }

    /// <summary>
    /// Вычисляет индекс массива для элемента
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int Hash(int key)
    {
        return (key.GetHashCode() & 0x7ffffff) % _size;
    }
}