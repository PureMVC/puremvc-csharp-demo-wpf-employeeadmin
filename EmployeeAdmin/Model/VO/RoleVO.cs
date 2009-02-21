/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
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
