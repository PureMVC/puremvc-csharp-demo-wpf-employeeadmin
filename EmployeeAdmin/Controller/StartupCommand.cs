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
using Demo.PureMVC.EmployeeAdmin.View;

namespace Demo.PureMVC.EmployeeAdmin.Controller
{
	public class StartupCommand : SimpleCommand, ICommand
	{
		/// <summary>
		/// Register the Proxies and Mediators.
		/// 
		/// Get the View Components for the Mediators from the app,
		/// which passed a reference to itself on the notification.
		/// </summary>
		/// <param name="note"></param>
		public override void Execute(INotification note)
		{
			Facade.RegisterProxy(new UserProxy());
			Facade.RegisterProxy(new RoleProxy());

			MainWindow window = (MainWindow) note.Body;
			Facade.RegisterMediator(new UserFormMediator(window.userForm));
			Facade.RegisterMediator(new UserListMediator(window.userList));
			Facade.RegisterMediator(new RolePanelMediator(window.rolePanel));
		}
	}
}
