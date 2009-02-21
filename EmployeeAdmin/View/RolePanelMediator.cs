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
	public class RolePanelMediator : Mediator, IMediator
	{
		private RoleProxy roleProxy;
		
		public new const string NAME = "RolePanelMediator";

		public RolePanelMediator(RolePanel viewComponent)
			: base(NAME, viewComponent)
		{
			RolePanel.AddRole += new EventHandler(RolePanel_AddRole);
			RolePanel.RemoveRole += new EventHandler(RolePanel_RemoveRole);
		}

		public override void OnRegister()
		{
			base.OnRegister();
			roleProxy = (RoleProxy) Facade.RetrieveProxy(RoleProxy.NAME);
		}
		
		private RolePanel RolePanel
		{
			get { return (RolePanel) ViewComponent; }
		}

		void RolePanel_RemoveRole(object sender, EventArgs e)
		{
			roleProxy.RemoveRoleFromUser(RolePanel.User, RolePanel.SelectedRole);
		}

		void RolePanel_AddRole(object sender, EventArgs e)
		{
			roleProxy.AddRoleToUser(RolePanel.User, RolePanel.SelectedRole);
		}
		
		public override IList<string> ListNotificationInterests()
		{
			IList<string> list = new List<string>();
			list.Add(ApplicationFacade.NEW_USER);
			list.Add(ApplicationFacade.USER_ADDED);
			list.Add(ApplicationFacade.USER_DELETED);
			list.Add(ApplicationFacade.CANCEL_SELECTED);
			list.Add(ApplicationFacade.USER_SELECTED);
			list.Add(ApplicationFacade.ADD_ROLE_RESULT);
			return list;
		}
		
		public override void HandleNotification(INotification note)
		{
			UserVO user;
			RoleVO role;
			string userName;

			switch (note.Name)
			{
				case ApplicationFacade.NEW_USER:
					RolePanel.ClearForm();
					break;
				case ApplicationFacade.USER_ADDED:
					user = (UserVO) note.Body;
					userName = user == null ? "" : user.UserName;
					role = new RoleVO(userName);
					roleProxy.AddItem(role);
					RolePanel.ClearForm();
					break;
				case ApplicationFacade.USER_UPDATED:
					RolePanel.ClearForm();
					break;
				case ApplicationFacade.USER_DELETED:
					RolePanel.ClearForm();
					break;
				case ApplicationFacade.CANCEL_SELECTED:
					RolePanel.ClearForm();
					break;
				case ApplicationFacade.USER_SELECTED:
					user = (UserVO) note.Body;
					userName = user == null ? "" : user.UserName;
					RolePanel.ShowUser(user, roleProxy.GetUserRoles(userName));
					break;
				case ApplicationFacade.ADD_ROLE_RESULT:
					userName = RolePanel.User == null ? "" : RolePanel.User.UserName;
					RolePanel.ShowUserRoles(roleProxy.GetUserRoles(userName));
					break;
			}
		}
	}
}
