using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string filePath = "assignmentFiles.json";
    private DataContainer? dataContainer;
    
    public ICollection<User> Users
    {
        get
        {
            LoadData();// this will check if the data is loaded or not
            return dataContainer!.Users;
        }
    }

    public ICollection<Forum> Forums
    {
        get
        {
            LoadData();
            return dataContainer!.Forums;
        }
    }
    
   

    private void LoadData()
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new()
            {
                Users = new List<User>(),
                Forums = new List<Forum>(),
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    // take the content of the datacontainer and put it into the file
    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);

        dataContainer = null;
    }
}