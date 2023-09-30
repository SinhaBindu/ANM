using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ANM.Models
{
    public class ImmModel
    {
        public int Id { get; set; }
        //[JsonProperty("_submission_time")]
        public string SubDate { get; set; }
        [JsonProperty("_id")]
        public string Sub_id { get; set; }
        [JsonProperty("G2/MOBILE")]
        public string MobileNo { get; set; }
        [JsonProperty("Q1_A")]
        public string Q1_A { get; set; }
        [JsonProperty("Q2_A")]
        public string Q2_A { get; set; }
        [JsonProperty("Q3_A")]
        public string Q3_A { get; set; }
        [JsonProperty("Q4_A")]
        public string Q4_A { get; set; }
        [JsonProperty("Q5_A")]
        public string Q5_A { get; set; }
        [JsonProperty("Q6_A")]
        public string Q6_A { get; set; }
        [JsonProperty("Q7_A")]
        public string Q7_A { get; set; }
        [JsonProperty("Q8_A")]
        public string Q8_A { get; set; }
        [JsonProperty("Q9_A")]
        public string Q9_A { get; set; }
        [JsonProperty("G4/Q1")]
        public string G4_Q1 { get; set; }
        [JsonProperty("G5/Q2")]
        public string G5_Q2 { get; set; }
        [JsonProperty("G6/Q3")]
        public string G6_Q3 { get; set; }
        [JsonProperty("G7/Q4")]
        public string G7_Q4 { get; set; }
        [JsonProperty("G8/Q5")]
        public string G8_Q5 { get; set; }
        [JsonProperty("G9/Q6")]
        public string G9_Q6 { get; set; }
        [JsonProperty("Marks")]
        public string Marks { get; set; }
        [JsonProperty("Q10_A")]
        public string Q10_A { get; set; }
        [JsonProperty("Q11_A")]
        public string Q11_A { get; set; }
        [JsonProperty("Q12_A")]
        public string Q12_A { get; set; }
        //[JsonProperty("_tags")]
        public string C_tags { get; set; }
        [JsonProperty("_uuid")]
        public string C_uuid { get; set; }
        [JsonProperty("today")]
        public string today { get; set; }
        [JsonProperty("G10/Q7")]
        public string G10_Q7 { get; set; }
        [JsonProperty("G11/Q8")]
        public string G11_Q8 { get; set; }
        [JsonProperty("G12/Q9")]
        public string G12_Q9 { get; set; }
        [JsonProperty("G2/ANM")]
        public string G2_ANM { get; set; }
        //[JsonProperty("_notes")]
        public string C_notes { get; set; }
        [JsonProperty("EndTime")]
        public string EndTime { get; set; }
        [JsonProperty("G13/Q10")]
        public string G13_Q10 { get; set; }
        [JsonProperty("G14/Q11")]
        public string G14_Q11 { get; set; }
        [JsonProperty("G15/Q12")]
        public string G15_Q12 { get; set; }
        [JsonProperty("_edited")]
        public string C_edited { get; set; }
        [JsonProperty("_status")]
        public string C_status { get; set; }
        [JsonProperty("G2/BLOCK")]
        public string G2_BLOCK { get; set; }
        [JsonProperty("_version")]
        public string C_version { get; set; }
        [JsonProperty("_duration")]
        public string C_duration { get; set; }
        [JsonProperty("_xform_id")]
        public string C_xform_id { get; set; }
        [JsonProperty("timeStart")]
        public string timeStart { get; set; }
        [JsonProperty("G2/DISTRICT")]
        public string G2_DISTRICT { get; set; }
        //[JsonProperty("_attachments")]
        public string C_attachments { get; set; }
       // [JsonProperty("_geolocation")]
        public string C_geolocation { get; set; }
        [JsonProperty("_media_count")]
        public string C_media_count { get; set; }
        [JsonProperty("_total_media")]
        public string C_total_media { get; set; }
        [JsonProperty("formhub/uuid")]
        public string formhub_uuid { get; set; }
        [JsonProperty("_submitted_by")]
        public string C_submitted_by { get; set; }
        [JsonProperty("_date_modified")]
        public string C_date_modified { get; set; }
        [JsonProperty("meta/instanceID")]
        public string meta_instanceID { get; set; }
        [JsonProperty("_submission_time")]
        public string C_submission_time { get; set; }
        [JsonProperty("_xform_id_string")]
        public string C_xform_id_string { get; set; }
        [JsonProperty("_bamboo_dataset_id")]
        public string C_bamboo_dataset_id { get; set; }
        [JsonProperty("_media_all_received")]
        public string C_media_all_received { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDt { get; set; }
    }
}