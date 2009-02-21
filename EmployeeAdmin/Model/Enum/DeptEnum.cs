/* 
	PureMVC CSharp / WPF / EmployeeAdmin Demo - Login
	By Andy Adamczak <andy.adamczak@puremvc.org>
	Copyright(c) 2009 Andy Adamczak, Some rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Demo.PureMVC.EmployeeAdmin.Model.Enum
{
	public class DeptEnum
	{
		public static readonly DeptEnum NONE_SELECTED = new DeptEnum("--None Selected--", -1);
		public static readonly DeptEnum ACCT = new DeptEnum("Accounting", 0);
		public static readonly DeptEnum SALES = new DeptEnum("Sales", 1);
		public static readonly DeptEnum PLANT = new DeptEnum("Plant", 2);
		public static readonly DeptEnum SHIPPING = new DeptEnum("Shipping", 3);
		public static readonly DeptEnum QC = new DeptEnum("Quality Control", 4);

		public int Ordinal
		{
			get { return m_ordinal; }
		}
		private int m_ordinal;

		public string Value
		{
			get { return m_value; }
		}
		private string m_value;

		public DeptEnum(string value, int ordinal)
		{
			m_value = value;
			m_ordinal = ordinal;
		}

		public static IList<DeptEnum> List
		{
			get
			{
				List<DeptEnum> l = new List<DeptEnum>();
				l.Add(ACCT);
				l.Add(SALES);
				l.Add(PLANT);
				return l;
			}
		}

		public static IList<DeptEnum> ComboList
		{
			get
			{
				IList<DeptEnum> l = List;
				l.Insert(0, NONE_SELECTED);
				return l;
			}
		}

		public bool Equals(DeptEnum e)
		{
			if (e == null) return false;
			return (Ordinal == e.Ordinal && Value == e.Value);
		}

		public override string ToString()
		{
			return Value;
		}
	}
}
