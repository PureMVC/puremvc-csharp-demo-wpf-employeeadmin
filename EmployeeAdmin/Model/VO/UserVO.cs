/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
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
