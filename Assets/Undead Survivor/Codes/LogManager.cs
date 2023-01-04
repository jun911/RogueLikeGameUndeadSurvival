using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using UnityEngine;

public class LogManager : MonoBehaviour
{
    private string _path;

	#region Constructors
	public LogManager(string path)
	{
		_path = path;
		_SetLogPath();
	}

	public LogManager() 
		: this("D:\\01.Dev\\UnityLog\\")
	{
	}
	#endregion

	private void _SetLogPath()
	{
        if (!Directory.Exists(_path))
		{
			Directory.CreateDirectory(_path);
		}

		string logFile = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

		_path = Path.Combine(_path, logFile);
	}

	#region Methods
	public void Write(string data)
	{
		using (StreamWriter writer = new StreamWriter(_path, false))
		{
            data += DateTime.Now.ToString("yyyy-MM-dd") + ": ";

            writer.Write(data);
		}
	}

	public void WriteLine(string data)
	{
		using (StreamWriter writer = new StreamWriter(_path, false))
		{
            writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss\t")} {data}");
		}
	} 
	#endregion
}
