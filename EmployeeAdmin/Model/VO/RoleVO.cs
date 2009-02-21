/* 
	PureMVC CSharp / WPF / EmployeeAdmin Demo - Login
	By Andy Adamczak <andy.adamczak@puremvc.org>
	Copyright(c) 2009 Andy Adamczak, Some rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using Demo.PureMVC.EmployeeAdmin.Model.Enum;

namespace Demo.PureMVC.EmployeeAdmin.Model.VO
{
	public class RoleVO
	{
		public RoleVO(string username)
		{
			if (username != null) m_userName = username;
		}

		public RoleVO(string username, RoleEnum[] roles)
			: this(username)
		{
			if (roles != null)
			{
				foreach (RoleEnum role in roles)
				{
					m_roles.Add(role);
				}
			}
		}

		public RoleVO(string username, IList<RoleEnum> roles)
		{
			if (username != null) m_userName = username;
			
			if (roles != null)
			{
				foreach (RoleEnum role in roles)
				{
					m_roles.Add(role);
				}
			}
		}

		public string UserName
		{
			get { return m_userName; }
		}
		private string m_userName = "";

		public IList<RoleEnum> Roles
		{
			get { return m_roles; }
		}
		private ObservableCollection<RoleEnum> m_roles = new ObservableCollection<RoleEnum>();
	}
}
