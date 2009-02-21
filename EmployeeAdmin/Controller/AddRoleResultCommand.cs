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
using System.Windows;

namespace Demo.PureMVC.EmployeeAdmin.Controller
{
	public class AddRoleResultCommand : SimpleCommand, ICommand
	{
		public override void Execute(INotification notification)
		{
			bool result = (bool) notification.Body;

			if (!result) {
				MessageBox.Show("Role already exists for this user!", "Add User Role");
			}
		}
	}
}
