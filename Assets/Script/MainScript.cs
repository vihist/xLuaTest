using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class TestClass
{
	public int a;
	public void inc()
	{
		a++;
	}
}

public class MainScript : MonoBehaviour
{

	[CSharpCallLua]
	public interface ItfOption
	{
		string op1 { get; }
		string op2 { get; }
		string op3 { get; }
		string op4 { get; }
		string op5 { get; }
		int process(string op);
	}



	// Use this for initialization
	LuaEnv luaenv = null;
	// Use this for initialization
	void Start()
	{
		luaenv = new LuaEnv();
		luaenv.DoString("require 'event'");

		Debug.Log("title = " + luaenv.Global.Get<string>("title"));
		Debug.Log("desc = " + luaenv.Global.Get<string>("desc"));
		ItfOption d3 = luaenv.Global.Get<ItfOption>("option");
		Debug.Log("op1 = " + d3.op1);
		Debug.Log("op2 = " + d3.op2);
		Debug.Log("op3 = " + d3.op3);
		Debug.Log("op4 = " + d3.op4);
		Debug.Log("op4 = " + d3.op4);
		Debug.Log("process = " + d3.process(d3.op1));
		//Debug.Log("_G.c = " + luaenv.Global.Get<bool>("c"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
