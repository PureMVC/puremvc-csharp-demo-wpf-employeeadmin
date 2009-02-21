/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
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
	public class UserFormMediator : Mediator, IMediator
	{
		private UserProxy userProxy;

		public new const string NAME = "UserFormMediator";

		public UserFormMediator(UserForm viewComponent)
			: base(NAME, viewComponent)
		{
			UserForm.AddUser += new EventHandler(UserForm_AddUser);
			UserForm.UpdateUser += new EventHandler(UserForm_UpdateUser);
			UserForm.CancelUser += new EventHandler(UserForm_CancelUser);
		}

		public override void OnRegister()
		{
			base.OnRegister();
			userProxy = (UserProxy) Facade.RetrieveProxy(UserProxy.NAME);
		}

		private UserForm UserForm
		{
			get { return (UserForm) ViewComponent; }
		}

		void UserForm_AddUser(object sender, EventArgs e)
		{
			UserVO user = UserForm.User;
			userProxy.AddItem(user);
			SendNotification(ApplicationFacade.USER_ADDED, user);
			UserForm.ClearForm();
		}

		void UserForm_UpdateUser(object sender, EventArgs e)
		{
			UserVO user = UserForm.User;
			userProxy.UpdateItem(user);
			SendNotification(ApplicationFacade.USER_UPDATED, user);
			UserForm.ClearForm();
		}

		void UserForm_CancelUser(object sender, EventArgs e)
		{
			SendNotification(ApplicationFacade.CANCEL_SELECTED);
			UserForm.ClearForm();
		}

		public override IList<string> ListNotificationInterests()
		{
			IList<string> list = new List<string>();
			list.Add(ApplicationFacade.NEW_USER);
			list.Add(ApplicationFacade.USER_DELETED);
			list.Add(ApplicationFacade.USER_SELECTED);
			return list;
		}

		public override void HandleNotification(INotification note)
		{
			UserVO user;

			switch (note.Name)
			{
				case ApplicationFacade.NEW_USER:
					user = (UserVO) note.Body;
					UserForm.ShowUser(user, UserFormMode.ADD);
					break;

				case ApplicationFacade.USER_DELETED:
					UserForm.ClearForm();
					break;

				case ApplicationFacade.USER_SELECTED:
					user = (UserVO) note.Body;
					UserForm.ShowUser(user, UserFormMode.EDIT);
					break;

			}
		}
	}
}
