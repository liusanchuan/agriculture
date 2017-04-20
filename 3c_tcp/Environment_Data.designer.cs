﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _3c_tcp
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Digital_Agriculture")]
	public partial class Environment_DataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertenvironemt_data(environemt_data instance);
    partial void Updateenvironemt_data(environemt_data instance);
    partial void Deleteenvironemt_data(environemt_data instance);
    #endregion
		
		public Environment_DataDataContext() : 
				base(global::_3c_tcp.Properties.Settings.Default.Digital_AgricultureConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public Environment_DataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Environment_DataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Environment_DataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Environment_DataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<environemt_data> environemt_data
		{
			get
			{
				return this.GetTable<environemt_data>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.environemt_data")]
	public partial class environemt_data : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _WiFi_name;
		
		private System.Nullable<System.DateTime> _time;
		
		private System.Nullable<double> _temp;
		
		private System.Nullable<double> _humi;
		
		private System.Nullable<double> _co2;
		
		private System.Nullable<double> _light;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnWiFi_nameChanging(string value);
    partial void OnWiFi_nameChanged();
    partial void OntimeChanging(System.Nullable<System.DateTime> value);
    partial void OntimeChanged();
    partial void OntempChanging(System.Nullable<double> value);
    partial void OntempChanged();
    partial void OnhumiChanging(System.Nullable<double> value);
    partial void OnhumiChanged();
    partial void Onco2Changing(System.Nullable<double> value);
    partial void Onco2Changed();
    partial void OnlightChanging(System.Nullable<double> value);
    partial void OnlightChanged();
    #endregion
		
		public environemt_data()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WiFi_name", DbType="NChar(10)")]
		public string WiFi_name
		{
			get
			{
				return this._WiFi_name;
			}
			set
			{
				if ((this._WiFi_name != value))
				{
					this.OnWiFi_nameChanging(value);
					this.SendPropertyChanging();
					this._WiFi_name = value;
					this.SendPropertyChanged("WiFi_name");
					this.OnWiFi_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_time", DbType="DateTime")]
		public System.Nullable<System.DateTime> time
		{
			get
			{
				return this._time;
			}
			set
			{
				if ((this._time != value))
				{
					this.OntimeChanging(value);
					this.SendPropertyChanging();
					this._time = value;
					this.SendPropertyChanged("time");
					this.OntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_temp", DbType="Float")]
		public System.Nullable<double> temp
		{
			get
			{
				return this._temp;
			}
			set
			{
				if ((this._temp != value))
				{
					this.OntempChanging(value);
					this.SendPropertyChanging();
					this._temp = value;
					this.SendPropertyChanged("temp");
					this.OntempChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_humi", DbType="Float")]
		public System.Nullable<double> humi
		{
			get
			{
				return this._humi;
			}
			set
			{
				if ((this._humi != value))
				{
					this.OnhumiChanging(value);
					this.SendPropertyChanging();
					this._humi = value;
					this.SendPropertyChanged("humi");
					this.OnhumiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_co2", DbType="Float")]
		public System.Nullable<double> co2
		{
			get
			{
				return this._co2;
			}
			set
			{
				if ((this._co2 != value))
				{
					this.Onco2Changing(value);
					this.SendPropertyChanging();
					this._co2 = value;
					this.SendPropertyChanged("co2");
					this.Onco2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_light", DbType="Float")]
		public System.Nullable<double> light
		{
			get
			{
				return this._light;
			}
			set
			{
				if ((this._light != value))
				{
					this.OnlightChanging(value);
					this.SendPropertyChanging();
					this._light = value;
					this.SendPropertyChanged("light");
					this.OnlightChanged();
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
}
#pragma warning restore 1591
