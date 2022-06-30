using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Lab2.Data;

public class DishOfTheWeekRepositary
{
    private const string FileName = "AllDish.json"; // путь к файлу
    private JsonSerializerOptions Options = new JsonSerializerOptions // настройки файла JSon
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        WriteIndented = true
    };

    public DishOfTheWeekRepositary()
    {
        if (!File.Exists(FileName)) // если файл существует
        {
            List<DishOfTheWeek> emptyList = new List<DishOfTheWeek>(); // создаём список
            string jsonString = JsonSerializer.Serialize(emptyList, Options); // в строку записываем пустой список и настройки файла JSon
            File.WriteAllText(FileName, jsonString); // записываем всё
        }
    }

    // После инициализации списка (выше) необходимо заполнить его
    // Заполнение списка
    public IList<DishOfTheWeek> List()
    {
        lock (this) // Блокировка процесса
        {
            // полностью считываем текст из файла в строку
            string jsonString = File.ReadAllText(FileName);
            // С помощью метода "JsonSerializer.Deserialize" переводим из сплошного текста в список
            List<DishOfTheWeek> list = JsonSerializer.Deserialize<List<DishOfTheWeek>>(jsonString);
            // Возвращаем список
            return list; 
        }
    }

    // добавляем новое блюдо
    public void Add(DishOfTheWeek data)
    {
        lock (this)
        {
            data.Id = Guid.NewGuid();
            // Deserialize data from file
            string jsonString = File.ReadAllText(FileName);
            List<DishOfTheWeek> list = JsonSerializer.Deserialize<List<DishOfTheWeek>>(jsonString);
            // Add new data
            list.Add(data);
            // Save updated list to file
            jsonString = JsonSerializer.Serialize(list, Options);
            File.WriteAllText(FileName, jsonString);
        }
    }

    // меняем данныен о блюде
    public void Update(DishOfTheWeek data)
    {
        lock (this)
        {
            // Deserialize data from file
            string jsonString = File.ReadAllText(FileName);
            List<DishOfTheWeek> list = JsonSerializer.Deserialize<List<DishOfTheWeek>>(jsonString);
            // Find data with same id
            int index = list.FindIndex(x => x.Id == data.Id);
            if (index != -1)
            {
                list[index] = data;
                jsonString = JsonSerializer.Serialize(list, Options);
                File.WriteAllText(FileName, jsonString);
            }
            else
            {
                throw new ArithmeticException();
            }
        }
    }

    // удаляем блюдо
    public void Remove(Guid id)
    {
        lock (this)
        {
            // Deserialize data from file
            string jsonString = File.ReadAllText(FileName);
            List<DishOfTheWeek> list = JsonSerializer.Deserialize<List<DishOfTheWeek>>(jsonString);
            // Find data with same id
            int index = list.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                // Remove data row
                list.RemoveAt(index);
                // Save updated list to file
                jsonString = JsonSerializer.Serialize(list, Options);
                File.WriteAllText(FileName, jsonString);
            }
        }
    }
}
