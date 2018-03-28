using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace RedLemon_ITI.Models
{
    public static class TemplateRepo
    {

        static String connString = System.Configuration.ConfigurationManager.ConnectionStrings["redlemon_iti"].ConnectionString;

        public static ICollection<Activity> GetActivitiesByTemplate(int templateId)
        {
            string spName = "usp_template_get_activities";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("ptemplate_id", templateId));
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            List<Activity> activities = new List<Activity>();
            while (reader.Read())
            {
                Activity activity = new Activity();
                activity.Id = Convert.ToInt32(reader["activity_id"]);
                activity.Name = reader["Name"].ToString();
                activity.TimeToResolve = Convert.ToDecimal(reader["time_to_resolve"]);
                activity.Purpose = reader["purpose"].ToString();
                activity.Instructions = reader["instructions"].ToString();
                activity.AnswerTypeId = Convert.ToInt32(reader["answertype_id"]);
                activity.AnswerType = new AnswerType(activity.AnswerTypeId, reader["AnswerType_Description"].ToString());

                activity.ActivityExtras = GetExtraAtivities(activity.Id, 0);

                activities.Add(activity);
            }

            conn.Close();

            return activities;
        }

        static ICollection<ExtraInformation> GetExtraAtivities(int id, int parentId)
        {
            string spName = "usp_activity_get_extras";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(spName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("pactivity_id", id));
            cmd.Parameters.Add(new MySqlParameter("pparent_id", parentId));
            MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

            List<ExtraInformation> extras = new List<ExtraInformation>();
            while (reader.Read())
            {
                ExtraInformation extra = new ExtraInformation();
                extra.Id = Convert.ToInt32(reader["id"]);
                extra.ExtraTypeInformationId = Convert.ToInt32(reader["extratype_id"]);
                extra.ExtraTypeInformation = new ExtraTypeInformation(extra.ExtraTypeInformationId, reader["extratype_description"].ToString());
                extra.ActivityId = Convert.ToInt32(reader["activity_id"]);
                extra.Key = reader["key"].ToString();
                extra.Value = reader["value"].ToString();
                extra.HasChildren = Convert.ToBoolean(reader["HasChildren"]);
                extras.Add(extra);
            }

            conn.Close();

            foreach (ExtraInformation extra in extras)
            {
                if (extra.HasChildren)
                {
                    extra.Children = GetExtraAtivities(id, extra.Id);
                }
            }

            return extras;
        }
    }
}