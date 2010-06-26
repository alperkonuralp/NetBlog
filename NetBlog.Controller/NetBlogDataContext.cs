using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetBlog.Controller.Common;
using NetBlog.Controller.Entities;

namespace NetBlog.Controller
{
    /// <summary>
    /// Net Blog Data Context
    /// </summary>
    public class NetBlogDataContext
    {
        private List<BBlog> _blogs;
        private List<BBlogCategory> _categories;
        private List<BBlogComment> _comments;
        private List<BBlogPage> _pages;
        private List<BBlogPageComment> _pageComments;
        private List<BBlogPost> _posts;
        private List<BBlogTag> _tags;
    }
}
