/* 
 PureMVC C# Port by Andy Adamczak <andy.adamczak@puremvc.org>, et al.
 PureMVC - Copyright(c) 2006-08 Futurescale, Inc., Some rights reserved. 
 Your reuse is governed by the Creative Commons Attribution 3.0 License 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.PureMVC.EmployeeAdmin.Model.Enum
{
	public class RoleEnum
	{
		public static readonly RoleEnum NONE_SELECTED		= new RoleEnum( "--None Selected--"		,-1 );
		public static readonly RoleEnum ADMIN				= new RoleEnum( "Administrator"			, 0 );
		public static readonly RoleEnum ACCT_PAY	 		= new RoleEnum( "Accounts Payable"		, 1 );
		public static readonly RoleEnum ACCT_RCV			= new RoleEnum( "Accounts Receivable"	, 2 );
		public static readonly RoleEnum EMP_BENEFITS		= new RoleEnum( "Employee Benefits"		, 3 );
		public static readonly RoleEnum GEN_LEDGER			= new RoleEnum( "General Ledger"		, 4 );
		public static readonly RoleEnum PAYROLL				= new RoleEnum( "Payroll"				, 5 );
		public static readonly RoleEnum INVENTORY	 		= new RoleEnum( "Inventory"				, 6 );
		public static readonly RoleEnum PRODUCTION			= new RoleEnum( "Production"			, 7 );
		public static readonly RoleEnum QUALITY_CTL			= new RoleEnum( "Quality Control" 		, 8 );
		public static readonly RoleEnum SALES				= new RoleEnum( "Sales"					, 9 );
		public static readonly RoleEnum ORDERS				= new RoleEnum( "Orders"				,10 );
		public static readonly RoleEnum CUSTOMERS			= new RoleEnum( "Customers"				,11 );
		public static readonly RoleEnum SHIPPING			= new RoleEnum( "Shipping"				,12 );
		public static readonly RoleEnum RETURNS				= new RoleEnum( "Returns"				,13 );
		
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

		public RoleEnum (string value, int ordinal)
		{
			m_value = value;
			m_ordinal = ordinal;
		}


		public static IList<RoleEnum> List
		{
			get
			{
				List<RoleEnum> l = new List<RoleEnum>();
				l.Add(ADMIN);
				l.Add(ACCT_PAY);
				l.Add(ACCT_RCV);
				l.Add(EMP_BENEFITS);
				l.Add(GEN_LEDGER);
				l.Add(PAYROLL);
				l.Add(INVENTORY);
				l.Add(PRODUCTION);
				l.Add(QUALITY_CTL);
				l.Add(SALES);
				l.Add(ORDERS);
				l.Add(CUSTOMERS);
				l.Add(SHIPPING);
				l.Add(RETURNS);
				return l;
			}
		}

		public static IList<RoleEnum> ComboList
		{
			get
			{
				IList<RoleEnum> l = List;
				l.Insert(0, NONE_SELECTED);
				return l;
			}
		}

		public bool Equals(RoleEnum e)
		{
			if (e == null) return false;
			return (Ordinal == e.Ordinal && Value == e.Value);
		}
	}
}
