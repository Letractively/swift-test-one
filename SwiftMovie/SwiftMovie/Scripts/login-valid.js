function check()
{
	var username = document.getElementById("username").value;
	var password = document.getElementById("password").value;
	
	if(username.length == 0)
	{
		alert("�û�������Ϊ��");
		return false;
	}
	
	if(password.length == 0)
	{
		alert("���벻��Ϊ��");
		return false;
	}

	
	
	//if((username.length < 6) || (username.length > 20))
	//{
	//	alert("ע���û���������6��20���ַ�֮��")
	//	return false;
	//}
	
}