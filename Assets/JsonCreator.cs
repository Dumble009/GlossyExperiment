using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System.IO;

public class JsonCreator : MonoBehaviour
{
	public void CreateJson(ConfusionMatrixData cm_Data)
	{
		using (var ms = new MemoryStream())
		{
			using (var sr = new StreamReader(ms))
			{
				var serializer = new DataContractJsonSerializer(typeof(ConfusionMatrixData));
				serializer.WriteObject(ms, cm_Data);
				ms.Position = 0;

				var json = sr.ReadToEnd();

				using (var sw = new StreamWriter(Application.dataPath + "/cm_" + Time.time.ToString()+".json", false, System.Text.Encoding.UTF8))
				{
					sw.Write(json);
				}
			}
		}
	}
}
