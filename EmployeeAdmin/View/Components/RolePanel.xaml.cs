/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Demo.PureMVC.EmployeeAdmin.Model.Enum;
using Demo.PureMVC.EmployeeAdmin.Model.VO;

namespace Demo.PureMVC.EmployeeAdmin.View.Components
{
	/// <summary>
	/// Interaction logic for RolePanel.xaml
	/// </summary>
	public partial class RolePanel : UserControl
	{
		public RolePanel()
		{
			InitializeComponent();
		}

		#region Notification handling

		#region Clear form

		public void ClearForm()
		{
			if (!CheckAccess())
			{
				Dispatcher.BeginInvoke(new ClearFormDelegate(ClearForm));
				return;
			}

			m_user = null;
			m_roles = null;
			formGrid.DataContext = null;
			userRoles.ItemsSource = null;
			roleList.SelectedItem = RoleEnum.NONE_SELECTED;
			UpdateButtons();
		}
		private delegate void ClearFormDelegate();

		#endregion

		#region Show user

		public void ShowUser(UserVO user, IList<RoleEnum> roles)
		{
			if (!CheckAccess())
			{
				Dispatcher.BeginInvoke(new ShowUserDelegate(ShowUser), new object[] { user, roles });
				return;
			}

			if (user == null)
			{
				ClearForm();
			}
			else
			{
				m_user = user;
				m_roles = roles;
				formGrid.DataContext = user;
				userRoles.ItemsSource = roles;
				roleList.SelectedItem = RoleEnum.NONE_SELECTED;
				UpdateButtons();
			}
		}
		private delegate void ShowUserDelegate(UserVO user, IList<RoleEnum> roles);

		#endregion

		#region Show user roles

		public void ShowUserRoles(IList<RoleEnum> roles)
		{
			if (!CheckAccess())
			{
				Dispatcher.BeginInvoke(new ShowUserRolesDelegate(ShowUserRoles), new object[] { roles });
				return;
			}

			userRoles.ItemsSource = roles;
			UpdateButtons();
		}
		private delegate void ShowUserRolesDelegate(IList<RoleEnum> roles);

		#endregion

		#endregion

		#region Events

		#region Request add role

		/// <summary>
		/// The add role event
		/// </summary>
		public event EventHandler AddRole;

		/// <summary>
		/// Fires the add role event
		/// </summary>
		/// <param name="args">The arguments for the event</param>
		protected virtual void OnAddRole(EventArgs args)
		{
			if (AddRole != null) AddRole(this, args);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SetAddRole()
		{
			OnAddRole(new EventArgs());
		}

		#endregion

		#region Request remove role

		/// <summary>
		/// The remove role event
		/// </summary>
		public event EventHandler RemoveRole;

		/// <summary>
		/// Fires the remove role event
		/// </summary>
		/// <param name="args">The arguments for the event</param>
		protected virtual void OnRemoveRole(EventArgs args)
		{
			if (RemoveRole != null) RemoveRole(this, args);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SetRemoveRole()
		{
			OnRemoveRole(new EventArgs());
		}

		#endregion

		#endregion

		#region Properties

		public UserVO User
		{
			get { return m_user; }
		}
		private UserVO m_user;

		public IList<RoleEnum> Roles
		{
			get { return m_roles; }
		}
		private IList<RoleEnum> m_roles;

		public RoleEnum SelectedRole
		{
			get
			{
				if (roleList.SelectedItem == null) return null;
				return (RoleEnum) roleList.SelectedItem;
			}
		}

		#endregion

		#region Button updating

		private void UpdateButtons()
		{
			IsEnabled = (m_user != null);

			if (bRemove != null) bRemove.IsEnabled = userRoles.SelectedIndex != -1;
			if (bAdd != null) bAdd.IsEnabled = !RoleEnum.NONE_SELECTED.Equals((RoleEnum) roleList.SelectedItem);
		}

		#endregion

		#region Event handling

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateButtons();
		}

		private void userRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateButtons();
		}

		private void roleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateButtons();
		}

		private void bAdd_Click(object sender, RoutedEventArgs e)
		{
			SetAddRole();
		}

		private void bRemove_Click(object sender, RoutedEventArgs e)
		{
			SetRemoveRole();
		}

		#endregion
	}
}
