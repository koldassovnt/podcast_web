using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using podcast_web.Models;

namespace podcast_web.Controllers
{
    public class ManageAudioController : Controller
    {
        // GET: ManageAudio
        public ActionResult AudioList()
        {

            if (Session["Email"] != null)
            {
                List<Audio> audiolist = new List<Audio>();
                string CS = ConfigurationManager.ConnectionStrings["PodcastLibContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllAudioFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Audio audio = new Audio();
                        audio.Id = Convert.ToInt32(rdr["Id"]);
                        audio.Name = rdr["Name"].ToString();
                        audio.FileSize = Convert.ToInt32(rdr["FileSize"]);
                        audio.FilePath = rdr["FilePath"].ToString();
                        audiolist.Add(audio);
                    }
                }

                ViewBag.AudioList = audiolist;
                return View();
            }

            return RedirectToAction("Error403", "Home", new { area = "" });
        }

        [HttpPost]
        public ActionResult AudioList(HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                string fileName = Path.GetFileName(fileupload.FileName);
                int fileSize = fileupload.ContentLength;
                int Size = fileSize / 1000000;
                fileupload.SaveAs(Server.MapPath("~/AudioFileUpload/" + fileName));
                
                string CS = ConfigurationManager.ConnectionStrings["PodcastLibContext"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("spAddNewAudioFile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", fileName);
                    cmd.Parameters.AddWithValue("@FileSize", Size);
                    cmd.Parameters.AddWithValue("FilePath", "~/AudioFileUpload/" + fileName);
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToAction("AudioList");
        }
    }
}