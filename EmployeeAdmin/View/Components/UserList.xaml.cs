/* 
	PureMVC CSharp / WPF / EmployeeAdmin Demo - Login
	By Andy Adamczak <andy.adamczak@puremvc.org>
	Copyright(c) 2009 Andy Adamczak, Some rights reserved.
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
using Demo.PureMVC.EmployeeAdmin.Model.VO;

namespace Demo.PureMVC.EmployeeAdmin.View.Components
{
	/// <summary>
	/// Interaction logic for UserList.xaml
	/// </summary>
	public partial class UserList : UserControl
	{
		public UserList()
		{
			InitializeComponent();
		}

		#region Notification handling

		#region Load users

		public void LoadUsers(IList<UserVO> list)
		{
			if (!CheckAccess())
			{
				Dispatcher.BeginInvoke(new LoadUsersDelegate(LoadUsers), new object[] { list });
				return;
			}

			m_currentUsers = list;
			userList.ItemsSource = m_currentUsers;
		}
		private delegate void LoadUsersDelegate(IList<UserVO> list);

		#endregion

		#region Deselect

		public void Deselect()
		{
			if (!CheckAccess())
			{
				Dispatcher.BeginInvoke(new DeselectDelegate(Deselect));
				return;
			}

			userList.SelectedIndex = -1;
		}
		private delegate void DeselectDelegate();

		#endregion

		#endregion

		#region Events

		#region Request create new user

		/// <summary>
		/// The create new user event
		/// </summary>
		public event EventHandler NewUser;

		/// <summary>
		/// Fires the create new user event
		/// </summary>
		/// <param name="args">The arguments for the event</param>
		protected virtual void OnNewUser(EventArgs args)
		{
			if (NewUser != null) NewUser(this, args);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SetNewUser()
		{
			OnNewUser(new EventArgs());
		}

		#endregion

		#region Request delete user

		/// <summary>
		/// The delete user event
		/// </summary>
		public event EventHandler DeleteUser;

		/// <summary>
		/// Fires the delete user event
		/// </summary>
		/// <param name="args">The arguments for the event</param>
		protected virtual void OnDeleteUser(EventArgs args)
		{
			if (DeleteUser != null) DeleteUser(this, args);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SetDeleteUser()
		{
			OnDeleteUser(new EventArgs());
		}

		#endregion

		#region Request create new user

		/// <summary>
		/// The select user event
		/// </summary>
		public event EventHandler SelectUser;

		/// <summary>
		/// Fires the select user event
		/// </summary>
		/// <param name="args">The arguments for the event</param>
		protected virtual void OnSelectUser(EventArgs args)
		{
			if (SelectUser != null) SelectUser(this, args);
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void SetSelectUser()
		{
			OnSelectUser(new EventArgs());
		}

		#endregion

		#endregion

		#region Properties

		public UserVO SelectedUser
		{
			get
			{
				if (userList.SelectedItem == null) return null;
				return (UserVO) userList.SelectedItem;
			}
		}

		#endregion

		#region Private member variables

		private IList<UserVO> m_currentUsers;

		#endregion

		#region Button updating

		private void UpdateButtons()
		{
			bDelete.IsEnabled = (userList.SelectedIndex != -1);
		}

		#endregion

		#region Event handlers

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			UpdateButtons();
		}

		private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateButtons();
			SetSelectUser();
		}

		private void bNew_Click(object sender, RoutedEventArgs e)
		{
			SetNewUser();
		}

		private void bDelete_Click(object sender, RoutedEventArgs e)
		{
			SetDeleteUser();
		}

		#endregion
	}
}
