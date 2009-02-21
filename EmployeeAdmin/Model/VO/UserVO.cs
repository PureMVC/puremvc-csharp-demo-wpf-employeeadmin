/* 
	PureMVC CSharp / WPF / EmployeeAdmin Demo - Login
	By Andy Adamczak <andy.adamczak@puremvc.org>
	Copyright(c) 2009 Andy Adamczak, Some rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Demo.PureMVC.EmployeeAdmin.Model.Enum;

namespace Demo.PureMVC.EmployeeAdmin.Model.VO
{
	public class UserVO
	{
		public UserVO()
		{
		}

		public UserVO(string uname, string fname, string lname, string email, string password, DeptEnum department)
		{
			if (uname != null) m_userName = uname;
			if (fname != null) m_firstName = fname;
			if (lname != null) m_lastName = lname;
			if (email != null) m_email = email;
			if (password != null) m_password = password;
			if (department != null) m_department = department;
		}

		public string UserName
		{
			get { return m_userName; }
		}
		private string m_userName = "";

		public string FirstName
		{
			get { return m_firstName; }
		}
		private string m_firstName = "";

		public string LastName
		{
			get { return m_lastName; }
		}
		private string m_lastName = "";

		public string Email
		{
			get { return m_email; }
		}
		private string m_email = "";

		public string Password
		{
			get { return m_password; }
		}
		private string m_password = "";

		public DeptEnum Department
		{
			get { return m_department; }
		}
		private DeptEnum m_department = DeptEnum.NONE_SELECTED;

		public bool IsValid
		{
			get { return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && Department != DeptEnum.NONE_SELECTED; }
		}

		public string GivenName
		{
			get { return LastName + ", " + FirstName; }
		}
	}
}
