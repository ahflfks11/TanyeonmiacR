﻿using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
//using PACKETS;

public class SocketCreate : MonoBehaviour {
	struct Packet
	{
		public int type;
		public int packetsize;
	};

	InputField nickCreate;
	Packet packet = new Packet();
	Socket clientSock=null;
	string mycharacter;
	byte[] msg;
	float time;
	float a;


	//PACKETS.PacketQueue packetInfo = new PACKETS.PacketQueue ();
	public float _value {
		get {
			return a;
		}
	}
	//clientSock.Connect(endPoint);
	// Use this for initialization
	void Start () {
		msg = new byte[1024];
		nickCreate = GameObject.Find ("CreateName").GetComponent<InputField> ();
		clientSock = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPAddress serverIPaddr = Dns.GetHostAddresses ("192.168.94.85") [0];
		IPEndPoint endPoint = new IPEndPoint (serverIPaddr, 9800);

		try{
			clientSock.Connect (endPoint);
		}catch{
			Debug.Log("No Server");
		}
	}

	public void SendPacketString(short _size, string _data){
		short size = _size;
		short typeNum = 1;
		string data = _data;
		byte[] header = new byte[2];
		header[0] = (byte)size;
		header[1] = (byte)typeNum;
		//byte[] type = BitConverter.GetBytes(typeNum);
		byte[] body = Encoding.Unicode.GetBytes(data);

		byte[] packet = new byte[body.Length+header.Length];  

		System.Array.Copy(header, 0, packet, 0, header.Length);
		System.Array.Copy(body, 0, packet, header.Length, body.Length);

		clientSock.Send (packet);
	}

	public void SendPacketFloat(short _size, float _data){
		short size = _size;
		short typeNum = 2;
		float data = _data;
		byte[] header = new byte[2];
		header[0] = (byte)size;
		header[1] = (byte)typeNum;
		//byte[] type = BitConverter.GetBytes(typeNum);
		byte[] body = BitConverter.GetBytes (data);

		byte[] packet = new byte[body.Length+header.Length];  

		System.Array.Copy(header, 0, packet, 0, header.Length);
		System.Array.Copy(body, 0, packet, header.Length, body.Length);

		clientSock.Send (packet);
	}

	public int ReceiveHead(byte[] msg){

		int headLength = 0;

		headLength = clientSock.Receive (msg, 0, 2, SocketFlags.None);

		packet.packetsize = msg [0];

		packet.type = msg [1];

		return packet.packetsize;
	}

	public void ReceiveBody(byte[] msg, int bodyLength){

		int readLength = 0;

		readLength = clientSock.Receive (msg, 0,msg.Length,SocketFlags.None);

		if (packet.type == 0) {
			return;
		} else if (packet.type == 1) {
			string message = Encoding.Unicode.GetString (msg, 0, readLength);
			//stringText.text = ""+message;
		} else if (packet.type == 2) {
			a = BitConverter.ToSingle (msg, 0);
			//floatText.text = ""+a;
		}

		packet.type = 0;
	}

	public void CreateNick(){
		string nick = nickCreate.text;
		short size = (short)nick.Length;
		SendPacketString (size,nick);
		SceneManager.LoadScene (1);
	}
	// Update is called once per frame
	void Update () {
		DontDestroyOnLoad (this);
		if (clientSock != null) {
			if (Input.GetButtonDown("Horizontal")) {
				float value = Input.GetAxis ("Horizontal");
				SendPacketFloat (sizeof(float),Input.GetAxisRaw ("Horizontal"));
			}

			if (Input.GetKeyDown(KeyCode.Space)){
				
			}
		}

		if (clientSock.Available != 0) {
			int bodyLength = ReceiveHead(msg);
			ReceiveBody (msg, bodyLength);
		}
	}
}