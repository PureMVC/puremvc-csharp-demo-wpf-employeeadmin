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

using Demo.PureMVC.EmployeeAdmin.Model.VO;
using Demo.PureMVC.EmployeeAdmin.Model;

namespace Demo.PureMVC.EmployeeAdmin.Controller
{
	public class DeleteUserCommand : SimpleCommand, ICommand
	{
		/// <summary>
		/// retrieve the user and role proxies and delete the user
		/// and his roles. then send the USER_DELETED notification
		/// </summary>
		/// <param name="notification"></param>
		public override void Execute(INotification notification)
		{
			UserVO user = (UserVO) notification.Body;
			UserProxy userProxy = (UserProxy) Facade.RetrieveProxy(UserProxy.NAME);
			RoleProxy roleProxy = (RoleProxy) Facade.RetrieveProxy(RoleProxy.NAME);
			userProxy.DeleteItem(user);
			roleProxy.DeleteItem(user);
			SendNotification(ApplicationFacade.USER_DELETED);
		}
	}
}
