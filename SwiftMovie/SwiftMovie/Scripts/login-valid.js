function check()
{
	var username = document.getElementById("username").value;
	var password = document.getElementById("password").value;
    var regu=/^([a-zA-Z0-9]|[._]){4,10}$/;
	
	if(username.length == 0)
	{
		alert("用户名不能为空");
		return false;
	}
	
	if(password.length == 0)
	{
		alert("密码不能为空");
		return false;
	}

    if (!regu.exec(username)) 
    {
        alert("输入错误");
        return false;
    }
	
	
	//if((username.length < 6) || (username.length > 20))
	//{
	//	alert("注册用户名必须在6～20个字符之间")
	//	return false;
	//}
	
}