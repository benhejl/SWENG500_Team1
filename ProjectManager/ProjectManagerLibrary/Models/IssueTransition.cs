using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagerLibrary.Models
{
    class IssueTransition
    {
        /// <summary>
        ///  Create a new IssueTransition object and initialize the members describing the transition.
        /// </summary>
        /// <param name="newStatus">Status that the issue transitioned to.</param>
        /// <param name="occurredOn">When did the status change occur.</param>
        /// <param name="comments">Comments added for the transition by the user.</param>
        public IssueTransition(Issue.IssueStatus newStatus, DateTime occurredOn, string comments)
        {
            Status = newStatus;
            OccurredOn = occurredOn;
            Comments = comments != null ? comments : string.Empty;
        }

        /// <summary>
        /// Status that the issue transitioned to.
        /// </summary>
        public Issue.IssueStatus Status { get; private set; }
        
        /// <summary>
        /// When did the status change occur.
        /// </summary>
        public DateTime OccurredOn { get; private set; }

        /// <summary>
        /// Comments added for the transition by the user.
        /// </summary>
        public string Comments { get; private set; }
    }
}
