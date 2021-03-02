using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using HCare.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;


namespace HCare.Server.DAL
{
	public partial class HcDiseasesDAL
	{
		#region Auto Generated 

		public bool SaveHcDiseasesInfo(HcDiseasesEntity hcDiseasesEntity, Database db, DbTransaction transaction)
		{
			string sql = "INSERT INTO HC_Diseases ( DiseaseName, DiseaseDesc, Sypmtoms, ShortName, isActive) VALUES (  @Diseasename,  @Diseasedesc,  @Sypmtoms,  @Shortname,  @Isactive )";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);

			db.AddInParameter(dbCommand, "Diseasename", DbType.String, hcDiseasesEntity.Diseasename);
			db.AddInParameter(dbCommand, "Diseasedesc", DbType.String, hcDiseasesEntity.Diseasedesc);
			db.AddInParameter(dbCommand, "Sypmtoms", DbType.String, hcDiseasesEntity.Sypmtoms);
			db.AddInParameter(dbCommand, "Shortname", DbType.String, hcDiseasesEntity.Shortname);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDiseasesEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;		}

		public bool UpdateHcDiseasesInfo(HcDiseasesEntity hcDiseasesEntity, Database db, DbTransaction transaction)
		{
			string sql = "UPDATE HC_Diseases SET DiseaseName= @Diseasename, DiseaseDesc= @Diseasedesc, Sypmtoms= @Sypmtoms, ShortName= @Shortname, isActive= @Isactive WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id",DbType.String, hcDiseasesEntity.Id);
			db.AddInParameter(dbCommand, "Diseasename", DbType.String, hcDiseasesEntity.Diseasename);
			db.AddInParameter(dbCommand, "Diseasedesc", DbType.String, hcDiseasesEntity.Diseasedesc);
			db.AddInParameter(dbCommand, "Sypmtoms", DbType.String, hcDiseasesEntity.Sypmtoms);
			db.AddInParameter(dbCommand, "Shortname", DbType.String, hcDiseasesEntity.Shortname);
			db.AddInParameter(dbCommand, "Isactive", DbType.String, hcDiseasesEntity.Isactive);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public bool DeleteHcDiseasesInfoById(object param, Database db, DbTransaction transaction)
		{
			string sql = "DELETE FROM HC_Diseases WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);

			db.ExecuteNonQuery(dbCommand, transaction);
			return true;
		}

		public HcDiseasesEntity GetSingleHcDiseasesRecordById(object param)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sql = "SELECT ID, DiseaseName, DiseaseDesc, Sypmtoms, ShortName, isActive FROM HC_Diseases WHERE Id=@Id";
			DbCommand dbCommand = db.GetSqlStringCommand(sql);
			db.AddInParameter(dbCommand, "Id", DbType.String, param);
			HcDiseasesEntity hcDiseasesEntity = null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if (dataReader.Read())
				{
					hcDiseasesEntity = new HcDiseasesEntity();
					if (dataReader["ID"] != DBNull.Value)
					{
						hcDiseasesEntity.Id = dataReader["ID"].ToString();
					}
					if (dataReader["DiseaseName"] != DBNull.Value)
					{
						hcDiseasesEntity.Diseasename = dataReader["DiseaseName"].ToString();
					}
					if (dataReader["DiseaseDesc"] != DBNull.Value)
					{
						hcDiseasesEntity.Diseasedesc = dataReader["DiseaseDesc"].ToString();
					}
					if (dataReader["Sypmtoms"] != DBNull.Value)
					{
						hcDiseasesEntity.Sypmtoms = dataReader["Sypmtoms"].ToString();
					}
					if (dataReader["ShortName"] != DBNull.Value)
					{
						hcDiseasesEntity.Shortname = dataReader["ShortName"].ToString();
					}
					if (dataReader["isActive"] != DBNull.Value)
					{
						hcDiseasesEntity.Isactive = dataReader["isActive"].ToString();
					}
				}
			}
			return hcDiseasesEntity;
		}

		#endregion

	}
}

