using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SavePlayer(Data d){

		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/playerdata.chris";

		FileStream stream = new FileStream(path, FileMode.Create);
		PlayerData pdata = new PlayerData(d);

		formatter.Serialize(stream, pdata);
		stream.Close();
	}

	public static PlayerData LoadPlayer(){

		string path = Application.persistentDataPath + "/playerdata.chris";

		if(File.Exists(path) == false){
			Debug.LogError("Save file not found in " + path);
			return null;
		}
		else{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();
			return data;
		}


	}
}
