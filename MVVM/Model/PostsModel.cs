using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class PostsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public PostsModel(string title, string content) 
        { 
            Title = title;
            Content = content;
        }
        public PostsModel() { }
    }
}
