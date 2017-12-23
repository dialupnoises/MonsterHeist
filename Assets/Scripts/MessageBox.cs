using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
	public GameObject MessageBoxPanel;
	public Text TitleLabel;
	public Text BodyLabel;
	public GameObject CoverUp;

	private bool _hasMessage = false;
	private Stack<BoxMessage> _messages = new Stack<BoxMessage>();

	public void OKButton()
	{
		if(_messages.Count > 0)
		{
			var message = _messages.Pop();
			TitleLabel.text = message.Title;
			BodyLabel.text = message.Body;
		}
		else
		{
			_hasMessage = false;
			MessageBoxPanel.SetActive(false);
			CoverUp.SetActive(false);
		}
	}

	public void Show(string title, string body)
	{
		if(!_hasMessage)
		{
			TitleLabel.text = title;
			BodyLabel.text = body;

			MessageBoxPanel.SetActive(true);
			CoverUp.SetActive(true);
			_hasMessage = true;
		}
		else
		{
			_messages.Push(new BoxMessage()
			{
				Title = title,
				Body = body
			});
		}
	}

	private class BoxMessage
	{
		public string Title;
		public string Body;
	}
}