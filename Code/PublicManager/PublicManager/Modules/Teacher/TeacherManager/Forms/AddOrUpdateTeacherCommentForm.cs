using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PublicManager.DB;
using PublicManager.Modules.Teacher.TeacherManager.Forms;

namespace PublicManager.Modules.Teacher.TeacherManager.Forms
{
    public partial class AddOrUpdateTeacherCommentForm : Form
    {
        public AddOrUpdateTeacherCommentForm(DB.Entitys.TeacherComment commentObj)
        {
            InitializeComponent();

            CommentObj = commentObj;
            if (CommentObj != null)
            {
               
            }
        }

        public DB.Entitys.TeacherComment CommentObj { get; set; }
    }
}