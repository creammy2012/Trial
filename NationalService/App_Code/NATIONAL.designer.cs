﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="National")]
public partial class NATIONALDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertNatID(NatID instance);
  partial void UpdateNatID(NatID instance);
  partial void DeleteNatID(NatID instance);
  #endregion
	
	public NATIONALDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["NationalConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public NATIONALDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NATIONALDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NATIONALDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public NATIONALDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<NatID> NatIDs
	{
		get
		{
			return this.GetTable<NatID>();
		}
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.NatIDQuery")]
	public ISingleResult<NatIDQueryResult> NatIDQuery([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(300)")] string query)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), query);
		return ((ISingleResult<NatIDQueryResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SelectAllNatIDById")]
	public ISingleResult<SelectAllNatIDByIdResult> SelectAllNatIDById([global::System.Data.Linq.Mapping.ParameterAttribute(Name="NatIDNum", DbType="Int")] System.Nullable<int> natIDNum)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), natIDNum);
		return ((ISingleResult<SelectAllNatIDByIdResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SearchNatID")]
	public ISingleResult<SearchNatIDResult> SearchNatID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Fname", DbType="VarChar(50)")] string fname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MiddleName", DbType="VarChar(50)")] string middleName, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Lname", DbType="VarChar(50)")] string lname, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DOB", DbType="Date")] System.Nullable<System.DateTime> dOB, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Gender", DbType="VarChar(10)")] string gender, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MotherMaiden", DbType="VarChar(50)")] string motherMaiden)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fname, middleName, lname, dOB, gender, motherMaiden);
		return ((ISingleResult<SearchNatIDResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SelectAllNatID")]
	public ISingleResult<SelectAllNatIDResult> SelectAllNatID()
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		return ((ISingleResult<SelectAllNatIDResult>)(result.ReturnValue));
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NatID")]
public partial class NatID : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _NatIDNum;
	
	private string _Fname;
	
	private string _MiddleName;
	
	private string _Lname;
	
	private System.Nullable<System.DateTime> _DOB;
	
	private string _Gender;
	
	private string _MotherMaiden;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnNatIDNumChanging(int value);
    partial void OnNatIDNumChanged();
    partial void OnFnameChanging(string value);
    partial void OnFnameChanged();
    partial void OnMiddleNameChanging(string value);
    partial void OnMiddleNameChanged();
    partial void OnLnameChanging(string value);
    partial void OnLnameChanged();
    partial void OnDOBChanging(System.Nullable<System.DateTime> value);
    partial void OnDOBChanged();
    partial void OnGenderChanging(string value);
    partial void OnGenderChanged();
    partial void OnMotherMaidenChanging(string value);
    partial void OnMotherMaidenChanged();
    #endregion
	
	public NatID()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NatIDNum", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int NatIDNum
	{
		get
		{
			return this._NatIDNum;
		}
		set
		{
			if ((this._NatIDNum != value))
			{
				this.OnNatIDNumChanging(value);
				this.SendPropertyChanging();
				this._NatIDNum = value;
				this.SendPropertyChanged("NatIDNum");
				this.OnNatIDNumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="VarChar(50)")]
	public string Fname
	{
		get
		{
			return this._Fname;
		}
		set
		{
			if ((this._Fname != value))
			{
				this.OnFnameChanging(value);
				this.SendPropertyChanging();
				this._Fname = value;
				this.SendPropertyChanged("Fname");
				this.OnFnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="VarChar(50)")]
	public string MiddleName
	{
		get
		{
			return this._MiddleName;
		}
		set
		{
			if ((this._MiddleName != value))
			{
				this.OnMiddleNameChanging(value);
				this.SendPropertyChanging();
				this._MiddleName = value;
				this.SendPropertyChanged("MiddleName");
				this.OnMiddleNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="VarChar(50)")]
	public string Lname
	{
		get
		{
			return this._Lname;
		}
		set
		{
			if ((this._Lname != value))
			{
				this.OnLnameChanging(value);
				this.SendPropertyChanging();
				this._Lname = value;
				this.SendPropertyChanged("Lname");
				this.OnLnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date")]
	public System.Nullable<System.DateTime> DOB
	{
		get
		{
			return this._DOB;
		}
		set
		{
			if ((this._DOB != value))
			{
				this.OnDOBChanging(value);
				this.SendPropertyChanging();
				this._DOB = value;
				this.SendPropertyChanged("DOB");
				this.OnDOBChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
	public string Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this.OnGenderChanging(value);
				this.SendPropertyChanging();
				this._Gender = value;
				this.SendPropertyChanged("Gender");
				this.OnGenderChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherMaiden", DbType="VarChar(50)")]
	public string MotherMaiden
	{
		get
		{
			return this._MotherMaiden;
		}
		set
		{
			if ((this._MotherMaiden != value))
			{
				this.OnMotherMaidenChanging(value);
				this.SendPropertyChanging();
				this._MotherMaiden = value;
				this.SendPropertyChanged("MotherMaiden");
				this.OnMotherMaidenChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

public partial class NatIDQueryResult
{
	
	private int _NatIDNum;
	
	private string _Fname;
	
	private string _MiddleName;
	
	private string _Lname;
	
	private System.Nullable<System.DateTime> _DOB;
	
	private string _Gender;
	
	private string _MotherMaiden;
	
	public NatIDQueryResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NatIDNum", DbType="Int NOT NULL")]
	public int NatIDNum
	{
		get
		{
			return this._NatIDNum;
		}
		set
		{
			if ((this._NatIDNum != value))
			{
				this._NatIDNum = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="VarChar(50)")]
	public string Fname
	{
		get
		{
			return this._Fname;
		}
		set
		{
			if ((this._Fname != value))
			{
				this._Fname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="VarChar(50)")]
	public string MiddleName
	{
		get
		{
			return this._MiddleName;
		}
		set
		{
			if ((this._MiddleName != value))
			{
				this._MiddleName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="VarChar(50)")]
	public string Lname
	{
		get
		{
			return this._Lname;
		}
		set
		{
			if ((this._Lname != value))
			{
				this._Lname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date")]
	public System.Nullable<System.DateTime> DOB
	{
		get
		{
			return this._DOB;
		}
		set
		{
			if ((this._DOB != value))
			{
				this._DOB = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
	public string Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this._Gender = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherMaiden", DbType="VarChar(50)")]
	public string MotherMaiden
	{
		get
		{
			return this._MotherMaiden;
		}
		set
		{
			if ((this._MotherMaiden != value))
			{
				this._MotherMaiden = value;
			}
		}
	}
}

public partial class SelectAllNatIDByIdResult
{
	
	private int _NatIDNum;
	
	private string _Fname;
	
	private string _MiddleName;
	
	private string _Lname;
	
	private System.Nullable<System.DateTime> _DOB;
	
	private string _Gender;
	
	private string _MotherMaiden;
	
	public SelectAllNatIDByIdResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NatIDNum", DbType="Int NOT NULL")]
	public int NatIDNum
	{
		get
		{
			return this._NatIDNum;
		}
		set
		{
			if ((this._NatIDNum != value))
			{
				this._NatIDNum = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="VarChar(50)")]
	public string Fname
	{
		get
		{
			return this._Fname;
		}
		set
		{
			if ((this._Fname != value))
			{
				this._Fname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="VarChar(50)")]
	public string MiddleName
	{
		get
		{
			return this._MiddleName;
		}
		set
		{
			if ((this._MiddleName != value))
			{
				this._MiddleName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="VarChar(50)")]
	public string Lname
	{
		get
		{
			return this._Lname;
		}
		set
		{
			if ((this._Lname != value))
			{
				this._Lname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date")]
	public System.Nullable<System.DateTime> DOB
	{
		get
		{
			return this._DOB;
		}
		set
		{
			if ((this._DOB != value))
			{
				this._DOB = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
	public string Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this._Gender = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherMaiden", DbType="VarChar(50)")]
	public string MotherMaiden
	{
		get
		{
			return this._MotherMaiden;
		}
		set
		{
			if ((this._MotherMaiden != value))
			{
				this._MotherMaiden = value;
			}
		}
	}
}

public partial class SearchNatIDResult
{
	
	private int _NatIDNum;
	
	private string _Fname;
	
	private string _MiddleName;
	
	private string _Lname;
	
	private System.Nullable<System.DateTime> _DOB;
	
	private string _Gender;
	
	private string _MotherMaiden;
	
	public SearchNatIDResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NatIDNum", DbType="Int NOT NULL")]
	public int NatIDNum
	{
		get
		{
			return this._NatIDNum;
		}
		set
		{
			if ((this._NatIDNum != value))
			{
				this._NatIDNum = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="VarChar(50)")]
	public string Fname
	{
		get
		{
			return this._Fname;
		}
		set
		{
			if ((this._Fname != value))
			{
				this._Fname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="VarChar(50)")]
	public string MiddleName
	{
		get
		{
			return this._MiddleName;
		}
		set
		{
			if ((this._MiddleName != value))
			{
				this._MiddleName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="VarChar(50)")]
	public string Lname
	{
		get
		{
			return this._Lname;
		}
		set
		{
			if ((this._Lname != value))
			{
				this._Lname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date")]
	public System.Nullable<System.DateTime> DOB
	{
		get
		{
			return this._DOB;
		}
		set
		{
			if ((this._DOB != value))
			{
				this._DOB = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
	public string Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this._Gender = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherMaiden", DbType="VarChar(50)")]
	public string MotherMaiden
	{
		get
		{
			return this._MotherMaiden;
		}
		set
		{
			if ((this._MotherMaiden != value))
			{
				this._MotherMaiden = value;
			}
		}
	}
}

public partial class SelectAllNatIDResult
{
	
	private int _NatIDNum;
	
	private string _Fname;
	
	private string _MiddleName;
	
	private string _Lname;
	
	private System.Nullable<System.DateTime> _DOB;
	
	private string _Gender;
	
	private string _MotherMaiden;
	
	public SelectAllNatIDResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NatIDNum", DbType="Int NOT NULL")]
	public int NatIDNum
	{
		get
		{
			return this._NatIDNum;
		}
		set
		{
			if ((this._NatIDNum != value))
			{
				this._NatIDNum = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="VarChar(50)")]
	public string Fname
	{
		get
		{
			return this._Fname;
		}
		set
		{
			if ((this._Fname != value))
			{
				this._Fname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="VarChar(50)")]
	public string MiddleName
	{
		get
		{
			return this._MiddleName;
		}
		set
		{
			if ((this._MiddleName != value))
			{
				this._MiddleName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="VarChar(50)")]
	public string Lname
	{
		get
		{
			return this._Lname;
		}
		set
		{
			if ((this._Lname != value))
			{
				this._Lname = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date")]
	public System.Nullable<System.DateTime> DOB
	{
		get
		{
			return this._DOB;
		}
		set
		{
			if ((this._DOB != value))
			{
				this._DOB = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="VarChar(10)")]
	public string Gender
	{
		get
		{
			return this._Gender;
		}
		set
		{
			if ((this._Gender != value))
			{
				this._Gender = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherMaiden", DbType="VarChar(50)")]
	public string MotherMaiden
	{
		get
		{
			return this._MotherMaiden;
		}
		set
		{
			if ((this._MotherMaiden != value))
			{
				this._MotherMaiden = value;
			}
		}
	}
}
#pragma warning restore 1591
