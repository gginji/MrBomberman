using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

public class IOManager 
{
    public string[] getAllFileNamesInFolder(string folder)
    {
        return Directory.GetFiles(folder);
    }

    public void writeHashtable(string path, Hashtable myTable)
    {
        //To write Hashtable on file:
       	
        BinaryFormatter bfw = new BinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Open);
        StreamWriter ws = new StreamWriter(file);
        bfw.Serialize(ws.BaseStream, myTable);
    }

    public Hashtable readHashtable(string path)
    {
        //To read Hashtable from file:

        FileStream file = new FileStream(path, FileMode.OpenOrCreate);
        StreamReader readMap = new StreamReader(file);
        BinaryFormatter bf = new BinaryFormatter();
        return (Hashtable)bf.Deserialize(readMap.BaseStream);
    }

    public void writeTextFile(string text, string path)
    { 
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(text);

        using (StreamWriter outfile = new StreamWriter(path, true))
        {
            outfile.Write(sb.ToString());
        }
    }
}
