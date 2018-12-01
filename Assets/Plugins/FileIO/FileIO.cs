using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileIO
{
    private const char DELIMITER = '/';

    public static void write<T>(T obj, string filename) {
        var path = pathForFile(filename);

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, obj);
        stream.Close();
    }

    public static T read<T>(string filename) {
        var path = pathForFile(filename);

        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            T t = (T)formatter.Deserialize(stream);
            stream.Close();

            return t;
        }
        else
        {
            return default(T);
        }
    }

    public static void write(string str, string filename)
    {
        var path = pathForFile(filename);

        FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(file);
        sw.WriteLine(str);

        sw.Close();
        file.Close();
    }

    public static string read(string filename)
    {
        var path = pathForFile(filename);

        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;

            str = sr.ReadLine();

            sr.Close();
            file.Close();

            return str;
        }
        else
        {
            return null;
        }
    }

    public static void delete(string filename)
    {
        var path = pathForFile(filename);

        if (File.Exists(path))
            File.Delete(path);
    }

    public static bool IsExist(string filename) {
        var path = pathForFile(filename);
        return File.Exists(path);
    }

    private static string pathForFile(string filename)
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.LastIndexOf(DELIMITER));
        return Path.Combine(path, filename);
    }
}
