using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectManagerBLL;
using ProjectManagerLibrary.Models;
using System.Web.UI.HtmlControls;

namespace ProjectManagerWeb
{
    public partial class IssueDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                        link.HRef = "~/IssueAttachmentDownload.aspx?IssueID=" + issueAttachments[j].IssueID.ToString();
                        tcell5.Controls.Add(link);

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

    }
}