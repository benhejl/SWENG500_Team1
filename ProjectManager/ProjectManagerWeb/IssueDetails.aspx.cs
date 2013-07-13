using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerBLL;
using ProjectManagerLibrary.Models;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Web.Security;

namespace ProjectManagerWeb
{
    public partial class IssueDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // select the correct Issue Details or Attachments Jquery tabs based on Page Postback.
            if (!Page.IsPostBack)
                ClientScript.RegisterStartupScript(this.GetType(), "selecttab", "javascript:$('#tabs div').hide();$('#tabs div:first').show();$('#tabs ul li:first').addClass('active');", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "selecttab", "javascript:$('#tab-1').hide();$('#tabs ul li:has(a[href=\"#tab-2\"])').click();", true);

            if (!string.IsNullOrEmpty(Request.QueryString["IssueAttachmentID"]))
            {
                var action = Request.QueryString["Action"].ToLower();

                if (action == "download") // download file.
                    GetFileAttachment(Request.QueryString["IssueAttachmentID"]);
                else if (action == "delete") // delete attachment
                    DeleteIssueAttachment(Request.QueryString["IssueAttachmentID"]);
            }

        }

        /// <summary>
        /// Page_PreRender
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // get issue info and display.
            GetIssueDetails();
        }

        
        /// <summary>
        /// GetIssueDetails
        /// </summary>
        private void GetIssueDetails()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["IssueID"]))
                {
                    // get IssueID from query string.
                    var issueID = Int32.Parse(Request.QueryString["IssueID"]);

                    // get Issue details.
                    Issue issue = IssueBLL.GetIssue(issueID);

                    // get project info for this issue.
                    Project project = ProjectBLL.GetProject(issue.ProjectID);

                    // display values.
                    lblIssueID.Text = issue.IssueID.ToString();
                    lblProjectName.Text = project.Name;
                    lblSubject.Text = issue.Subject;
                    lblIssuePriority.Text = issue.CurrentPriority.ToString();
                    lblIssueStatus.Text = issue.CurrentStatus.ToString();
                    lblDescription.Text = issue.Description;
                    lblCategory.Text = issue.IssueCategoryName;
                    lblMilestone.Text = issue.Milestone.ToString();
                    lblAssignee.Text = issue.Assignee.FirstName + " " + issue.Assignee.LastName;
                    lblEntryDate.Text = issue.EntryDate.ToShortDateString();

                    // add Edit Issue Details link.
                    lnkEditDetails.NavigateUrl = "~/IssueDetailsEdit.aspx?IssueID=" + issueID.ToString();
                }

                // Get the list of issue attachments for the issue.
                GetIssueAttachments();

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// GetIssueAttachments
        /// </summary>
        private void GetIssueAttachments()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString["IssueID"]))
                {
                    // get IssueID from query string.
                    var issueID = Int32.Parse(Request.QueryString["IssueID"]);

                    List<IssueAttachment> issueAttachments = new List<IssueAttachment>();

                    // get attachments for the issue
                    issueAttachments = IssueBLL.GetIssueAttachmentsList(issueID);


                    for (int j = 0; j < issueAttachments.Count; j++)
                    {
                        var trow = new HtmlTableRow();
                        tblAttachments.Rows.Add(trow);

                        // File Name
                        var tcell1 = new HtmlTableCell();
                        tcell1.InnerText = issueAttachments[j].FileName;
                        trow.Cells.Add(tcell1);

                        // Entry Date
                        var tcell2 = new HtmlTableCell();
                        tcell2.InnerText = issueAttachments[j].EntryDate.ToString();
                        trow.Cells.Add(tcell2);

                        // Mime Type
                        var tcell3 = new HtmlTableCell();
                        tcell3.InnerText = issueAttachments[j].MimeType;
                        trow.Cells.Add(tcell3);

                        // Description
                        var tcell4 = new HtmlTableCell();
                        tcell4.InnerText = issueAttachments[j].Description;
                        trow.Cells.Add(tcell4);

                        // Download link
                        var tcell5 = new HtmlTableCell();
                        var link = new HtmlAnchor();
                        link.InnerText = "Download";
                        link.HRef = "~/IssueDetails.aspx?Action=Download&IssueAttachmentID=" + issueAttachments[j].IssueAttachmentID.ToString() + "&IssueID=" + Request.QueryString["IssueID"];
                        tcell5.Controls.Add(link);
                        trow.Cells.Add(tcell5);

                        // Delete link
                        var tcell6 = new HtmlTableCell();
                        var linkDel = new HtmlAnchor();
                        linkDel.InnerText = "Delete";
                        linkDel.Attributes.Add("ID", "hplDelete");
                        linkDel.Attributes.Add("class", "clkdelete");
                        linkDel.HRef = "~/IssueDetails.aspx?Action=Delete&IssueAttachmentID=" + issueAttachments[j].IssueAttachmentID.ToString() + "&IssueID=" + Request.QueryString["IssueID"];
                        tcell6.Controls.Add(linkDel);
                        trow.Cells.Add(tcell6);

                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }


        /// <summary>
        /// GetFileAttachment
        /// </summary>
        protected void GetFileAttachment(string issueAttachmentID)
        {
            try
            {
                IssueAttachment file;
                var id = Int32.Parse(issueAttachmentID);
                if (id > 0)
                {
                    // get file info from database.
                    file = IssueBLL.GetIssueAttachment(id); 

                    Response.Expires = 0;
                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    var filename = "attachment; filename=" + file.FileName;
                    Response.AppendHeader("Content-Disposition", filename);
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.AddHeader("Content-Length", file.FileData.Length.ToString());
                    Response.AddHeader("Accept-Header", file.FileData.Length.ToString());
                    Response.AppendHeader("Pragma", "Cache");
                    Response.AppendHeader("Cache-control", "Public");
                    Response.ContentType = file.MimeType;

                    //forces download dialog box
                    Response.BinaryWrite(file.FileData);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                // Caused by Response.End, ignore it
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// DeleteIssueAttachment
        /// </summary>
        /// <param name="issueAttachmentID"></param>
        protected void DeleteIssueAttachment(string issueAttachmentID)
        {
            try
            {
                if (!string.IsNullOrEmpty(issueAttachmentID))
                {
                    var id = Int32.Parse(issueAttachmentID);
                    // Delete Issue Attachment.
                    IssueBLL.DeleteIssueAttachment(id);
                }
            }
            catch (Exception)
            {
                throw;
            }

            // set the tab selection hidden field to issue attachments - tab id 2.
            Response.Redirect("~/IssueDetails.aspx?tab=2&IssueID="  + Request.QueryString["IssueID"] );
        }


        /// <summary>
        /// btnUpload_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(FileUpload1.FileName) && !String.IsNullOrEmpty(Request.QueryString["IssueID"]))
                {
                    // Check if file is allowed
                    if (isValidFile(FileUpload1.FileName))
                    {
                        // instantiate an IssueAttachment object.
                        var issueAttachment = new IssueAttachment();
                        issueAttachment.FileName = FileUpload1.FileName;
                        issueAttachment.Description = txtDescription.Text;
                        issueAttachment.EntryDate = DateTime.Now;
                        issueAttachment.IssueID = Int32.Parse(Request.QueryString["IssueID"]);
                        issueAttachment.MimeType = FileUpload1.PostedFile.ContentType;

                        // Read the file and convert it to Byte Array
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        issueAttachment.FileData = bytes;

                        // Get the userID for the logged in user.
                        var name = HttpContext.Current.User.Identity.Name;
                        var user = UserBLL.GetUserGivenLogonName(name);
                        issueAttachment.UserID = user.UserId;

                        // upload file
                        IssueBLL.AddIssueAttachment(issueAttachment);

                    }
                    else
                    {
                        // not valid file type. display error message.
                        lblErrorMessage.Text = "ERROR: Not a valid file type.";
                    }
                 }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "ERROR: " + ex.Message.ToString();
            }

            // set the tab selection hidden field to issue attachments - tab id 2.
            Response.Redirect("~/IssueDetails.aspx?tab=2&IssueID=" + Request.QueryString["IssueID"]);
        }

        /// <summary>
        /// isValidFile
        /// </summary>
        /// <param name="fileName">string</param>
        /// <returns>bool</returns>
        private bool isValidFile(string fileName)
        {
            bool isvalid = false;

            try
            {
                // Get the FileExtenstion
                var fileExt = System.IO.Path.GetExtension(fileName).ToLower().Replace(".", "");

                // Get the list of valid extensions
                var validExtensions = System.Configuration.ConfigurationManager.AppSettings["ValidFileExtensions"];

                if (!string.IsNullOrEmpty(validExtensions))
                {
                    var sb = new StringBuilder();
                    string[] exts = validExtensions.Split(',');

                    if (exts.Contains(fileExt))
                        isvalid =  true;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return isvalid;
        }



    }
}