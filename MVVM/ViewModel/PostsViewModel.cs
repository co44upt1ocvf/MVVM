using MVVM.ViewModel.Helpers;
using MVVM.Model;
using MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class PostsViewModel : BindingHelper
    {
        public BindableCommand AddCommand { get; set; }
        public BindableCommand EditCommand { get; set; }
        public BindableCommand DeleteCommand { get; set; }

        private PostsModel selected = new PostsModel();
        public PostsModel Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PostsModel> posts;
        public ObservableCollection<PostsModel> Posts
        {
            get { return posts; }
            set 
            { 
                posts = value; 
                OnPropertyChanged(); 
            }
        }

        public PostsViewModel()
        {
            Posts = new ObservableCollection<PostsModel>();

            AddCommand = new BindableCommand(_ => Add());
            EditCommand = new BindableCommand(_ => Edit());
            DeleteCommand = new BindableCommand(_ => Delete());
        }

        public void Add()
        {
            var newPost = new PostsModel
            {
                Id = Posts.Count + 1,
                Title = Selected.Title,
                Content = Selected.Content
            };

            Posts.Add(newPost);
        }
        public void Edit() //todo fix
        {
            if (Selected != null)
            {
                int index = Posts.IndexOf(Selected);
                if (index != -1)
                {
                    Posts[index] = new PostsModel(Selected.Title, Selected.Content);
                }
            }
        }
        public void Delete() //todo fix
        {
            if (Selected != null)
            {
                Posts.Remove(Selected);
            }
        }
    }
}
