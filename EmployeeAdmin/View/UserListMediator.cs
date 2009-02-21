/* 
	PureMVC CSharp / WPF / EmployeeAdmin Demo - Login
	By Andy Adamczak <andy.adamczak@puremvc.org>
	Copyright(c) 2009 Andy Adamczak, Some rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PureMVC.Patterns;
using PureMVC.Interfaces;

using Demo.PureMVC.EmployeeAdmin.Model;
using Demo.PureMVC.EmployeeAdmin.View.Components;
using Demo.PureMVC.EmployeeAdmin.Model.VO;

namespace Demo.PureMVC.EmployeeAdmin.View
{
	public class UserListMediator : Mediator, IMediator
	{
		private UserProxy userProxy;

		public new const string NAME = "UserListMediator";

		public UserListMediator(UserList userList)
			: base(NAME, userList)
		{
			userList.NewUser += new EventHandler(userList_NewUser);
			userList.DeleteUser += new EventHandler(userList_DeleteUser);
			userList.SelectUser += new EventHandler(userList_SelectUser);
		}

		public override void OnRegister()
		{
			base.OnRegister();
			userProxy = (UserProxy) Facade.RetrieveProxy(UserProxy.NAME);
			UserList.LoadUsers(userProxy.Users);
		}

		private UserList UserList
		{
			get { return (UserList) ViewComponent; }
		}

		void userList_NewUser(object sender, EventArgs e)
		{
			UserVO user = new UserVO();
			SendNotification(ApplicationFacade.NEW_USER, user);
		}

		void userList_DeleteUser(object sender, EventArgs e)
		{
			SendNotification(ApplicationFacade.DELETE_USER, UserList.SelectedUser);
		}

		void userList_SelectUser(object sender, EventArgs e)
		{
			SendNotification(ApplicationFacade.USER_SELECTED, UserList.SelectedUser);
		}

		public override IList<string> ListNotificationInterests()
		{
			IList<string> list = new List<string>();
			list.Add(ApplicationFacade.CANCEL_SELECTED);
			list.Add(ApplicationFacade.USER_UPDATED);
			return list;
		}

		public override void HandleNotification(INotification note)
		{
			switch (note.Name)
			{
				case ApplicationFacade.CANCEL_SELECTED:
					UserList.Deselect();
					break;

				case ApplicationFacade.USER_UPDATED:
					UserList.Deselect();
					break;
			}
		}
	}
}
